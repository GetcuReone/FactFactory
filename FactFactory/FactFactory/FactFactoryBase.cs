using GetcuReone.ComboPatterns.Facade;
using GetcuReone.ComboPatterns.Factory;
using GetcuReone.ComboPatterns.Interfaces;
using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.BaseEntities.Context;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Entities.Trees;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Exceptions.Entities;
using GetcuReone.FactFactory.Facades.SingleEntityOperations;
using GetcuReone.FactFactory.Facades.TreeBuildingOperations;
using GetcuReone.FactFactory.Facades.TreesOperations;
using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System;
using System.Collections.Generic;
using System.Linq;
using CommonHelper = GetcuReone.FactFactory.FactFactoryCommonHelper;

namespace GetcuReone.FactFactory
{
    /// <summary>
    /// Base class for fact factory.
    /// </summary>
    public abstract class FactFactoryBase<TFactRule, TFactRuleCollection, TWantAction, TFactContainer> : FactoryBase, IFactFactory<TFactRule, TFactRuleCollection, TWantAction, TFactContainer>, IAbstractFactory, IFactTypeCreation, IFacadeCreation
        where TFactContainer : FactContainerBase
        where TFactRule : FactRuleBase
        where TFactRuleCollection : FactRuleCollectionBase<TFactRule>
        where TWantAction : WantActionBase
    {
        /// <summary>
        /// Want actions
        /// </summary>
        protected List<TWantAction> WantActions { get; } = new List<TWantAction>();

        /// <inheritdoc/>
        public abstract TFactContainer Container { get; }

        /// <inheritdoc/>
        public abstract TFactRuleCollection Rules { get; }

        /// <inheritdoc/>
        public virtual TFacade GetFacade<TFacade>()
            where TFacade : IFacade, new()
        {
            return FacadeBase.Create<TFacade>(this);
        }

        /// <inheritdoc/>
        public virtual IFactType GetFactType<TFact>() where TFact : IFact
        {
            return new FactType<TFact>();
        }

        /// <summary>
        /// Return the fact set that will be contained in the default container.
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        protected virtual IEnumerable<IFact> GetDefaultFacts(TFactContainer container)
        {
            return Enumerable.Empty<IFact>();
        }

        /// <inheritdoc/>
        public virtual void Derive()
        {
            // Create static context data.
            IFactTypeCache cache = GetFactTypeCache();
            ISingleEntityOperations singleEntityOperations = GetSingleEntityOperations();
            ITreeBuildingOperations treeBuildingOperations = GetTreeBuildingOperations();

            // Validating rules and container.
            TFactContainer container = singleEntityOperations.ValidateAndGetContainer(Container);
            TFactRuleCollection rules = singleEntityOperations.ValidateAndGetRules<TFactRule, TFactRuleCollection>(Rules);

            // We fill the container with the default set of facts, if they are missing.
            foreach (IFact fact in GetDefaultFacts(container) ?? Enumerable.Empty<IFact>())
            {
                if (!container.Contains(fact))
                    using (container.CreateIgnoreReadOnlySpace())
                        container.Add(fact);
            }

            // Create a copy of the requested actions. To work with a collection that does not change during the construction of the tree.
            var wantActions = new List<TWantAction>(WantActions);

            var request = new Interfaces.Operations.Entities.BuildTreesRequest<TFactRule, TFactRuleCollection, TWantAction, TFactContainer>
            {
                FactRules = rules,
                WantActionContexts = wantActions.ConvertAll(wantAction => 
                    wantAction.ConvertWantActionContext(container, cache, singleEntityOperations, treeBuildingOperations)),
            };

            if (!treeBuildingOperations.TryBuildTrees(request, out var result))
                throw CommonHelper.CreateDeriveException(result.DeriveErrorDetails);

            foreach(var item in result.TreesByActions)
                CalculateTreeAndDeriveWantFacts(item.Key, item.Value);

            OnDeriveFinished(wantActions, container);
            wantActions.ForEach(wA =>
            {
                if (WantActions.Contains(wA))
                    WantActions.Remove(wA);
            });
        }

        /// <inheritdoc/>
        public virtual TFact DeriveFact<TFact>() where TFact : IFact
        {
            TFact fact = default;

            var wantActions = new List<TWantAction>(WantActions);
            WantActions.Clear();

            var inputFacts = new List<IFactType> { GetFactType<TFact>() };

            WantFact(CreateWantAction(
                facts => fact = facts.GetFact<TFact>(),
                inputFacts));

            Derive();

            WantActions.AddRange(wantActions);

            return fact;
        }

        /// <inheritdoc/>
        public virtual ITreeBuildingOperations GetTreeBuildingOperations()
        {
            return GetFacade<TreeBuildingOperationsFacade>();
        }

        /// <inheritdoc/>
        public virtual ISingleEntityOperations GetSingleEntityOperations()
        {
            return GetFacade<SingleEntityOperationsFacade>();
        }

        /// <inheritdoc/>
        public virtual IFactTypeCache GetFactTypeCache()
        {
            return new FactTypeCache();
        }

        /// <summary>
        /// Build trees for wantActions.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <exception cref="InvalidDeriveOperationException">Mistakes in building trees.</exception>
        /// <returns></returns>
        public virtual Dictionary<WantActionInfo<TWantAction, TFactContainer>, List<TreeByFactRule<TFactRule, TWantAction, TFactContainer>>> BuildTrees(BuildTreesRequest<TFactRule, TFactRuleCollection, TWantAction, TFactContainer> request, IFactFactoryContext context)
        {
            var forestry = new Dictionary<WantActionInfo<TWantAction, TFactContainer>, List<TreeByFactRule<TFactRule, TWantAction, TFactContainer>>>();
            var deriveErrorDetails = new List<DeriveErrorDetail>();

            foreach (TWantAction wantAction in request.WantActions)
            {
                var wantActionInfo = new WantActionInfo<TWantAction, TFactContainer>()
                {
                    FailedConditions = new List<IConditionFact>(),
                    SuccessConditions = new List<IConditionFact>(),
                    WantAction = wantAction,
                    Container = request.Container,
                };

                FactRulesContext<TFactRule, TWantAction, TFactContainer> factRulesContext = context
                    .ToWantActionContext(wantAction, request.Container)
                    .ToFactRulesContext(request.FactRules, true);

                var requestForWantAction = new BuildTreesForWantActionRequest<TFactRule, TWantAction, TFactContainer>
                {
                    WantActionInfo = wantActionInfo,
                    FactRules = factRulesContext
                        .FactRules
                        .ToList(),
                };
                if (TryBuildTreesForWantAction(requestForWantAction, factRulesContext, out List<TreeByFactRule<TFactRule, TWantAction, TFactContainer>> result, out DeriveErrorDetail detail))
                {
                    forestry.Add(wantActionInfo, result);
                }
                else
                    deriveErrorDetails.Add(detail);
            }

            if (deriveErrorDetails.Count != 0)
                throw CommonHelper.CreateDeriveException(deriveErrorDetails);

            return forestry;
        }

        /// <summary>
        /// Tree calculation and fact deriving.
        /// </summary>
        /// <param name="wantActionInfo"></param>
        /// <param name="trees"></param>
        protected virtual void CalculateTreeAndDeriveWantFacts(WantActionInfo<TWantAction, TFactContainer> wantActionInfo, List<TreeByFactRule<TFactRule, TWantAction, TFactContainer>> trees)
        {
            var treesOperationsFacade = GetFacade<TreesOperationsFacade>();

            // We calculate all the rules.
            foreach(var tree in trees)
            {
                foreach(var group in treesOperationsFacade.GetIndependentRulesGroups(tree))
                {
                    foreach(var node in group)
                    {
                        // 1. Add condition facts to the container for the rule.
                        foreach (var conditionFact in node.Info.SuccessConditions)
                            using (wantActionInfo.Container.CreateIgnoreReadOnlySpace())
                                wantActionInfo.Container.Add(conditionFact);

                        // 2. Calculate fact
                        CalculateRule(node.Info.Rule, wantActionInfo.Container, wantActionInfo.WantAction);

                        // 3. Remove condition facts to the container for the rule.
                        foreach (var conditionFact in node.Info.SuccessConditions)
                            using (wantActionInfo.Container.CreateIgnoreReadOnlySpace())
                                wantActionInfo.Container.Remove(conditionFact);
                    }
                }
            }

            foreach (var conditionFact in wantActionInfo.SuccessConditions)
                using (wantActionInfo.Container.CreateIgnoreReadOnlySpace())
                    wantActionInfo.Container.Add(conditionFact);

            wantActionInfo.WantAction.Invoke(wantActionInfo.Container);
            OnWantActionCalculated(wantActionInfo.WantAction, wantActionInfo.Container);

            foreach (var conditionFact in wantActionInfo.SuccessConditions)
                using (wantActionInfo.Container.CreateIgnoreReadOnlySpace())
                    wantActionInfo.Container.Remove(conditionFact);
        }

        /// <summary>
        /// Tree calculation and fact deriving.
        /// </summary>
        /// <param name="wantActionInfo"></param>
        /// <param name="treeByFactRules"></param>
        protected virtual void CalculateTreeAndDeriveWantFacts(Interfaces.Operations.Entities.WantActionInfo<TWantAction, TFactContainer> wantActionInfo, List<Interfaces.Operations.Entities.TreeByFactRule<TFactRule, TWantAction, TFactContainer>> treeByFactRules)
        {
            foreach(var tree in treeByFactRules)
            {
                foreach(var group in tree.Context.TreeBuilding.GetIndependentNodeGroups(tree))
                {
                    foreach(var node in group)
                    {
                        if (tree.Context.SingleEntity.TryCalculateFact(node, tree.Context, out IFact fact))
                        {
                            using (wantActionInfo.Context.Container.CreateIgnoreReadOnlySpace())
                                wantActionInfo.Context.Container.Add(fact);
                            OnFactCalculated(node.Info.Rule, wantActionInfo.Context);
                        }
                    }
                }
            }

            wantActionInfo.Context.SingleEntity.DeriveWantFacts(wantActionInfo);
            OnDeriveWantFacts(wantActionInfo.Context);
        }

        /// <summary>
        /// Action calculation completion handler
        /// </summary>
        /// <param name="wantAction"></param>
        /// <param name="container"></param>
        protected virtual void OnWantActionCalculated(TWantAction wantAction, TFactContainer container) { }

        /// <summary>
        /// Fact calculation event handler for an <paramref name="wantAction"/>.
        /// </summary>
        /// <param name="factType">Type calculated fact.</param>
        /// <param name="container">Container.</param>
        /// <param name="wantAction">The action for which the fact was calculated.</param>
        protected virtual void OnFactCalculatedForWantAction(IFactType factType, TFactContainer container, TWantAction wantAction) { }

        /// <summary>
        /// Fact calculation event handler.
        /// </summary>
        /// <param name="rule">The rule that calculated the fact.</param>
        /// <param name="context">Context.</param>
        protected virtual void OnFactCalculated(TFactRule rule, IWantActionContext<TWantAction, TFactContainer> context) { }

        /// <summary>
        /// Event handler for outputting facts to the WantAction.
        /// </summary>
        /// <param name="context"></param>
        protected virtual void OnDeriveWantFacts(IWantActionContext<TWantAction, TFactContainer> context) { }

        /// <summary>
        /// Event handler method 'derive finished'. It is executed at the end of the <see cref="FactFactoryBase{TFactRule, TFactRuleCollection, TWantAction, TFactContainer}.Derive"/> method.
        /// </summary>
        /// <param name="wantActions">List of desired actions.</param>
        /// <param name="container">Container.</param>
        protected virtual void OnDeriveFinished(List<TWantAction> wantActions, TFactContainer container) { }

        #region methods for derive

        /// <summary>
        /// Creation method <typeparamref name="TWantAction"/>.
        /// </summary>
        /// <param name="wantAction">Action taken after deriving a fact.</param>
        /// <param name="factTypes">Facts required to launch an action.</param>
        /// <returns></returns>
        protected abstract TWantAction CreateWantAction(Action<IFactContainer> wantAction, List<IFactType> factTypes);

        /// <summary>
        /// Creation method <typeparamref name="TWantAction"/>.
        /// </summary>
        /// <param name="wantAction">Action taken after deriving a fact.</param>
        /// <param name="factTypes">Facts required to launch an action.</param>
        /// <returns></returns>
        protected abstract TWantAction CreateWantAction(Action<IEnumerable<IFact>> wantAction, List<IFactType> factTypes);

        /// <summary>
        /// The method determines whether the fact should be recounted.
        /// </summary>
        /// <param name="rule">Rule for calculating the fact.</param>
        /// <param name="container">Fact container.</param>
        /// <param name="wantAction">The initial action for which the parameters are calculated.</param>
        /// <param name="needRemoveFact">If the method returns the true, then this fact will be removed from the container. There will be no deletion if the fact is empty.</param>
        /// <returns>True - fact needs to be recalculated.</returns>
        protected virtual bool NeedRecalculateFact(TFactRule rule, TFactContainer container, TWantAction wantAction, out IFact needRemoveFact)
        {
            needRemoveFact = null;
            return false;
        }

        /// <summary>
        /// Trye build tree for wantAction.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <param name="treesResult">Build trees.</param>
        /// <param name="deriveErrorDetail">Mistakes in building trees.</param>
        /// <returns></returns>
        public virtual bool TryBuildTreesForWantAction(BuildTreesForWantActionRequest<TFactRule, TWantAction, TFactContainer> request, IFactRulesContext<TFactRule, TWantAction, TFactContainer> context, out List<TreeByFactRule<TFactRule, TWantAction, TFactContainer>> treesResult, out DeriveErrorDetail deriveErrorDetail)
        {
            treesResult = new List<TreeByFactRule<TFactRule, TWantAction, TFactContainer>>();
            var deriveFactErrorDetails = new List<DeriveFactErrorDetail>();
            deriveErrorDetail = null;
            WantActionInfo<TWantAction, TFactContainer> wantActionInfo = request.WantActionInfo;

            foreach (IFactType wantFact in wantActionInfo.WantAction.GetNecessaryFactTypes(wantActionInfo.Container))
            {
                if (wantFact.IsFactType<IConditionFact>())
                {
                    IConditionFact conditionFact = wantFact.CreateConditionFact<IConditionFact>();

                    if (CanUseConditionFact(conditionFact, wantActionInfo.WantAction, wantActionInfo, request.FactRules))
                        wantActionInfo.SuccessConditions.Add(conditionFact);
                    else
                        deriveFactErrorDetails.Add(new DeriveFactErrorDetail(wantFact, null));

                    continue;
                }

                var requestForFactType = new BuildTreeForFactTypeRequest<TFactRule, TWantAction, TFactContainer>
                {
                    WantFactType = wantFact,
                    FactRules = request.FactRules,
                    WantActionInfo = wantActionInfo
                };

                if (TryBuildTreeForFactInfo(requestForFactType, out TreeByFactRule<TFactRule, TWantAction, TFactContainer> treeResult, out List<DeriveFactErrorDetail> details))
                {
                    treesResult.Add(treeResult);
                }
                else
                {
                    deriveFactErrorDetails.AddRange(details);
                }
            }

            if (deriveFactErrorDetails.Count != 0)
            {
                deriveErrorDetail = new DeriveErrorDetail(ErrorCode.FactCannotDerived, $"Failed to derive one or more facts for the action {request.WantActionInfo.WantAction}.", request.WantActionInfo.WantAction, deriveFactErrorDetails);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Try build tree for wantFact from wantAcction.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="treeResult">Build tree.</param>
        /// <param name="deriveFactErrorDetails">Errors that occurred while building a tree.</param>
        /// <returns></returns>
        public virtual bool TryBuildTreeForFactInfo(BuildTreeForFactTypeRequest<TFactRule, TWantAction, TFactContainer> request, out TreeByFactRule<TFactRule, TWantAction, TFactContainer> treeResult, out List<DeriveFactErrorDetail> deriveFactErrorDetails)
        {
            treeResult = null;
            deriveFactErrorDetails = null;
            var facade = GetFacade<TreesOperationsFacade>();

            // find the rules that can calculate the fact
            List<TreeByFactRule<TFactRule, TWantAction, TFactContainer>> treesByWantFactType = facade.GetTreesByBuildTreeRequest(request);
            var treeReady = treesByWantFactType.FirstOrDefault(tree => tree.Status == Entities.Trees.Enums.TreeStatus.Built);

            if (treeReady != null)
            {
                treeResult = treeReady;
                return true;
            }

            List<List<IFactType>> notFoundFactSet = treesByWantFactType.ConvertAll(item => new List<IFactType>());
            var allFinichedNodes = new Dictionary<NodeInfoByFactRyle<TFactRule>, NodeByFactRule<TFactRule>>();

            while(true)
            {
                for (int i = treesByWantFactType.Count - 1; i >= 0; i--)
                {
                    TreeByFactRule<TFactRule, TWantAction, TFactContainer> treeByWantFactType = treesByWantFactType[i];
                    WantActionInfo<TWantAction, TFactContainer> wantActionInfo = treeByWantFactType.WantActionInfo;

                    if (treeByWantFactType.Status != Entities.Trees.Enums.TreeStatus.BeingBuilt)
                        continue;

                    int lastlevelNumber = treeByWantFactType.Levels.Count - 1;

                    // If after synchronization we can calculate the tree.
                    if (facade.TrySyncTreeLevelsAndFinishedNodes(treeByWantFactType, lastlevelNumber, allFinichedNodes))
                    {
                        treeByWantFactType.Built();
                        continue;
                    }

                    List<NodeByFactRule<TFactRule>> lastTreeLevel = treeByWantFactType.Levels[lastlevelNumber];

                    // If in the last level there are no nodes for calculation, then the tree can be calculated.
                    if (lastTreeLevel.Count == 0)
                    {
                        treeByWantFactType.Built();
                        continue;
                    }

                    // Next level nodes.
                    var nextTreeLevel = new List<NodeByFactRule<TFactRule>>();
                    var currentLevelFinishedNodes = new Dictionary<NodeInfoByFactRyle<TFactRule>, NodeByFactRule<TFactRule>>();
                    bool cannotDerived = false;

                    for (int j = 0; j < lastTreeLevel.Count; j++)
                    {
                        NodeByFactRule<TFactRule> node = lastTreeLevel[j];
                        NodeInfoByFactRyle<TFactRule> nodeInfo = node.Info;
                        Dictionary<NodeInfoByFactRyle<TFactRule>, NodeByFactRule<TFactRule>> copatibleAllFinishedNodes = allFinichedNodes
                            .Where(finishedNode => node.Info.Rule.СompatibilityWithRule(finishedNode.Key.Rule, wantActionInfo.WantAction, wantActionInfo.Container))
                            .ToDictionary(finishedNode => finishedNode.Key, finishedNode => finishedNode.Value);
                        List<IFactType> needFacts = node.Info.Rule.GetNecessaryFactTypes(wantActionInfo.WantAction, wantActionInfo.Container);

                        // Exclude special facts and facts for which a solution has already been found.
                        for (int factIndex = needFacts.Count - 1; factIndex >= 0; factIndex--)
                        {
                            IFactType needFactType = needFacts[factIndex];
                            bool needRemove = false;

                            // Exclude runtime special facts
                            if (needFactType.IsFactType<IConditionFact>())
                            {
                                if (nodeInfo.SuccessConditions.Exists(fact => fact.GetFactType().EqualsFactType(needFactType)))
                                {
                                    needFacts.Remove(needFactType);
                                    continue;
                                }
                                else if (!nodeInfo.FailedConditions.Exists(fact => fact.GetFactType().EqualsFactType(needFactType)))
                                {
                                    var conditionFact = needFactType.CreateConditionFact<IConditionFact>();

                                    if (CanUseConditionFact(conditionFact, nodeInfo.Rule, wantActionInfo, nodeInfo.FactRules))
                                    {
                                        nodeInfo.SuccessConditions.Add(conditionFact);
                                        needRemove = true;
                                    }
                                    else
                                        nodeInfo.FailedConditions.Add(conditionFact);
                                }
                            }
                            else
                            {
                                // Exclude facts for which a solution has already been found.
                                List<KeyValuePair<NodeInfoByFactRyle<TFactRule>, NodeByFactRule<TFactRule>>> finishedNodesForCurrentFact = copatibleAllFinishedNodes
                                    .Where(finishedNode => finishedNode.Key.Rule.OutputFactType.EqualsFactType(needFactType))
                                    .ToList();

                                if (finishedNodesForCurrentFact.Count != 0)
                                {
                                    node.Childs.Insert(0, finishedNodesForCurrentFact[0].Value);
                                    needRemove = true;
                                }
                            }

                            if (needRemove)
                                needFacts.Remove(needFactType);
                        }

                        // If the rule can be calculated from the parameters in the container, then add the node to the list of complete.
                        if (needFacts.IsNullOrEmpty())
                        {
                            copatibleAllFinishedNodes.Add(node.Info, node);
                            allFinichedNodes.Add(node.Info, node);
                            currentLevelFinishedNodes.Add(node.Info, node);
                            continue;
                        }

                        bool canTryRemoveNode = false;

                        foreach (var needFact in needFacts)
                        {
                            if (needFact.IsFactType<ISpecialFact>())
                            {
                                if (!canTryRemoveNode)
                                    canTryRemoveNode = true;

                                notFoundFactSet[i].Add(needFact);
                                continue;
                            }

                            var needRules = request.FactRules.FindAll(rule => 
                                rule.OutputFactType.EqualsFactType(needFact) && !facade.RuleContainBranch(node, rule));

                            if (needRules.Count > 0)
                            {
                                List<NodeByFactRule<TFactRule>> nodes = facade.GetNodesByRules(needRules, treeByWantFactType, node, request.FactRules);
                                nextTreeLevel.AddRange(nodes);
                                node.Childs.AddRange(nodes);
                            }
                            else
                            {
                                if (!canTryRemoveNode)
                                    canTryRemoveNode = true;

                                notFoundFactSet[i].Add(needFact);
                            }
                        }

                        if (canTryRemoveNode)
                        {
                            // Is there a neighboring node capable of deriving this fact.
                            cannotDerived = facade.TryRemoveRootNode(node, treeByWantFactType, lastlevelNumber);
                            j--;
                        }
                    }

                    if (cannotDerived)
                        treeByWantFactType.Cencel();
                    else if (currentLevelFinishedNodes.Count > 0)
                    {
                        if (facade.TrySyncTreeLevelsAndFinishedNodes(treeByWantFactType, lastlevelNumber, currentLevelFinishedNodes))
                            treeByWantFactType.Built();
                        else if (nextTreeLevel.Count > 0)
                        {
                            facade.SyncTreeLevelAndFinishedNodes(nextTreeLevel, currentLevelFinishedNodes, wantActionInfo.WantAction, wantActionInfo.Container);
                            treeByWantFactType.Levels.Add(nextTreeLevel);
                        }
                    }
                    else if (nextTreeLevel.Count > 0)
                        treeByWantFactType.Levels.Add(nextTreeLevel);
                    else
                        treeByWantFactType.Built();
                }

                List<TreeByFactRule<TFactRule, TWantAction, TFactContainer>> builtTrees = treesByWantFactType
                    .FindAll(tree => tree.Status == Entities.Trees.Enums.TreeStatus.Built);

                if (builtTrees.Count != 0)
                {
                    var countRuleByBuiltTrees = builtTrees.ToDictionary(tree => tree, tree => facade.GetUniqueRulesFromTree(tree).Count);
                    int minRuleCount = countRuleByBuiltTrees.Min(item => item.Value);
                    var suitableTree = countRuleByBuiltTrees.First(item => item.Value == minRuleCount).Key;

                    foreach (var tree in treesByWantFactType)
                        if (tree != suitableTree && tree.Status != Entities.Trees.Enums.TreeStatus.Cencel && facade.GetUniqueRulesFromTree(tree).Count >= minRuleCount)
                            tree.Cencel();

                    if (treesByWantFactType.All(tree => tree.Status != Entities.Trees.Enums.TreeStatus.BeingBuilt))
                    {
                        treeResult = suitableTree;
                        return true;
                    }
                }

                if (treesByWantFactType.All(tree => tree.Status == Entities.Trees.Enums.TreeStatus.Cencel))
                    break;
            }

            deriveFactErrorDetails = new List<DeriveFactErrorDetail>();

            foreach (var factSet in notFoundFactSet)
                if (factSet.Count != 0)
                    deriveFactErrorDetails.Add(new DeriveFactErrorDetail(request.WantFactType, factSet.ToReadOnlyCollection()));

            return false;
        }

        private void CalculateRule(TFactRule rule, TFactContainer container, TWantAction wantAction)
        {
            // 1. Is it necessary to recount a fact if a fact of this type has already been calculated?
            if (container.Any(fact => fact.GetFactType().EqualsFactType(rule.OutputFactType)))
            {
                if (!NeedRecalculateFact(rule, container, wantAction, out IFact needRemoveFact))
                    return;
                else if (needRemoveFact != null)
                {
                    using (container.CreateIgnoreReadOnlySpace())
                        container.Remove(needRemoveFact);
                }
            }

            // 2. Calculete fact
            IFact calculateFact = CreateObject(ct => rule.Calculate(ct, wantAction), container);

            if (calculateFact == null)
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidOperation, $"Rule {rule} return null");

            using (container.CreateIgnoreReadOnlySpace())
                container.Add(calculateFact);

            OnFactCalculatedForWantAction(rule.OutputFactType, container, wantAction);
        }

        private bool CanUseConditionFact<TFactWork>(IConditionFact conditionFact, TFactWork factWork, WantActionInfo<TWantAction, TFactContainer> wantActionInfo, List<TFactRule> compatibilityRules)
            where TFactWork : FactWorkBase
        {
            switch (conditionFact)
            {
                case ICannotDerivedFact _:
                    return !TryBuildTreeForConditionFact(conditionFact, factWork, wantActionInfo, compatibilityRules);
                case ICanDerivedFact _:
                    return TryBuildTreeForConditionFact(conditionFact, factWork, wantActionInfo, compatibilityRules);
                default:
                    return conditionFact.Condition(factWork, wantActionInfo.WantAction, wantActionInfo.Container);
            }
        }

        private bool TryBuildTreeForConditionFact<TFactWork>(IConditionFact conditionFact, TFactWork factWork, WantActionInfo<TWantAction, TFactContainer> wantActionInfo, List<TFactRule> compatibilityRules)
            where TFactWork : FactWorkBase
        {
            if (conditionFact.IsFactContained<TFactWork, TWantAction, TFactContainer>(factWork, wantActionInfo.WantAction, wantActionInfo.Container))
                return true;

            try
            {
                // Exclude the rules that accept our special fact at the input to exclude the possibility of recursion.
                var conditionFactType = conditionFact.GetFactType();
                var rulesWithoutCurrentFact = compatibilityRules
                    .FindAll(r =>
                        r.InputFactTypes.All(factType => !factType.EqualsFactType(conditionFactType))
                        && factWork.СompatibilityWithRule(r, wantActionInfo.WantAction, wantActionInfo.Container));
                var request = new BuildTreeForFactTypeRequest<TFactRule, TWantAction, TFactContainer>
                {
                    FactRules = rulesWithoutCurrentFact,
                    WantActionInfo = wantActionInfo,
                    WantFactType = conditionFact.FactType,
                };
                return TryBuildTreeForFactInfo(request, out var _, out var _);
            }
            catch (InvalidDeriveOperationException ex)
            {
                if (ex.Details != null && ex.Details.Count == 1)
                {
                    DeriveErrorDetail detail = ex.Details.First();

                    if (detail.Code == ErrorCode.RuleNotFound || detail.Code == ErrorCode.EmptyRuleCollection)
                        return false;
                }

                throw;
            }
        }
        #endregion

        #region overloads method WantFact

        /// <summary>
        /// Return the correct fact.
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <param name="container"></param>
        /// <param name="inputFactTypes"></param>
        /// <returns></returns>
        protected virtual TFact GetCorrectFact<TFact>(IFactContainer container, IReadOnlyCollection<IFactType> inputFactTypes)
            where TFact : IFact
        {
            return container.GetFact<TFact>();
        }

        /// <summary>
        /// Requesting a desired fact through action.
        /// </summary>
        /// <param name="wantAction"></param>
        /// <exception cref="FactFactoryException">The action has already been requested before.</exception>
        public virtual void WantFact(TWantAction wantAction)
        {
            if (WantActions.IndexOf(wantAction) != -1)
                throw CommonHelper.CreateException(ErrorCode.InvalidData, "Action already requested");

            WantActions.Add(wantAction);
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1>(
            Action<TFact1> wantFactAction) where TFact1 : IFact
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>() };

            WantFact(CreateWantAction(
                facts => wantFactAction(facts.GetFact<TFact1>()),
                inputFacts));
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1, TFact2>(
            Action<TFact1, TFact2> wantFactAction)
            where TFact1 : IFact
            where TFact2 : IFact
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>() };

            WantFact(CreateWantAction(
                facts => wantFactAction(facts.GetFact<TFact1>(), facts.GetFact<TFact2>()),
                inputFacts));
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <typeparam name="TFact3">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1, TFact2, TFact3>(
            Action<TFact1, TFact2, TFact3> wantFactAction)
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>() };

