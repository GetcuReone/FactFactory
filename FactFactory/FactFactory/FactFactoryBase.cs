using GetcuReone.ComboPatterns.Facade;
using GetcuReone.ComboPatterns.Factory;
using GetcuReone.ComboPatterns.Interfaces;
using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.BaseEntities.Context;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Facades.SingleEntityOperations;
using GetcuReone.FactFactory.Facades.TreeBuildingOperations;
using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Interfaces.Operations.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using CommonHelper = GetcuReone.FactFactory.FactFactoryHelper;

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
        /// WantFacts.
        /// </summary>
        protected List<WantFactsInfo<TWantAction, TFactContainer>> WantFactsInfos { get; } = new List<WantFactsInfo<TWantAction, TFactContainer>>();

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
        /// <param name="context">Context.</param>
        /// <returns></returns>
        protected virtual IEnumerable<IFact> GetDefaultFacts(IWantActionContext<TWantAction, TFactContainer> context)
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

            // Validate container and get contexts.
            var contexts = WantFactsInfos.ConvertAll(info => 
                GetWantActionContext(info, treeBuildingOperations, singleEntityOperations, cache));

            // Validating rules.
            TFactRuleCollection rules = singleEntityOperations.ValidateAndGetRules<TFactRule, TFactRuleCollection>(Rules);

            var request = new BuildTreesRequest<TFactRule, TFactRuleCollection, TWantAction, TFactContainer>
            {
                FactRules = rules,
                WantActionContexts = contexts,
            };

            if (!treeBuildingOperations.TryBuildTrees(request, out var result))
                throw CommonHelper.CreateDeriveException(result.DeriveErrorDetails);

            foreach(var item in result.TreesByActions)
                CalculateTreeAndDeriveWantFacts(item.Key, item.Value);

            OnDeriveFinished(contexts);
            contexts.ForEach(context =>
            {
                var wantFactsInfos = WantFactsInfos.FirstOrDefault(info => info.WantAction == context.WantAction && info.Container == context.Container);
                if (wantFactsInfos != null)
                    WantFactsInfos.Remove(wantFactsInfos);
            });
        }

        private IWantActionContext<TWantAction, TFactContainer> GetWantActionContext(WantFactsInfo<TWantAction, TFactContainer> wantFactsInfo, ITreeBuildingOperations treeBuilding, ISingleEntityOperations singleEntity, IFactTypeCache cache)
        {
            singleEntity.ValidateContainer(wantFactsInfo.Container);
            var context = new WantActionContext<TWantAction, TFactContainer>
            {
                Cache = cache,
                Container = wantFactsInfo.Container,
                SingleEntity = singleEntity,
                TreeBuilding = treeBuilding,
                WantAction = wantFactsInfo.WantAction,
            };

            var defaultFacts = GetDefaultFacts(context);

            if (!defaultFacts.IsNullOrEmpty())
            {
                foreach(var defaultFact in defaultFacts)
                {
                    if (!context.Container.Contains(defaultFact))
                        using (context.Container.CreateIgnoreReadOnlySpace())
                            context.Container.Add(defaultFact);
                }
            }

            return context;
        }

        /// <summary>
        /// Derive <typeparamref name="TFactResult"/>.
        /// </summary>
        /// <typeparam name="TFactResult">Type of desired fact.</typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        public virtual TFactResult DeriveFact<TFactResult>(TFactContainer container = null) where TFactResult : IFact
        {
            TFactResult fact = default;

            var previousWantFacts = new List<WantFactsInfo<TWantAction, TFactContainer>>(WantFactsInfos);
            WantFactsInfos.Clear();

            var inputFacts = new List<IFactType> { GetFactType<TFactResult>() };

            WantFacts(
                CreateWantAction(
                    facts => fact = facts.GetFact<TFactResult>(),
                    inputFacts),
                container);

            Derive();

            WantFactsInfos.AddRange(previousWantFacts);

            return fact;
        }

        /// <summary>
        /// Get default container.
        /// </summary>
        /// <returns></returns>
        protected abstract TFactContainer GetDefaultContainer();

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
        /// Tree calculation and fact deriving.
        /// </summary>
        /// <param name="wantActionInfo"></param>
        /// <param name="treeByFactRules"></param>
        protected virtual void CalculateTreeAndDeriveWantFacts(WantActionInfo<TWantAction, TFactContainer> wantActionInfo, List<Interfaces.Operations.Entities.TreeByFactRule<TFactRule, TWantAction, TFactContainer>> treeByFactRules)
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
        /// <param name="context">Contexts.</param>
        protected virtual void OnDeriveFinished(IEnumerable<IWantActionContext<TWantAction, TFactContainer>> context) { }

        #region overloads method WantFact

        /// <summary>
        /// Creation method <typeparamref name="TWantAction"/>.
        /// </summary>
        /// <param name="wantAction">Action taken after deriving a fact.</param>
        /// <param name="factTypes">Facts required to launch an action.</param>
        /// <returns></returns>
        protected abstract TWantAction CreateWantAction(Action<IEnumerable<IFact>> wantAction, List<IFactType> factTypes);

        /// <summary>
        /// Requesting a desired fact through action.
        /// </summary>
        /// <param name="wantAction"></param>
        /// <param name="container"></param>
        /// <exception cref="FactFactoryException">The action has already been requested before.</exception>
        public virtual void WantFacts(TWantAction wantAction, TFactContainer container)
        {
            if (wantAction == null)
                throw CommonHelper.CreateException(ErrorCode.InvalidData, "WantAction is null.");

            var factContainer = container ?? GetDefaultContainer();
            if (WantFactsInfos.Any(info => info.WantAction == wantAction && info.Container == factContainer))
                throw CommonHelper.CreateException(ErrorCode.InvalidData, "Action already requested.");

            WantFactsInfos.Add(new WantFactsInfo<TWantAction, TFactContainer> 
            {
                Container = factContainer,
                WantAction = wantAction,
            });
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        /// <param name="container">Fact container.</param>
        public virtual void WantFacts<TFact1>(Action<TFact1> wantFactAction, TFactContainer container = null)
            where TFact1 : IFact
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>() };

            WantFacts(
                CreateWantAction(
                    facts => wantFactAction(facts.GetFact<TFact1>()),
                    inputFacts),
                container);
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        /// <param name="container">Fact container.</param>
        public virtual void WantFacts<TFact1, TFact2>(
            Action<TFact1, TFact2> wantFactAction, TFactContainer container = null)
            where TFact1 : IFact
            where TFact2 : IFact
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>() };

            WantFacts(
                CreateWantAction(
                    facts => wantFactAction(facts.GetFact<TFact1>(), facts.GetFact<TFact2>()),
                    inputFacts),
                container);
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <typeparam name="TFact3">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        /// <param name="container">Fact container.</param>
        public virtual void WantFacts<TFact1, TFact2, TFact3>(
            Action<TFact1, TFact2, TFact3> wantFactAction, TFactContainer container = null)
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>() };

            WantFacts(
                CreateWantAction(
                    facts => wantFactAction(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>()),
                    inputFacts),
                container);
        }

        /// <summary>
        /// Requesting desired facts through action.
        /// </summary>
        /// <typeparam name="TFact1">Type fact.</typeparam>
        /// <typeparam name="TFact2">Type fact.</typeparam>
        /// <typeparam name="TFact3">Type fact.</typeparam>
        /// <typeparam name="TFact4">Type fact.</typeparam>
        /// <param name="wantFactAction">Desired action.</param>
        /// <param name="container">Fact container.</param>
        public virtual void WantFacts<TFact1, TFact2, TFact3, TFact4>(
            Action<TFact1, TFact2, TFact3, TFact4> wantFactAction, TFactContainer container = null)
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFact4 : IFact
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>() };

            WantFacts(
                CreateWantAction(
                    facts => wantFactAction(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>(), facts.GetFact<TFact4>()),
                    inputFacts),
                container);
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
        /// <param name="container">Fact container.</param>
        public virtual void WantFacts<TFact1, TFact2, TFact3, TFact4, TFact5>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5> wantFactAction, TFactContainer container = null)
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFact4 : IFact
            where TFact5 : IFact
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>() };

            WantFacts(
                CreateWantAction(
                    facts => wantFactAction(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>(), facts.GetFact<TFact4>(), facts.GetFact<TFact5>()),
                    inputFacts),
                container);
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
        /// <param name="container">Fact container.</param>
        public virtual void WantFacts<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6> wantFactAction, TFactContainer container = null)
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFact4 : IFact
            where TFact5 : IFact
            where TFact6 : IFact
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>() };

            WantFacts(
                CreateWantAction(
                    facts => wantFactAction(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>(), facts.GetFact<TFact4>(), facts.GetFact<TFact5>(), facts.GetFact<TFact6>()),
                    inputFacts),
                container);
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
        /// <param name="container">Fact container.</param>
        public virtual void WantFacts<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7> wantFactAction, TFactContainer container = null)
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFact4 : IFact
            where TFact5 : IFact
            where TFact6 : IFact
            where TFact7 : IFact
        {
            var inputFacts = new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), GetFactType<TFact4>(), GetFactType<TFact5>(), GetFactType<TFact6>(), GetFactType<TFact7>() };

            WantFacts(
                CreateWantAction(
                    facts => wantFactAction(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>(), facts.GetFact<TFact4>(), facts.GetFact<TFact5>(), facts.GetFact<TFact6>(), facts.GetFact<TFact7>()),
                    inputFacts),
                container);
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
        /// <param name="container">Fact container.</param>
        public virtual void WantFacts<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8> wantFactAction, TFactContainer container = null)
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

            WantFacts(
                CreateWantAction(
                    facts => wantFactAction(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>(), facts.GetFact<TFact4>(), facts.GetFact<TFact5>(), facts.GetFact<TFact6>(), facts.GetFact<TFact7>(), facts.GetFact<TFact8>()),
                    inputFacts),
                container);
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
        /// <param name="container">Fact container.</param>
        public virtual void WantFacts<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9> wantFactAction, TFactContainer container = null)
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

            WantFacts(
                CreateWantAction(
                    facts => wantFactAction(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>(), facts.GetFact<TFact4>(), facts.GetFact<TFact5>(), facts.GetFact<TFact6>(), facts.GetFact<TFact7>(), facts.GetFact<TFact8>(), facts.GetFact<TFact9>()),
                    inputFacts),
                container);
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
        /// <param name="container">Fact container.</param>
        public virtual void WantFacts<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10> wantFactAction, TFactContainer container = null)
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

            WantFacts(
                CreateWantAction(
                    facts => wantFactAction(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>(), facts.GetFact<TFact4>(), facts.GetFact<TFact5>(), facts.GetFact<TFact6>(), facts.GetFact<TFact7>(), facts.GetFact<TFact8>(), facts.GetFact<TFact9>(), facts.GetFact<TFact10>()),
                    inputFacts),
                container);
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
        /// <param name="container">Fact container.</param>
        public virtual void WantFacts<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11> wantFactAction, TFactContainer container = null)
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

            WantFacts(
                CreateWantAction(
                    facts => wantFactAction(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>(), facts.GetFact<TFact4>(), facts.GetFact<TFact5>(), facts.GetFact<TFact6>(), facts.GetFact<TFact7>(), facts.GetFact<TFact8>(), facts.GetFact<TFact9>(), facts.GetFact<TFact10>(), facts.GetFact<TFact11>()),
                    inputFacts),
                container);
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
        /// <param name="container">Fact container.</param>
        public virtual void WantFacts<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12> wantFactAction, TFactContainer container = null)
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

            WantFacts(
                CreateWantAction(
                    facts => wantFactAction(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>(), facts.GetFact<TFact4>(), facts.GetFact<TFact5>(), facts.GetFact<TFact6>(), facts.GetFact<TFact7>(), facts.GetFact<TFact8>(), facts.GetFact<TFact9>(), facts.GetFact<TFact10>(), facts.GetFact<TFact11>(), facts.GetFact<TFact12>()),
                    inputFacts),
                container);
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
        /// <param name="container">Fact container.</param>
        public virtual void WantFacts<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13> wantFactAction, TFactContainer container = null)
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

            WantFacts(
                CreateWantAction(
                    facts => wantFactAction(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>(), facts.GetFact<TFact4>(), facts.GetFact<TFact5>(), facts.GetFact<TFact6>(), facts.GetFact<TFact7>(), facts.GetFact<TFact8>(), facts.GetFact<TFact9>(), facts.GetFact<TFact10>(), facts.GetFact<TFact11>(), facts.GetFact<TFact12>(), facts.GetFact<TFact13>()),
                    inputFacts),
                container);
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
        /// <param name="container">Fact container.</param>
        public virtual void WantFacts<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13, TFact14>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13, TFact14> wantFactAction, TFactContainer container = null)
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

            WantFacts(
                CreateWantAction(
                    facts => wantFactAction(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>(), facts.GetFact<TFact4>(), facts.GetFact<TFact5>(), facts.GetFact<TFact6>(), facts.GetFact<TFact7>(), facts.GetFact<TFact8>(), facts.GetFact<TFact9>(), facts.GetFact<TFact10>(), facts.GetFact<TFact11>(), facts.GetFact<TFact12>(), facts.GetFact<TFact13>(), facts.GetFact<TFact14>()),
                    inputFacts),
                container);
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
        /// <param name="container">Fact container.</param>
        public virtual void WantFacts<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13, TFact14, TFact15>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13, TFact14, TFact15> wantFactAction, TFactContainer container = null)
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

            WantFacts(
                CreateWantAction(
                    facts => wantFactAction(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>(), facts.GetFact<TFact4>(), facts.GetFact<TFact5>(), facts.GetFact<TFact6>(), facts.GetFact<TFact7>(), facts.GetFact<TFact8>(), facts.GetFact<TFact9>(), facts.GetFact<TFact10>(), facts.GetFact<TFact11>(), facts.GetFact<TFact12>(), facts.GetFact<TFact13>(), facts.GetFact<TFact14>(), facts.GetFact<TFact15>()),
                    inputFacts),
                container);
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
        /// <param name="container">Fact container.</param>
        public virtual void WantFacts<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13, TFact14, TFact15, TFact16>(
            Action<TFact1, TFact2, TFact3, TFact4, TFact5, TFact6, TFact7, TFact8, TFact9, TFact10, TFact11, TFact12, TFact13, TFact14, TFact15, TFact16> wantFactAction, TFactContainer container = null)
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

            WantFacts(
                CreateWantAction(
                    facts => wantFactAction(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>(), facts.GetFact<TFact4>(), facts.GetFact<TFact5>(), facts.GetFact<TFact6>(), facts.GetFact<TFact7>(), facts.GetFact<TFact8>(), facts.GetFact<TFact9>(), facts.GetFact<TFact10>(), facts.GetFact<TFact11>(), facts.GetFact<TFact12>(), facts.GetFact<TFact13>(), facts.GetFact<TFact14>(), facts.GetFact<TFact15>(), facts.GetFact<TFact16>()),
                    inputFacts),
                container);
        }

        #endregion
    }
}
