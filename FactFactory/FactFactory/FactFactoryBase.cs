﻿using GetcuReone.ComboPatterns.Factory;
using GetcuReone.ComboPatterns.Interfaces;
using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Entities.Trees;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Exceptions.Entities;
using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.InnerEntities;
using GetcuReone.FactFactory.InnerEntities.Enums;
using GetcuReone.FactFactory.Interfaces;
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
    public abstract class FactFactoryBase<TFactBase, TFactContainer, TFactRule, TFactRuleCollection, TWantAction> : FactoryBase, IFactFactory<TFactBase, TFactContainer, TFactRule, TFactRuleCollection, TWantAction>, IAbstractFactory, IFactTypeCreation
        where TFactBase : class, IFact
        where TFactContainer : FactContainerBase<TFactBase>
        where TFactRule : FactRuleBase<TFactBase>
        where TFactRuleCollection : FactRuleCollectionBase<TFactBase, TFactRule>
        where TWantAction : WantActionBase<TFactBase>
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
            TFactContainer container = ValidateContainer();
            TFactRuleCollection rules = ValidateRules();
            List<TWantAction> wantActions = new List<TWantAction>(WantActions);
            wantActions.Sort(new WorkFactCompare<TFactBase, TWantAction, TFactContainer>(container));

            var defaultFacts = new List<IFact>();
            foreach(IFact fact in GetDefaultFacts(container) ?? Enumerable.Empty<IFact>())
            {
                if (!container.Contains(fact))
                {
                    using (container.CreateIgnoreReadOnlySpace())
                        container.Add(fact);

                    defaultFacts.Add(fact);
                }
            }

            var forestry = BuildTrees(new BuildTreesRequest<TFactBase, TFactRule, TFactRuleCollection, TWantAction, TFactContainer>
            {
                Container = container,
                FactRules = rules,
                WantActions = wantActions,
            });

            foreach (var item in forestry)
            {
                var wantAction = item.Key;
                var trees = item.Value.Trees;
                var needSpecialFacts = item.Value.NeedSpecialFacts;

                List<List<TFactRule>> ruleLevels = GetRuleLevels(trees);

                // Add to the container all the special facts that will be necessary in the calculation.
                foreach (TFactBase fact in needSpecialFacts)
                {
                    using (container.CreateIgnoreReadOnlySpace())
                        container.Add(fact);
                }

                // We calculate all the rules.
                foreach(var ruleLevel in ruleLevels)
                {
                    foreach (var rule in ruleLevel)
                        CalculateRule(rule, container, wantAction);
                }

                wantAction.Invoke(container);

                OnWantActionCalculated(wantAction, container);

                foreach (TFactBase fact in needSpecialFacts)
                {
                    using(container.CreateIgnoreReadOnlySpace())
                        container.Remove(fact);
                }
            }

            OnDeriveFinished(wantActions, container);

            foreach(var fact in defaultFacts)
            {
                using (container.CreateIgnoreReadOnlySpace())
                    container.Remove(fact);
            }

            WantActions.Clear();
        }

        /// <inheritdoc/>
        public virtual TFact DeriveFact<TFact>() where TFact : TFactBase
        {
            TFact fact = default;

            var wantActions = new List<TWantAction>(WantActions);
            WantActions.Clear();

            var inputFacts = new List<IFactType> { GetFactType<TFact>() };

            WantFact(CreateWantAction(
                container => fact = GetCorrectFact<TFact>(container, inputFacts),
                inputFacts));

            Derive();

            WantActions.AddRange(wantActions);

            return fact;
        }

        /// <summary>
        /// Validation container.
        /// </summary>
        /// <returns>Copy <see cref="Container"/></returns>
        private TFactContainer ValidateContainer()
        {
            if (Container == null)
                throw CommonHelper.CreateDeriveException<TFactBase>(ErrorCode.InvalidData, "Container cannot be null.");

            FactContainerBase<TFactBase> containerCopy = Container.Copy();
            if (containerCopy == null)
                throw CommonHelper.CreateDeriveException<TFactBase>(ErrorCode.InvalidData, "IFactContainer.Copy method return null.");
            if (Container.Equals(containerCopy))
                throw CommonHelper.CreateDeriveException<TFactBase>(ErrorCode.InvalidData, "IFactContainer.Copy method return original container.");
            if (!(containerCopy is TFactContainer container))
                throw CommonHelper.CreateDeriveException<TFactBase>(ErrorCode.InvalidData, "IFactContainer.Copy method returned a different type of container.");
            if (container.Any(fact => fact is IConditionFact))
                throw CommonHelper.CreateDeriveException<TFactBase>(ErrorCode.InvalidData, $"Container contains {nameof(IConditionFact)} facts.");

            container.IsReadOnly = true;
            return container;
        }

        /// <summary>
        /// Valudate <see cref="Rules"/>.
        /// </summary>
        /// <returns></returns>
        private TFactRuleCollection ValidateRules()
        {
            // Get a copy of the rules
            if (Rules == null)
                throw CommonHelper.CreateDeriveException<TFactBase>(ErrorCode.InvalidData, "Rules cannot be null.");

            FactRuleCollectionBase<TFactBase, TFactRule> rulesCopy = Rules.Copy();
            if (rulesCopy == null)
                throw CommonHelper.CreateDeriveException<TFactBase>(ErrorCode.InvalidData, "FactRuleCollectionBase.Copy method return null.");
            if (rulesCopy.Equals(Rules))
                throw CommonHelper.CreateDeriveException<TFactBase>(ErrorCode.InvalidData, "FactRuleCollectionBase.Copy method return original rule collection.");
            if (!(rulesCopy is TFactRuleCollection rules))
                throw CommonHelper.CreateDeriveException<TFactBase>(ErrorCode.InvalidData, "FactRuleCollectionBase.Copy method returned a different type of rules.");

            rules.IsReadOnly = true;
            return rules;
        }

        /// <summary>
        /// Build trees.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private Dictionary<TWantAction, (List<FactRuleTree<TFactBase, TFactRule>> Trees, List<IConditionFact> NeedSpecialFacts)> BuildTrees(BuildTreesRequest<TFactBase, TFactRule, TFactRuleCollection, TWantAction, TFactContainer> request)
        {
            var forestry = new Dictionary<TWantAction, (List<FactRuleTree<TFactBase, TFactRule>> Trees, List<IConditionFact> NeedSpecialFacts)>();
            var deriveErrorDetails = new List<DeriveErrorDetail<TFactBase>>();

            foreach (TWantAction wantAction in request.WantActions)
            {
                if (TryDeriveTreesForWantAction(out List<FactRuleTree<TFactBase, TFactRule>> result, wantAction, request.Container, request.FactRules, out List<IConditionFact> specialFacts, out DeriveErrorDetail<TFactBase> detail))
                {
                    forestry.Add(wantAction, (result, specialFacts));
                }
                else
                    deriveErrorDetails.Add(detail);
            }

            if (deriveErrorDetails.Count != 0)
                throw CommonHelper.CreateDeriveException(deriveErrorDetails);

            return forestry;
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
        /// Event handler method 'derive finished'. It is executed at the end of the <see cref="FactFactoryBase{TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction}.Derive"/> method.
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
        protected abstract TWantAction CreateWantAction(Action<IFactContainer<TFactBase>> wantAction, List<IFactType> factTypes);

        /// <summary>
        /// The method determines whether the fact should be recounted.
        /// </summary>
        /// <param name="rule">Rule for calculating the fact.</param>
        /// <param name="container">Fact container.</param>
        /// <param name="wantAction">The initial action for which the parameters are calculated.</param>
        /// <param name="needRemoveFact">If the method returns the true, then this fact will be removed from the container. There will be no deletion if the fact is empty.</param>
        /// <returns>True - fact needs to be recalculated.</returns>
        protected virtual bool NeedRecalculateFact(TFactRule rule, TFactContainer container, TWantAction wantAction, out TFactBase needRemoveFact)
        {
            needRemoveFact = null;
            return false;
        }

        /// <summary>
        /// We are trying to calculate a tree by which we find a fact
        /// </summary>
        /// <param name="treesResult">found trees</param>
        /// <param name="wantAction">desired action information</param>
        /// <param name="container">fact container</param>
        /// <param name="rules">rule collection</param>
        /// <param name="deriveErrorDetail"></param>
        /// <param name="specialFacts"></param>
        /// <returns></returns>
        private bool TryDeriveTreesForWantAction(out List<FactRuleTree<TFactBase, TFactRule>> treesResult, TWantAction wantAction, TFactContainer container, TFactRuleCollection rules, out List<IConditionFact> specialFacts, out DeriveErrorDetail<TFactBase> deriveErrorDetail)
        {
            List<TFactRule> rulesForDerive = rules
                .Where(rule => wantAction.СompatibilityWithRule(rule, wantAction, container))
                .OrderBy(rule => rule, new WorkFactCompare<TFactBase, TFactRule, TFactContainer>(container))
                .ToList();

            treesResult = new List<FactRuleTree<TFactBase, TFactRule>>();
            var deriveFactErrorDetails = new List<DeriveFactErrorDetail>();
            deriveErrorDetail = null;
            specialFacts = new List<IConditionFact>();

            foreach (IFactType wantFact in wantAction.GetNecessaryFactTypes(container))
            {
                if (wantFact.IsFactType<IConditionFact>())
                {
                    if (wantFact.IsFactType<ICannotDerivedFact>())
                    {
                        ICannotDerivedFact cannotDerivedFact = wantFact.CreateConditionFact<ICannotDerivedFact>();

                        if (!TryDeriveRuntimeSpecialFact(cannotDerivedFact, null, wantAction, container, rules, specialFacts))
                            specialFacts.Add(cannotDerivedFact);
                        else
                            deriveFactErrorDetails.Add(new DeriveFactErrorDetail(wantFact, null));

                        continue;
                    }
                    else if (wantFact.IsFactType<ICanDerivedFact>())
                    {
                        ICanDerivedFact canDerivedFact = wantFact.CreateConditionFact<ICanDerivedFact>();

                        if (TryDeriveRuntimeSpecialFact(canDerivedFact, null, wantAction, container, rulesForDerive, specialFacts))
                            specialFacts.Add(canDerivedFact);
                        else
                            deriveFactErrorDetails.Add(new DeriveFactErrorDetail(wantFact, null));

                        continue;
                    }
                    else
                    {
                        IConditionFact conditionFact = wantFact.CreateConditionFact<IConditionFact>();

                        if (conditionFact.Condition<TFactBase, TWantAction, TWantAction, TFactContainer>(wantAction, wantAction, container))
                            specialFacts.Add(conditionFact);
                        else
                            deriveFactErrorDetails.Add(new DeriveFactErrorDetail(wantFact, null));

                        continue;
                    }
                }

                if (TryDeriveTreeForFactInfo(out FactRuleTree<TFactBase, TFactRule> treeResult, wantFact, wantAction, container, rulesForDerive, specialFacts, out List<DeriveFactErrorDetail> details))
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
                deriveErrorDetail = new DeriveErrorDetail<TFactBase>(ErrorCode.FactCannotDerived, $"Failed to derive one or more facts for the action {wantAction.ToString()}.", wantAction, deriveFactErrorDetails);
                return false;
            }

            return true;
        }

        private bool TryDeriveTreeForFactInfo(out FactRuleTree<TFactBase, TFactRule> treeResult, IFactType wantFact, TWantAction wantAction, TFactContainer container, IList<TFactRule> ruleCollection, List<IConditionFact> specialFacts, out List<DeriveFactErrorDetail> deriveFactErrorDetails)
        {
            treeResult = null;
            deriveFactErrorDetails = null;

            // find the rules that can calculate the fact
            List<FactRuleTree<TFactBase, TFactRule>> factRuleTrees = GetFactRuleTrees(wantFact, ruleCollection);

            // Check if we can already derive the fact
            FactRuleTree<TFactBase, TFactRule> factRuleTreeComputed = factRuleTrees.FirstOrDefault(tree => tree.Root.FactRule.CanCalculate(container, wantAction));

            if (factRuleTreeComputed != null)
            {
                factRuleTreeComputed.Built();
                treeResult = factRuleTreeComputed;
                return true;
            }

            List<List<IFactType>> notFoundFactSet = factRuleTrees.ConvertAll(item => new List<IFactType>());
            List<FactRuleNode<TFactBase, TFactRule>> allCompletedNodes = new List<FactRuleNode<TFactBase, TFactRule>>();

            while(true)
            {
                for (int i = factRuleTrees.Count - 1; i >= 0; i--)
                {
                    FactRuleTree<TFactBase, TFactRule> tree = factRuleTrees[i];

                    if (tree.Status != TreeStatus.BeingBuilt)
                        continue;

                    int lastlevelNumber = tree.Levels.Count - 1;

                    // If after synchronization we can calculate the tree.
                    if (SyncComputedNodeForLevelTreeAndCheckGoneRoot(tree, lastlevelNumber, allCompletedNodes, wantAction, container))
                    {
                        tree.Built();
                        continue;
                    }

                    List<FactRuleNode<TFactBase, TFactRule>> lastLevel = tree.Levels[lastlevelNumber];

                    // If in the last level there are no nodes for calculation, then the tree can be calculated.
                    if (lastLevel.Count == 0)
                    {
                        tree.Built();
                        continue;
                    }

                    // Next level nodes.
                    List<FactRuleNode<TFactBase, TFactRule>> nextNodes = new List<FactRuleNode<TFactBase, TFactRule>>();
                    List<FactRuleNode<TFactBase, TFactRule>> currentLevelCompletedNodes = new List<FactRuleNode<TFactBase, TFactRule>>();
                    bool cannotDerived = false;

                    for (int j = 0; j < lastLevel.Count; j++)
                    {
                        FactRuleNode<TFactBase, TFactRule> node = lastLevel[j];
                        List<FactRuleNode<TFactBase, TFactRule>> copatibleAllCompletedNodes = allCompletedNodes
                            .Where(n => node.FactRule.СompatibilityWithRule(n.FactRule, wantAction, container))
                            .ToList();
                        List<IFactType> needFacts = node.FactRule.GetNecessaryFactTypes(wantAction, container);

                        // Exclude special facts and facts for which a solution has already been found.
                        for (int factIndex = needFacts.Count - 1; factIndex >= 0; factIndex--)
                        {
                            IFactType needFactType = needFacts[factIndex];
                            bool needRemove = false;

                            // Exclude runtime special facts
                            if (needFactType.IsFactType<IConditionFact>())
                            {
                                if (specialFacts.Any(fact => fact.GetFactType().EqualsFactType(needFactType)))
                                {
                                    needFacts.Remove(needFactType);
                                    continue;
                                }

                                bool isCannotDerive = needFactType.IsFactType<ICannotDerivedFact>();
                                bool isCanDerived = needFactType.IsFactType<ICanDerivedFact>();

                                if (isCannotDerive || isCanDerived)
                                {
                                    // Check ICannotDerivedFact fact
                                    if (isCannotDerive)
                                    {
                                        ICannotDerivedFact cannotDerivedFact = needFactType.CreateConditionFact<ICannotDerivedFact>();

                                        if (!TryDeriveRuntimeSpecialFact(cannotDerivedFact, node.FactRule, wantAction, container, ruleCollection, specialFacts))
                                        {
                                            specialFacts.Add(cannotDerivedFact);
                                            needRemove = true;
                                        }
                                    }

                                    // Check ICanDerivedFact fact
                                    else
                                    {
                                        ICanDerivedFact canDerivedFact = needFactType.CreateConditionFact<ICanDerivedFact>();

                                        if (TryDeriveRuntimeSpecialFact(canDerivedFact, node.FactRule, wantAction, container, ruleCollection, specialFacts))
                                        {
                                            specialFacts.Add(canDerivedFact);
                                            needRemove = true;
                                        }
                                    }
                                }
                                else
                                {
                                    IConditionFact conditionFact = needFactType.CreateConditionFact<IConditionFact>();

                                    if (conditionFact.Condition<TFactBase, TFactRule, TWantAction, TFactContainer>(node.FactRule, wantAction, container))
                                    {
                                        specialFacts.Add(conditionFact);
                                        needRemove = true;
                                    }
                                }
                            }
                            else
                            {
                                // Exclude facts for which a solution has already been found.
                                var nodeCompleted = copatibleAllCompletedNodes.FirstOrDefault(n => n.FactRule.OutputFactType.EqualsFactType(needFactType));

                                if (nodeCompleted != null)
                                {
                                    node.Childs.Insert(0, nodeCompleted);
                                    needRemove = true;
                                }
                            }

                            if (needRemove)
                                needFacts.Remove(needFactType);
                        }

                        // If the rule can be calculated from the parameters in the container, then add the node to the list of complete.
                        if (needFacts.IsNullOrEmpty())
                        {
                            copatibleAllCompletedNodes.Add(node);
                            allCompletedNodes.Add(node);
                            currentLevelCompletedNodes.Add(node);
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

                            var needRules = ruleCollection
                                .Where(rule => rule.OutputFactType.EqualsFactType(needFact) && !node.ExistsBranch(rule))
                                .ToList();

                            if (needRules.Count > 0)
                            {
                                var nodes = needRules.Select(rule => new FactRuleNode<TFactBase, TFactRule>
                                {
                                    FactRule = rule,
                                    Parent = node,
                                }).ToList();
                                nextNodes.AddRange(nodes);
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
                            cannotDerived = RemoveRuleNodeAndCheckGoneRoot(tree, lastlevelNumber, node);
                            j--;
                        }
                    }

                    if (cannotDerived)
                        tree.Cencel();
                    else if (currentLevelCompletedNodes.Count > 0)
                    {
                        if (SyncComputedNodeForLevelTreeAndCheckGoneRoot(tree, lastlevelNumber, currentLevelCompletedNodes, wantAction, container))
                            tree.Built();
                        else if (nextNodes.Count > 0)
                        {
                            SyncComputedNodes(nextNodes, currentLevelCompletedNodes);
                            tree.Levels.Add(nextNodes);
                        }
                    }
                    else if (nextNodes.Count > 0)
                        tree.Levels.Add(nextNodes);
                    else
                        tree.Built();

                    if (tree.Status != TreeStatus.Cencel)
                    {
                        tree.ContainedRules.Clear();
                        tree.Root.FillRules(tree.ContainedRules);
                    }
                }

                List<FactRuleTree<TFactBase, TFactRule>> builtTrees = factRuleTrees.Where(tree => tree.Status == TreeStatus.Built).ToList();

                if (builtTrees.Count != 0)
                {
                    int minRuleCount = builtTrees.Min(tree => tree.ContainedRules.Count);
                    var suitableTree = builtTrees.First(tree => tree.ContainedRules.Count == minRuleCount);

                    foreach (var tree in factRuleTrees)
                        if (tree != suitableTree && tree.Status != TreeStatus.Cencel && tree.ContainedRules.Count >= minRuleCount)
                            tree.Cencel();

                    if (factRuleTrees.All(tree => tree.Status != TreeStatus.BeingBuilt))
                    {
                        treeResult = suitableTree;
                        return true;
                    }
                }

                if (factRuleTrees.All(tree => tree.Status == TreeStatus.Cencel))
                    break;
            }

            deriveFactErrorDetails = new List<DeriveFactErrorDetail>();

            foreach (var factSet in notFoundFactSet)
                if (factSet.Count != 0)
                    deriveFactErrorDetails.Add(new DeriveFactErrorDetail(wantFact, factSet.ToReadOnlyCollection()));

            return false;
        }

        /// <summary>
        /// Returns trees. Their number is equal to the number of rules that can derive the necessary <paramref name="wantFact"/>.
        /// </summary>
        /// <param name="wantFact">derive fact</param>
        /// <param name="rules">rule set</param>
        /// <returns></returns>
        private List<FactRuleTree<TFactBase, TFactRule>> GetFactRuleTrees(IFactType wantFact, IList<TFactRule> rules)
        {
            if (rules.IsNullOrEmpty())
                throw CommonHelper.CreateDeriveException<TFactBase>(ErrorCode.EmptyRuleCollection, "Rules cannot be null.");

            List<FactRuleTree<TFactBase, TFactRule>> factRuleTrees = rules.Where(rule => rule.OutputFactType.EqualsFactType(wantFact))
                    .Select(rule =>
                    {
                        var tree = new FactRuleTree<TFactBase, TFactRule>
                        {
                            Root = new FactRuleNode<TFactBase, TFactRule> { FactRule = rule },
                        };
                        tree.Levels.Add(new List<FactRuleNode<TFactBase, TFactRule>> { tree.Root });
                        tree.ContainedRules.Add(rule);
                        return tree;
                    })
                    .ToList();

            if (factRuleTrees.IsNullOrEmpty())
                throw CommonHelper.CreateDeriveException<TFactBase>(ErrorCode.RuleNotFound, $"No rules found able to calculate fact {wantFact.FactName}.");

            return factRuleTrees;
        }

        /// <summary>
        /// Synchronizes the level of nodes. Searches for finished nodes and removes them from the level. 
        /// Returns the truth if, invoking itself, the method has passed the root of the tree
        /// </summary>
        /// <param name="factRuleTree"></param>
        /// <param name="level"></param>
        /// <param name="computedNodes"></param>
        /// <param name="wantAction"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        private bool SyncComputedNodeForLevelTreeAndCheckGoneRoot(FactRuleTree<TFactBase, TFactRule> factRuleTree, int level, List<FactRuleNode<TFactBase, TFactRule>> computedNodes, TWantAction wantAction, TFactContainer container)
        {
            if (level < 0)
                return true;

            List<FactRuleNode<TFactBase, TFactRule>> currentLevel = factRuleTree.Levels[level];
            List<FactRuleNode<TFactBase, TFactRule>> computedNodesInCurrentLevel = new List<FactRuleNode<TFactBase, TFactRule>>();

            foreach (var node in currentLevel)
            {
                var copatibleComputedNodes = computedNodes
                    .Where(n => node.FactRule.СompatibilityWithRule(n.FactRule, wantAction, container))
                    .ToList();

                if (node.FactRule.InputFactTypes.Count > 0 && node.FactRule.InputFactTypes.All(f => copatibleComputedNodes.Any(n => n.FactRule.OutputFactType.EqualsFactType(f))))
                    computedNodesInCurrentLevel.Add(node);
                else if (copatibleComputedNodes.Any(n => n.FactRule.EqualsWork(node.FactRule, wantAction, container)))
                    computedNodesInCurrentLevel.Add(node);
            }

            if (computedNodesInCurrentLevel.IsNullOrEmpty())
                return false;

            SyncComputedNodes(currentLevel, computedNodesInCurrentLevel);
            computedNodes.AddRange(computedNodesInCurrentLevel.Where(node => computedNodes.All(n => !n.FactRule.EqualsWork(node.FactRule, wantAction, container))));
            return SyncComputedNodeForLevelTreeAndCheckGoneRoot(factRuleTree, level - 1, computedNodes, wantAction, container);
        }

        private void SyncComputedNodes(List<FactRuleNode<TFactBase, TFactRule>> levelNodes, List<FactRuleNode<TFactBase, TFactRule>> computedNodes)
        {
            // value - parents, key - node matching on child
            Dictionary<FactRuleNode<TFactBase, TFactRule>, List<FactRuleNode<TFactBase, TFactRule>>> keyValuePairs = new Dictionary<FactRuleNode<TFactBase, TFactRule>, List<FactRuleNode<TFactBase, TFactRule>>>();
            foreach (var computedNode in computedNodes.Distinct())
            {
                List<FactRuleNode<TFactBase, TFactRule>> parentNodes = levelNodes
                    .Where(n => n.FactRule.OutputFactType.EqualsFactType(computedNode.FactRule.OutputFactType))
                    .Select(n => n.Parent).ToList();
                keyValuePairs.Add(computedNode, parentNodes);
            }

            foreach (KeyValuePair<FactRuleNode<TFactBase, TFactRule>, List<FactRuleNode<TFactBase, TFactRule>>> keyValuePair in keyValuePairs.Reverse())
            {
                foreach (FactRuleNode<TFactBase, TFactRule> parentNode in keyValuePair.Value)
                {
                    if (parentNode == null)
                        continue;

                    foreach (var removeNode in parentNode.Childs.FindAll(n => n.FactRule.OutputFactType.EqualsFactType(keyValuePair.Key.FactRule.OutputFactType)))
                    {
                        parentNode.Childs.Remove(removeNode);
                        if (levelNodes.IndexOf(removeNode) != -1)
                            levelNodes.Remove(removeNode);
                    }
                    parentNode.Childs.Add(keyValuePair.Key);
                }
            }
        }

        private bool RemoveRuleNodeAndCheckGoneRoot(FactRuleTree<TFactBase, TFactRule> factRuleTree, int level, FactRuleNode<TFactBase, TFactRule> removeNode)
        {

            if (level == 0)
            {
                factRuleTree.Levels[level].Remove(removeNode);
                return true;
            }

            factRuleTree.Levels[level].Remove(removeNode);
            FactRuleNode<TFactBase, TFactRule> parent = removeNode.Parent;
            parent.Childs.Remove(removeNode);

            // If the node has a child node that can calculate this fact
            if (parent.Childs.Any(node => node.FactRule.OutputFactType.EqualsFactType(removeNode.FactRule.OutputFactType)))
                return false;
            else
                return RemoveRuleNodeAndCheckGoneRoot(factRuleTree, level - 1, parent);
        }

        private List<List<TFactRule>> GetRuleLevels(List<FactRuleTree<TFactBase, TFactRule>> trees)
        {
            // Get all rules to be calculated.
            var allRules = new List<TFactRule>();

            foreach (var tree in trees)
                foreach (var rule in tree.ContainedRules)
                    if (!allRules.Contains(rule))
                        allRules.Add(rule);

            // Break down rules into levels where rules can be calculated independently.
            var ruleLevels = new List<List<TFactRule>>();

            int maxCycles = allRules.Count;
            int counterCycles = 0;

            while (allRules.Count != 0)
            {
                var currentLevel = new List<TFactRule>();
                ruleLevels.Add(currentLevel);

                for (int i = allRules.Count - 1; i >= 0; i--)
                {
                    TFactRule currentRule = allRules[i];

                    // We get the number of rules on which the current rule depends.
                    int rulesOnDependCount = allRules
                        .Count(rule => !rule.Equals(currentLevel)
                            && currentRule.InputFactTypes.Any(type => type.EqualsFactType(rule.OutputFactType)));

                    if (rulesOnDependCount != 0)
                        continue;

                    // Sum of rules at the current level calculating the same fact.
                    rulesOnDependCount = currentLevel.Count(rule => rule.OutputFactType.EqualsFactType(currentRule.OutputFactType));

                    if (rulesOnDependCount != 0)
                        continue;

                    allRules.Remove(currentRule);
                    currentLevel.Add(currentRule);
                }

                if (counterCycles > maxCycles)
                    throw CommonHelper.CreateDeriveException<TFactBase>(
                        ErrorCode.InvalidOperation,
                        "The calculation uses interdependent rules.\n" + string.Join("\n", allRules.ConvertAll(rule => rule.ToString())));
            }

            return ruleLevels;
        }

        private void CalculateRule(TFactRule rule, TFactContainer container, TWantAction wantAction)
        {
            // 1. Is it necessary to recount a fact if a fact of this type has already been calculated?
            if (container.Any(fact => fact.GetFactType().EqualsFactType(rule.OutputFactType)))
            {
                if (!NeedRecalculateFact(rule, container, wantAction, out TFactBase needRemoveFact))
                    return;
                else if (needRemoveFact != null)
                {
                    using (container.CreateIgnoreReadOnlySpace())
                        container.Remove(needRemoveFact);
                }
            }

            // 2. Calculete fact
            TFactBase calculateFact = CreateObject(ct => rule.Calculate(ct, wantAction), container);

            if (calculateFact == null)
                throw CommonHelper.CreateDeriveException<TFactBase>(ErrorCode.InvalidOperation, $"Rule {rule.ToString()} return null");

            using (container.CreateIgnoreReadOnlySpace())
                container.Add(calculateFact);

            OnFactCalculatedForWantAction(rule.OutputFactType, container, wantAction);
        }

        private bool TryDeriveRuntimeSpecialFact<TConditionFact>(TConditionFact conditionFact, TFactRule rule, TWantAction wantAction, TFactContainer container, IList<TFactRule> ruleCollection, List<IConditionFact> specialFacts)
            where TConditionFact : IConditionFact
        {
            if (rule != null && conditionFact.IsFactContained<TFactBase, TFactRule, TWantAction, TFactContainer>(rule, wantAction, container))
                return true;
            else if (conditionFact.IsFactContained<TFactBase, TWantAction, TWantAction, TFactContainer>(wantAction, wantAction, container))
                return true;

            try
            {
                // Exclude the rules that accept our special fact at the input to exclude the possibility of recursion.
                var runtimeSpecialFactType = conditionFact.GetFactType();
                var rulesWithoutCurrentFact = ruleCollection
                    .Where(r => 
                        r.InputFactTypes.All(factType => !factType.EqualsFactType(runtimeSpecialFactType)) 
                        && (rule?.СompatibilityWithRule(r, wantAction, container) ?? true))
                    .ToList();
                return TryDeriveTreeForFactInfo(out FactRuleTree<TFactBase, TFactRule> _, conditionFact.FactType, wantAction, container, rulesWithoutCurrentFact, new List<IConditionFact>(specialFacts), out var _);
            }
            catch (InvalidDeriveOperationException<TFactBase> ex)
            {
                if (ex.Details != null && ex.Details.Count == 1)
                {
                    DeriveErrorDetail<TFactBase> detail = ex.Details.First();

                    if (detail.Code == ErrorCode.RuleNotFound || detail.Code == ErrorCode.EmptyRuleCollection)
                        return false;
                }

                throw;
            }
            catch
            {
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
        protected virtual TFact GetCorrectFact<TFact>(IFactContainer<TFactBase> container, IReadOnlyCollection<IFactType> inputFactTypes)
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
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts)),
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
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts), GetCorrectFact<TFact2>(container, inputFacts)),
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
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts), GetCorrectFact<TFact2>(container, inputFacts), GetCorrectFact<TFact3>(container, inputFacts)),
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
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts), GetCorrectFact<TFact2>(container, inputFacts), GetCorrectFact<TFact3>(container, inputFacts), GetCorrectFact<TFact4>(container, inputFacts)),
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
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts), GetCorrectFact<TFact2>(container, inputFacts), GetCorrectFact<TFact3>(container, inputFacts), GetCorrectFact<TFact4>(container, inputFacts), GetCorrectFact<TFact5>(container, inputFacts)),
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
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts), GetCorrectFact<TFact2>(container, inputFacts), GetCorrectFact<TFact3>(container, inputFacts), GetCorrectFact<TFact4>(container, inputFacts), GetCorrectFact<TFact5>(container, inputFacts), GetCorrectFact<TFact6>(container, inputFacts)),
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
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts), GetCorrectFact<TFact2>(container, inputFacts), GetCorrectFact<TFact3>(container, inputFacts), GetCorrectFact<TFact4>(container, inputFacts), GetCorrectFact<TFact5>(container, inputFacts), GetCorrectFact<TFact6>(container, inputFacts), GetCorrectFact<TFact7>(container, inputFacts)),
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
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts), GetCorrectFact<TFact2>(container, inputFacts), GetCorrectFact<TFact3>(container, inputFacts), GetCorrectFact<TFact4>(container, inputFacts), GetCorrectFact<TFact5>(container, inputFacts), GetCorrectFact<TFact6>(container, inputFacts), GetCorrectFact<TFact7>(container, inputFacts), GetCorrectFact<TFact8>(container, inputFacts)),
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
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts), GetCorrectFact<TFact2>(container, inputFacts), GetCorrectFact<TFact3>(container, inputFacts), GetCorrectFact<TFact4>(container, inputFacts), GetCorrectFact<TFact5>(container, inputFacts), GetCorrectFact<TFact6>(container, inputFacts), GetCorrectFact<TFact7>(container, inputFacts), GetCorrectFact<TFact8>(container, inputFacts), GetCorrectFact<TFact9>(container, inputFacts)),
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
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts), GetCorrectFact<TFact2>(container, inputFacts), GetCorrectFact<TFact3>(container, inputFacts), GetCorrectFact<TFact4>(container, inputFacts), GetCorrectFact<TFact5>(container, inputFacts), GetCorrectFact<TFact6>(container, inputFacts), GetCorrectFact<TFact7>(container, inputFacts), GetCorrectFact<TFact8>(container, inputFacts), GetCorrectFact<TFact9>(container, inputFacts), GetCorrectFact<TFact10>(container, inputFacts)),
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
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts), GetCorrectFact<TFact2>(container, inputFacts), GetCorrectFact<TFact3>(container, inputFacts), GetCorrectFact<TFact4>(container, inputFacts), GetCorrectFact<TFact5>(container, inputFacts), GetCorrectFact<TFact6>(container, inputFacts), GetCorrectFact<TFact7>(container, inputFacts), GetCorrectFact<TFact8>(container, inputFacts), GetCorrectFact<TFact9>(container, inputFacts), GetCorrectFact<TFact10>(container, inputFacts), GetCorrectFact<TFact11>(container, inputFacts)),
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
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts), GetCorrectFact<TFact2>(container, inputFacts), GetCorrectFact<TFact3>(container, inputFacts), GetCorrectFact<TFact4>(container, inputFacts), GetCorrectFact<TFact5>(container, inputFacts), GetCorrectFact<TFact6>(container, inputFacts), GetCorrectFact<TFact7>(container, inputFacts), GetCorrectFact<TFact8>(container, inputFacts), GetCorrectFact<TFact9>(container, inputFacts), GetCorrectFact<TFact10>(container, inputFacts), GetCorrectFact<TFact11>(container, inputFacts), GetCorrectFact<TFact12>(container, inputFacts)),
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
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts), GetCorrectFact<TFact2>(container, inputFacts), GetCorrectFact<TFact3>(container, inputFacts), GetCorrectFact<TFact4>(container, inputFacts), GetCorrectFact<TFact5>(container, inputFacts), GetCorrectFact<TFact6>(container, inputFacts), GetCorrectFact<TFact7>(container, inputFacts), GetCorrectFact<TFact8>(container, inputFacts), GetCorrectFact<TFact9>(container, inputFacts), GetCorrectFact<TFact10>(container, inputFacts), GetCorrectFact<TFact11>(container, inputFacts), GetCorrectFact<TFact12>(container, inputFacts), GetCorrectFact<TFact13>(container, inputFacts)),
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
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts), GetCorrectFact<TFact2>(container, inputFacts), GetCorrectFact<TFact3>(container, inputFacts), GetCorrectFact<TFact4>(container, inputFacts), GetCorrectFact<TFact5>(container, inputFacts), GetCorrectFact<TFact6>(container, inputFacts), GetCorrectFact<TFact7>(container, inputFacts), GetCorrectFact<TFact8>(container, inputFacts), GetCorrectFact<TFact9>(container, inputFacts), GetCorrectFact<TFact10>(container, inputFacts), GetCorrectFact<TFact11>(container, inputFacts), GetCorrectFact<TFact12>(container, inputFacts), GetCorrectFact<TFact13>(container, inputFacts), GetCorrectFact<TFact14>(container, inputFacts)),
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
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts), GetCorrectFact<TFact2>(container, inputFacts), GetCorrectFact<TFact3>(container, inputFacts), GetCorrectFact<TFact4>(container, inputFacts), GetCorrectFact<TFact5>(container, inputFacts), GetCorrectFact<TFact6>(container, inputFacts), GetCorrectFact<TFact7>(container, inputFacts), GetCorrectFact<TFact8>(container, inputFacts), GetCorrectFact<TFact9>(container, inputFacts), GetCorrectFact<TFact10>(container, inputFacts), GetCorrectFact<TFact11>(container, inputFacts), GetCorrectFact<TFact12>(container, inputFacts), GetCorrectFact<TFact13>(container, inputFacts), GetCorrectFact<TFact14>(container, inputFacts), GetCorrectFact<TFact15>(container, inputFacts)),
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
                container => wantFactAction(GetCorrectFact<TFact1>(container, inputFacts), GetCorrectFact<TFact2>(container, inputFacts), GetCorrectFact<TFact3>(container, inputFacts), GetCorrectFact<TFact4>(container, inputFacts), GetCorrectFact<TFact5>(container, inputFacts), GetCorrectFact<TFact6>(container, inputFacts), GetCorrectFact<TFact7>(container, inputFacts), GetCorrectFact<TFact8>(container, inputFacts), GetCorrectFact<TFact9>(container, inputFacts), GetCorrectFact<TFact10>(container, inputFacts), GetCorrectFact<TFact11>(container, inputFacts), GetCorrectFact<TFact12>(container, inputFacts), GetCorrectFact<TFact13>(container, inputFacts), GetCorrectFact<TFact14>(container, inputFacts), GetCorrectFact<TFact15>(container, inputFacts), GetCorrectFact<TFact16>(container, inputFacts)),
                inputFacts));
        }

        #endregion
    }
}