            WantFact(CreateWantAction(
                facts => wantFactAction(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>()),
                inputFacts));
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <typeparam name="TFact3">Type fact.</typeparam>
        /// <typeparam name="TFact4">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4>(
            Action<TFact1, TFact2, TFact3, TFact4> wantFactAction)
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFact4 : IFact
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>() };

            WantFact(CreateWantAction(
                facts => wantFactAction(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>(), facts.GetFact<TFact4>()),
                inputFacts));
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <typeparam name="TFact3">Type fact.</typeparam>
        /// <typeparam name="TFact4">Type fact.</typeparam>
        /// <typeparam name="TFact5">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5> wantFactAction)
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFact4 : IFact
            where TFact5 : IFact
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>() };

            WantFact(CreateWantAction(
                facts => wantFactAction(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>(), facts.GetFact<TFact4>(), facts.GetFact<TFact5>()),
                inputFacts));
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <typeparam name="TFact3">Type fact.</typeparam>
        /// <typeparam name="TFact4">Type fact.</typeparam>
        /// <typeparam name="TFact5">Type fact.</typeparam>
        /// <typeparam name="TFact6">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6> wantFactAction)
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFact4 : IFact
            where TFact5 : IFact
            where TFact6 : IFact
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>() };

            WantFact(CreateWantAction(
                facts => wantFactAction(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>(), facts.GetFact<TFact4>(), facts.GetFact<TFact5>(), facts.GetFact<TFact6>()),
                inputFacts));
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <typeparam name="TFact3">Type fact.</typeparam>
        /// <typeparam name="TFact4">Type fact.</typeparam>
        /// <typeparam name="TFact5">Type fact.</typeparam>
        /// <typeparam name="TFact6">Type fact.</typeparam>
        /// <typeparam name="TFact7">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7> wantFactAction)
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFact4 : IFact
            where TFact5 : IFact
            where TFact6 : IFact
            where TFact7 : IFact
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>(), GetFactType<TFact7>() };

            WantFact(CreateWantAction(
                facts => wantFactAction(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>(), facts.GetFact<TFact4>(), facts.GetFact<TFact5>(), facts.GetFact<TFact6>(), facts.GetFact<TFact7>()),
                inputFacts));
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <typeparam name="TFact3">Type fact.</typeparam>
        /// <typeparam name="TFact4">Type fact.</typeparam>
        /// <typeparam name="TFact5">Type fact.</typeparam>
        /// <typeparam name="TFact6">Type fact.</typeparam>
        /// <typeparam name="TFact7">Type fact.</typeparam>
        /// <typeparam name="TFact8">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8> wantFactAction)
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFact4 : IFact
            where TFact5 : IFact
            where TFact6 : IFact
            where TFact7 : IFact
            where TFact8 : IFact
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>(), GetFactType<TFact7>(), GetFactType<TFact8>() };

            WantFact(CreateWantAction(
                facts => wantFactAction(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>(), facts.GetFact<TFact4>(), facts.GetFact<TFact5>(), facts.GetFact<TFact6>(), facts.GetFact<TFact7>(), facts.GetFact<TFact8>()),
                inputFacts));
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <typeparam name="TFact3">Type fact.</typeparam>
        /// <typeparam name="TFact4">Type fact.</typeparam>
        /// <typeparam name="TFact5">Type fact.</typeparam>
        /// <typeparam name="TFact6">Type fact.</typeparam>
        /// <typeparam name="TFact7">Type fact.</typeparam>
        /// <typeparam name="TFact8">Type fact.</typeparam>
        /// <typeparam name="TFact9">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9> wantFactAction)
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFact4 : IFact
            where TFact5 : IFact
            where TFact6 : IFact
            where TFact7 : IFact
            where TFact8 : IFact
            where TFact9 : IFact
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>(), GetFactType<TFact7>(), GetFactType<TFact8>(), GetFactType<TFact9>() };

            WantFact(CreateWantAction(
                facts => wantFactAction(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>(), facts.GetFact<TFact4>(), facts.GetFact<TFact5>(), facts.GetFact<TFact6>(), facts.GetFact<TFact7>(), facts.GetFact<TFact8>(), facts.GetFact<TFact9>()),
                inputFacts));
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <typeparam name="TFact3">Type fact.</typeparam>
        /// <typeparam name="TFact4">Type fact.</typeparam>
        /// <typeparam name="TFact5">Type fact.</typeparam>
        /// <typeparam name="TFact6">Type fact.</typeparam>
        /// <typeparam name="TFact7">Type fact.</typeparam>
        /// <typeparam name="TFact8">Type fact.</typeparam>
        /// <typeparam name="TFact9">Type fact.</typeparam>
        /// <typeparam name="TFact10">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10> wantFactAction)
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFact4 : IFact
            where TFact5 : IFact
            where TFact6 : IFact
            where TFact7 : IFact
            where TFact8 : IFact
            where TFact9 : IFact
            where TFact10 : IFact
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>(), GetFactType<TFact7>(), GetFactType<TFact8>(), GetFactType<TFact9>(), GetFactType<TFact10>() };

            WantFact(CreateWantAction(
                facts => wantFactAction(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>(), facts.GetFact<TFact4>(), facts.GetFact<TFact5>(), facts.GetFact<TFact6>(), facts.GetFact<TFact7>(), facts.GetFact<TFact8>(), facts.GetFact<TFact9>(), facts.GetFact<TFact10>()),
                inputFacts));
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <typeparam name="TFact3">Type fact.</typeparam>
        /// <typeparam name="TFact4">Type fact.</typeparam>
        /// <typeparam name="TFact5">Type fact.</typeparam>
        /// <typeparam name="TFact6">Type fact.</typeparam>
        /// <typeparam name="TFact7">Type fact.</typeparam>
        /// <typeparam name="TFact8">Type fact.</typeparam>
        /// <typeparam name="TFact9">Type fact.</typeparam>
        /// <typeparam name="TFact10">Type fact.</typeparam>
        /// <typeparam name="TFact11">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11> wantFactAction)
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFact4 : IFact
            where TFact5 : IFact
            where TFact6 : IFact
            where TFact7 : IFact
            where TFact8 : IFact
            where TFact9 : IFact
            where TFact10 : IFact
            where TFact11 : IFact
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>(), GetFactType<TFact7>(), GetFactType<TFact8>(), GetFactType<TFact9>(), GetFactType<TFact10>(), GetFactType<TFact11>() };

            WantFact(CreateWantAction(
                facts => wantFactAction(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>(), facts.GetFact<TFact4>(), facts.GetFact<TFact5>(), facts.GetFact<TFact6>(), facts.GetFact<TFact7>(), facts.GetFact<TFact8>(), facts.GetFact<TFact9>(), facts.GetFact<TFact10>(), facts.GetFact<TFact11>()),
                inputFacts));
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <typeparam name="TFact3">Type fact.</typeparam>
        /// <typeparam name="TFact4">Type fact.</typeparam>
        /// <typeparam name="TFact5">Type fact.</typeparam>
        /// <typeparam name="TFact6">Type fact.</typeparam>
        /// <typeparam name="TFact7">Type fact.</typeparam>
        /// <typeparam name="TFact8">Type fact.</typeparam>
        /// <typeparam name="TFact9">Type fact.</typeparam>
        /// <typeparam name="TFact10">Type fact.</typeparam>
        /// <typeparam name="TFact11">Type fact.</typeparam>
        /// <typeparam name="TFact12">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12> wantFactAction)
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFact4 : IFact
            where TFact5 : IFact
            where TFact6 : IFact
            where TFact7 : IFact
            where TFact8 : IFact
            where TFact9 : IFact
            where TFact10 : IFact
            where TFact11 : IFact
            where TFact12 : IFact
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>(), GetFactType<TFact7>(), GetFactType<TFact8>(), GetFactType<TFact9>(), GetFactType<TFact10>(), GetFactType<TFact11>(), GetFactType<TFact12>() };

            WantFact(CreateWantAction(
                facts => wantFactAction(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>(), facts.GetFact<TFact4>(), facts.GetFact<TFact5>(), facts.GetFact<TFact6>(), facts.GetFact<TFact7>(), facts.GetFact<TFact8>(), facts.GetFact<TFact9>(), facts.GetFact<TFact10>(), facts.GetFact<TFact11>(), facts.GetFact<TFact12>()),
                inputFacts));
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <typeparam name="TFact3">Type fact.</typeparam>
        /// <typeparam name="TFact4">Type fact.</typeparam>
        /// <typeparam name="TFact5">Type fact.</typeparam>
        /// <typeparam name="TFact6">Type fact.</typeparam>
        /// <typeparam name="TFact7">Type fact.</typeparam>
        /// <typeparam name="TFact8">Type fact.</typeparam>
        /// <typeparam name="TFact9">Type fact.</typeparam>
        /// <typeparam name="TFact10">Type fact.</typeparam>
        /// <typeparam name="TFact11">Type fact.</typeparam>
        /// <typeparam name="TFact12">Type fact.</typeparam>
        /// <typeparam name="TFact13">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13> wantFactAction)
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFact4 : IFact
            where TFact5 : IFact
            where TFact6 : IFact
            where TFact7 : IFact
            where TFact8 : IFact
            where TFact9 : IFact
            where TFact10 : IFact
            where TFact11 : IFact
            where TFact12 : IFact
            where TFact13 : IFact
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>(), GetFactType<TFact7>(), GetFactType<TFact8>(), GetFactType<TFact9>(), GetFactType<TFact10>(), GetFactType<TFact11>(), GetFactType<TFact12>(), GetFactType<TFact13>() };

            WantFact(CreateWantAction(
                facts => wantFactAction(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>(), facts.GetFact<TFact4>(), facts.GetFact<TFact5>(), facts.GetFact<TFact6>(), facts.GetFact<TFact7>(), facts.GetFact<TFact8>(), facts.GetFact<TFact9>(), facts.GetFact<TFact10>(), facts.GetFact<TFact11>(), facts.GetFact<TFact12>(), facts.GetFact<TFact13>()),
                inputFacts));
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <typeparam name="TFact3">Type fact.</typeparam>
        /// <typeparam name="TFact4">Type fact.</typeparam>
        /// <typeparam name="TFact5">Type fact.</typeparam>
        /// <typeparam name="TFact6">Type fact.</typeparam>
        /// <typeparam name="TFact7">Type fact.</typeparam>
        /// <typeparam name="TFact8">Type fact.</typeparam>
        /// <typeparam name="TFact9">Type fact.</typeparam>
        /// <typeparam name="TFact10">Type fact.</typeparam>
        /// <typeparam name="TFact11">Type fact.</typeparam>
        /// <typeparam name="TFact12">Type fact.</typeparam>
        /// <typeparam name="TFact13">Type fact.</typeparam>
        /// <typeparam name="TFact14">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13, TFact14>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13, TFact14> wantFactAction)
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFact4 : IFact
            where TFact5 : IFact
            where TFact6 : IFact
            where TFact7 : IFact
            where TFact8 : IFact
            where TFact9 : IFact
            where TFact10 : IFact
            where TFact11 : IFact
            where TFact12 : IFact
            where TFact13 : IFact
            where TFact14 : IFact
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>(), GetFactType<TFact7>(), GetFactType<TFact8>(), GetFactType<TFact9>(), GetFactType<TFact10>(), GetFactType<TFact11>(), GetFactType<TFact12>(), GetFactType<TFact13>(), GetFactType<TFact14>() };

            WantFact(CreateWantAction(
                facts => wantFactAction(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>(), facts.GetFact<TFact4>(), facts.GetFact<TFact5>(), facts.GetFact<TFact6>(), facts.GetFact<TFact7>(), facts.GetFact<TFact8>(), facts.GetFact<TFact9>(), facts.GetFact<TFact10>(), facts.GetFact<TFact11>(), facts.GetFact<TFact12>(), facts.GetFact<TFact13>(), facts.GetFact<TFact14>()),
                inputFacts));
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <typeparam name="TFact3">Type fact.</typeparam>
        /// <typeparam name="TFact4">Type fact.</typeparam>
        /// <typeparam name="TFact5">Type fact.</typeparam>
        /// <typeparam name="TFact6">Type fact.</typeparam>
        /// <typeparam name="TFact7">Type fact.</typeparam>
        /// <typeparam name="TFact8">Type fact.</typeparam>
        /// <typeparam name="TFact9">Type fact.</typeparam>
        /// <typeparam name="TFact10">Type fact.</typeparam>
        /// <typeparam name="TFact11">Type fact.</typeparam>
        /// <typeparam name="TFact12">Type fact.</typeparam>
        /// <typeparam name="TFact13">Type fact.</typeparam>
        /// <typeparam name="TFact14">Type fact.</typeparam>
        /// <typeparam name="TFact15">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13, TFact14, TFact15>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13, TFact14, TFact15> wantFactAction)
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFact4 : IFact
            where TFact5 : IFact
            where TFact6 : IFact
            where TFact7 : IFact
            where TFact8 : IFact
            where TFact9 : IFact
            where TFact10 : IFact
            where TFact11 : IFact
            where TFact12 : IFact
            where TFact13 : IFact
            where TFact14 : IFact
            where TFact15 : IFact
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>(), GetFactType<TFact7>(), GetFactType<TFact8>(), GetFactType<TFact9>(), GetFactType<TFact10>(), GetFactType<TFact11>(), GetFactType<TFact12>(), GetFactType<TFact13>(), GetFactType<TFact14>(), GetFactType<TFact15>() };

            WantFact(CreateWantAction(
                facts => wantFactAction(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>(), facts.GetFact<TFact4>(), facts.GetFact<TFact5>(), facts.GetFact<TFact6>(), facts.GetFact<TFact7>(), facts.GetFact<TFact8>(), facts.GetFact<TFact9>(), facts.GetFact<TFact10>(), facts.GetFact<TFact11>(), facts.GetFact<TFact12>(), facts.GetFact<TFact13>(), facts.GetFact<TFact14>(), facts.GetFact<TFact15>()),
                inputFacts));
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <typeparam name="TFact3">Type fact.</typeparam>
        /// <typeparam name="TFact4">Type fact.</typeparam>
        /// <typeparam name="TFact5">Type fact.</typeparam>
        /// <typeparam name="TFact6">Type fact.</typeparam>
        /// <typeparam name="TFact7">Type fact.</typeparam>
        /// <typeparam name="TFact8">Type fact.</typeparam>
        /// <typeparam name="TFact9">Type fact.</typeparam>
        /// <typeparam name="TFact10">Type fact.</typeparam>
        /// <typeparam name="TFact11">Type fact.</typeparam>
        /// <typeparam name="TFact12">Type fact.</typeparam>
        /// <typeparam name="TFact13">Type fact.</typeparam>
        /// <typeparam name="TFact14">Type fact.</typeparam>
        /// <typeparam name="TFact15">Type fact.</typeparam>
        /// <typeparam name="TFact16">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        public virtual void WantFact<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13, TFact14, TFact15, TFact16>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13, TFact14, TFact15, TFact16> wantFactAction)
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFact4 : IFact
            where TFact5 : IFact
            where TFact6 : IFact
            where TFact7 : IFact
            where TFact8 : IFact
            where TFact9 : IFact
            where TFact10 : IFact
            where TFact11 : IFact
            where TFact12 : IFact
            where TFact13 : IFact
            where TFact14 : IFact
            where TFact15 : IFact
            where TFact16 : IFact
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>(), GetFactType<TFact7>(), GetFactType<TFact8>(), GetFactType<TFact9>(), GetFactType<TFact10>(), GetFactType<TFact11>(), GetFactType<TFact12>(), GetFactType<TFact13>(), GetFactType<TFact14>(), GetFactType<TFact15>(), GetFactType<TFact16>() };

            WantFact(CreateWantAction(
                facts => wantFactAction(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>(), facts.GetFact<TFact4>(), facts.GetFact<TFact5>(), facts.GetFact<TFact6>(), facts.GetFact<TFact7>(), facts.GetFact<TFact8>(), facts.GetFact<TFact9>(), facts.GetFact<TFact10>(), facts.GetFact<TFact11>(), facts.GetFact<TFact12>(), facts.GetFact<TFact13>(), facts.GetFact<TFact14>(), facts.GetFact<TFact15>(), facts.GetFact<TFact16>()),
                inputFacts));
        }

        #endregion
    }
}
