using GetcuReone.ComboPatterns.Facade;
using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.BaseEntities.Context;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Interfaces.Operations.Entities;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonHelper = GetcuReone.FactFactory.FactFactoryHelper;

namespace GetcuReone.FactFactory.Facades.SingleEntityOperations
{
    /// <summary>
    /// Single operations on entities of the FactFactory.
    /// </summary>
    public class SingleEntityOperationsFacade : FacadeBase, ISingleEntityOperations
    {
        /// <inheritdoc/>
        public virtual IComparer<TFactRule> GetRuleComparer<TFactRule, TWantAction, TFactContainer>(IWantActionContext<TWantAction, TFactContainer> context)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            return Comparer<TFactRule>.Create(
                (x, y) => CompareFactRules(x, y, context));
        }

        /// <summary>
        /// Compare <see cref="IFactRule"/>.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual int CompareFactRules<TFactRule, TWantAction, TFactContainer>(TFactRule x, TFactRule y, IWantActionContext<TWantAction, TFactContainer> context)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            return x.CompareTo(y);
        }

        /// <inheritdoc/>
        public virtual void ValidateContainer<TFactContainer>(TFactContainer container) 
            where TFactContainer : IFactContainer
        {
            if (container == null)
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidData, "Container cannot be null.");
            if (container.Any(fact => fact is IBuildConditionFact))
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidData, $"Container contains {nameof(IBuildConditionFact)} facts.");
            if (container.Any(fact => fact is IRuntimeConditionFact))
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidData, $"Container contains {nameof(IRuntimeConditionFact)} facts.");

            IEqualityComparer<IFact> comparer = container.EqualityComparer ?? FactEqualityComparer.GetDefault();

            foreach(var fact in container)
            {
                if (container.Count(f => comparer.Equals(f, fact)) != 1)
                    throw CommonHelper.CreateDeriveException(ErrorCode.InvalidData, $"Using the IEqualityComparer<IFact>, the '{fact.GetFactType().FactName}' fact was not found in the container or was found multiple times.");
            }
        }

        /// <inheritdoc/>
        public virtual TFactRuleCollection ValidateAndGetRules<TFactRule, TFactRuleCollection>(TFactRuleCollection ruleCollection)
            where TFactRule : IFactRule
            where TFactRuleCollection : IFactRuleCollection<TFactRule>
        {
            // Get a copy of the rules
            if (ruleCollection == null)
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidData, "Rules cannot be null.");

            IFactRuleCollection<TFactRule> rulesCopy = ruleCollection.Copy();
            if (rulesCopy == null)
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidData, "IFactRuleCollection.Copy method return null.");
            if (rulesCopy.Equals(ruleCollection))
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidData, "IFactRuleCollection.Copy method return original rule collection.");
            if (!(rulesCopy is TFactRuleCollection rules))
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidData, "IFactRuleCollection.Copy method returned a different type of rules.");

            rules.IsReadOnly = true;
            return rules;
        }

        /// <inheritdoc/>
        public virtual IFactRuleCollection<TFactRule> GetCompatibleRules<TFactWork, TFactRule, TWantAction, TFactContainer>(TFactWork target, IFactRuleCollection<TFactRule> factRules, IWantActionContext<TWantAction, TFactContainer> context)
            where TFactWork : IFactWork
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            return factRules;
        }

        /// <inheritdoc/>
        public virtual bool CompatibleRule<TFactWork, TFactRule, TWantAction, TFactContainer>(TFactWork target, TFactRule rule, IWantActionContext<TWantAction, TFactContainer> context)
            where TFactWork : IFactWork
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            return true;
        }

        /// <inheritdoc/>
        public virtual bool CanExtractFact<TFactWork, TWantAction, TFactContainer>(IFactType factType, TFactWork factWork, IWantActionContext<TWantAction, TFactContainer> context)
            where TFactWork : IFactWork
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            return context.Container.Any(fact => context.Cache.GetFactType(fact).EqualsFactType(factType));
        }

        /// <inheritdoc/>
        public virtual IEnumerable<IFactType> GetRequiredTypesOfFacts<TFactWork, TWantAction, TFactContainer>(TFactWork factWork, IWantActionContext<TWantAction, TFactContainer> context)
            where TFactWork : IFactWork
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            return factWork.InputFactTypes.Where(factType => !context.SingleEntity.CanExtractFact(factType, factWork, context));
        }

        /// <summary>
        /// Get the facts needed to enter the work.
        /// </summary>
        /// <typeparam name="TFactWork"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="factWork"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        protected virtual IEnumerable<IFact> GetRequireFacts<TFactWork, TWantAction, TFactContainer>(TFactWork factWork, IWantActionContext<TWantAction, TFactContainer> context)
            where TFactWork : IFactWork
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            return context.Container
                .Where(fact => factWork.InputFactTypes
                    .Any(inputType => context.Cache.GetFactType(fact).EqualsFactType(inputType)))
                .OrderByDescending(fact => fact, Comparer<IFact>.Create(CompareFacts))
                .ToList();
        }

        /// <inheritdoc/>
        public virtual bool NeedCalculateFact<TFactRule, TWantAction, TFactContainer>(NodeByFactRule<TFactRule> node, IWantActionContext<TWantAction, TFactContainer> context)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            return node.Parent != null
                ? !CanExtractFact(node.Info.Rule.OutputFactType, node.Parent.Info.Rule, context)
                : !CanExtractFact(node.Info.Rule.OutputFactType, context.WantAction, context);
        }

        /// <inheritdoc/>
        public virtual IFact CalculateFact<TFactRule, TWantAction, TFactContainer>(NodeByFactRule<TFactRule> node, IWantActionContext<TWantAction, TFactContainer> context)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            (var rule, var buildSuccessConditions, var runtimeConditions) = 
                (node.Info.Rule, node.Info.BuildSuccessConditions, node.Info.RuntimeConditions);

            foreach (IRuntimeConditionFact condition in runtimeConditions)
                if (TryCalculateFactByRuntimeCondition(rule, condition, context, out IFact resultFact))
                    return resultFact;

            using var writer = context.Container.GetWriter();

            buildSuccessConditions.ForEach(writer.Add);
            runtimeConditions.ForEach(writer.Add);

            var requiredFacts = GetRequireFacts(rule, context);
            if (!CanInvokeWork(requiredFacts, rule, context.Cache))
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidOperation, $"Can't calculate the '{rule}' rule.", context.WantAction, context.Container);

            var fact = Factory.CreateObject(
                facts => rule.Calculate(facts),
                requiredFacts);

            fact.SetCalculateByRule();
            context.WantAction.AddUsedRule(rule);

            buildSuccessConditions.ForEach(writer.Remove);
            runtimeConditions.ForEach(writer.Remove);

            return fact;
        }

        /// <inheritdoc/>
        public virtual async ValueTask<IFact> CalculateFactAsync<TFactRule, TWantAction, TFactContainer>(NodeByFactRule<TFactRule> node, IWantActionContext<TWantAction, TFactContainer> context)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            var rule = node.Info.Rule;

            foreach (var condition in node.Info.BuildSuccessConditions)
                using (var writer = context.Container.GetWriter())
                    writer.Add(condition);

            var requiredFacts = GetRequireFacts(rule, context);
            if (!CanInvokeWork(requiredFacts, rule, context.Cache))
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidOperation, $"Can't calculate the '{rule}' rule.", context.WantAction, context.Container);

            IFact fact = await Factory
                .CreateObject(facts => rule.CalculateAsync(facts), requiredFacts)
                .ConfigureAwait(false);

            fact.SetCalculateByRule();
            context.WantAction.AddUsedRule(rule);

            foreach (var condition in node.Info.BuildSuccessConditions)
                using (var writer = context.Container.GetWriter())
                    writer.Remove(condition);

            return fact;
        }

        /// <inheritdoc/>
        public virtual void DeriveWantFacts<TWantAction, TFactContainer>(WantActionInfo<TWantAction, TFactContainer> wantActionInfo)
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            (var context, var wantAction, var buildSuccessConditions, var runtimeConditions) =
                (wantActionInfo.Context, wantActionInfo.Context.WantAction, wantActionInfo.BuildSuccessConditions, wantActionInfo.RuntimeConditions);

            foreach (var condition in runtimeConditions)
                if (!RuntimeCondition(condition, context))
                    throw CommonHelper.CreateDeriveException(
                        ErrorCode.RuntimeCondition,
                        $"Failed to meet {context.Cache.GetFactType(condition).FactName} for {wantAction} and find another solution.");

            using var writer = context.Container.GetWriter();

            buildSuccessConditions.ForEach(writer.Add);
            runtimeConditions.ForEach(writer.Add);

            var requiredFacts = GetRequireFacts(context.WantAction, context);
            if (!CanInvokeWork(requiredFacts, context.WantAction, context.Cache))
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidOperation, $"Can't invoke the '{context.WantAction}' action.", context.WantAction, context.Container);

            context.WantAction.Invoke(requiredFacts);

            buildSuccessConditions.ForEach(writer.Remove);
            runtimeConditions.ForEach(writer.Remove);
        }

        /// <summary>
        /// Comparison of facts.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public virtual int CompareFacts(IFact x, IFact y)
        {
            return x.CompareTo(y);
        }

        /// <inheritdoc/>
        public virtual async ValueTask DeriveWantFactsAsync<TWantAction, TFactContainer>(WantActionInfo<TWantAction, TFactContainer> wantActionInfo)
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            var context = wantActionInfo.Context;

            foreach (var condition in wantActionInfo.BuildSuccessConditions)
                using (var writer = context.Container.GetWriter())
                    writer.Add(condition);

            var requiredFacts = GetRequireFacts(context.WantAction, context);
            if (!CanInvokeWork(requiredFacts, context.WantAction, context.Cache))
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidOperation, $"Can't invoke the '{context.WantAction}' action.", context.WantAction, context.Container);

            await context.WantAction.InvokeAsync(requiredFacts).ConfigureAwait(false);

            foreach (var condition in wantActionInfo.BuildSuccessConditions)
                using (var writer = context.Container.GetWriter())
                    writer.Remove(condition);
        }

        /// <summary>
        /// Is it possible to start a <see cref="IFactWork"/>.
        /// </summary>
        /// <typeparam name="TFactWork"></typeparam>
        /// <param name="inputFacts">Input facts.</param>
        /// <param name="factWork"></param>
        /// <param name="cache"></param>
        /// <returns></returns>
        public virtual bool CanInvokeWork<TFactWork>(IEnumerable<IFact> inputFacts, TFactWork factWork, IFactTypeCache cache)
            where TFactWork : IFactWork
        {
            foreach(IFactType requiredFactType in factWork.InputFactTypes)
            {
                if (inputFacts.All(inputFact => !cache.GetFactType(inputFact).EqualsFactType(requiredFactType)))
                    return false;
            }

            return true;
        }

        /// <inheritdoc/>
        public virtual IEqualityComparer<IFact> GetFactEqualityComparer<TWantAction, TFactContainer>(IWantActionContext<TWantAction, TFactContainer> context)
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            return new FactEqualityComparer((first, second) => EqualsFacts(first, second, context));
        }

        /// <inheritdoc/>
        public virtual IComparer<IFact> GetFactComparer<TWantAction, TFactContainer>(IWantActionContext<TWantAction, TFactContainer> context)
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            return Comparer<IFact>.Create(CompareFacts);
        }

        /// <summary>
        /// Checking the equality of facts.
        /// </summary>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual bool EqualsFacts<TWantAction, TFactContainer>(IFact first, IFact second, IWantActionContext<TWantAction, TFactContainer> context)
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            if (first == null && second == null)
                return true;
            if (!FactEqualityComparer.EqualsFacts(first, second, cache: context.Cache, includeFactParams: false))
                return false;

            IReadOnlyCollection<IFactParameter> firstParameters = first.GetParameters();
            IReadOnlyCollection<IFactParameter> secondParameters = second.GetParameters();

            if (firstParameters.IsNullOrEmpty() && secondParameters.IsNullOrEmpty())
                return true;
            if (firstParameters.IsNullOrEmpty() || secondParameters.IsNullOrEmpty())
                return false;
            if (firstParameters.Count != secondParameters.Count)
                return false;

            foreach (IFactParameter xParameter in firstParameters)
            {
                bool found = false;

                foreach (IFactParameter yParameter in secondParameters)
                {
                    if (EqualsFactParameters(xParameter, yParameter, context))
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Checking the equality of fact parameters.
        /// </summary>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual bool EqualsFactParameters<TWantAction, TFactContainer>(IFactParameter first, IFactParameter second, IWantActionContext<TWantAction, TFactContainer> context)
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            return FactEqualityComparer.EqualsFactParameters(first, second);
        }

        /// <inheritdoc/>
        public TWantAction CreateWantAction<TWantAction>(Action<IEnumerable<IFact>> wantAction, List<IFactType> factTypes, FactWorkOption option) where TWantAction : IWantAction
        {
            var result = new WantAction(wantAction, factTypes, option);

            if (result is TWantAction converted)
                return converted;

            throw CommonHelper.CreateException(
                ErrorCode.InvalidData,
                $"The result of the ISingleEntityOperations.CreateWantAction cannot be converted to the type {typeof(TWantAction).Name}.");
        }

        /// <inheritdoc/>
        public TWantAction CreateWantAction<TWantAction>(Func<IEnumerable<IFact>, ValueTask> wantAction, List<IFactType> factTypes, FactWorkOption option) where TWantAction : IWantAction
        {
            var result = new WantAction(wantAction, factTypes, option);

            if (result is TWantAction converted)
                return converted;

            throw CommonHelper.CreateException(
                ErrorCode.InvalidData,
                $"The result of the ISingleEntityOperations.CreateWantAction cannot be converted to the type {typeof(TWantAction).Name}.");
        }

        /// <inheritdoc/>
        public virtual IFactType GetFactType<TFact>() where TFact : IFact
        {
            return new FactType<TFact>();
        }

        /// <summary>
        /// Try to calculate a fact based on a <paramref name="condition"/>.
        /// </summary>
        /// <typeparam name="TFactRule">Type rule.</typeparam>
        /// <typeparam name="TWantAction">Type wantAction.</typeparam>
        /// <typeparam name="TFactContainer">Type fact container.</typeparam>
        /// <param name="rule">Rule for which the condition is checked.</param>
        /// <param name="condition">Condition.</param>
        /// <param name="context">Context.</param>
        /// <param name="result">Calculated fact.</param>
        /// <returns>True - The <paramref name="condition"/> was not fulfilled and the fact had to be recalculated.</returns>
        private bool TryCalculateFactByRuntimeCondition<TFactRule, TWantAction, TFactContainer>(TFactRule rule, IRuntimeConditionFact condition, IWantActionContext<TWantAction, TFactContainer> context, out IFact result)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            result = default;
            (var wantAction, var container, var engine, var singleOperations, var treeOperations, var cache) =
                (context.WantAction, context.Container, context.Engine, context.SingleEntity, context.TreeBuilding, context.Cache);

            var rulesContext = new FactRulesContext<TFactRule, TWantAction, TFactContainer>
            {
                Cache = cache,
                Container = container,
                SingleEntity = singleOperations,
                TreeBuilding = treeOperations,
                WantAction = wantAction,
                Engine = engine,
            };

            if (condition.TryGetRelatedRulse(out IFactRuleCollection<TFactRule> rules))
            {
                rulesContext.FactRules = rules;

                if (condition.Condition(rule, rulesContext))
                    return false;

                IFact resultFact = null;
                var inputTypes = new List<IFactType>(wantAction.InputFactTypes.Where(t => t.IsFactType<ISpecialFact>()));
                inputTypes.Add(rule.OutputFactType);

                var wantContext = new WantActionContext<TWantAction, TFactContainer>
                {
                    Cache = cache,
                    Container = container,
                    Engine = engine,
                    SingleEntity = singleOperations,
                    TreeBuilding = treeOperations,
                    WantAction = singleOperations.CreateWantAction<TWantAction>(
                        facts => { resultFact = facts.FirstFactByFactType(rule.OutputFactType, context.Cache); },
                        inputTypes,
                        wantAction.Option)
                };

                var requests = new List<DeriveWantActionRequest<TFactRule, IFactRuleCollection<TFactRule>, TWantAction, TFactContainer>>
                {
                    new DeriveWantActionRequest<TFactRule, IFactRuleCollection<TFactRule>, TWantAction, TFactContainer>
                    {
                        Rules = rules,
                        Context = wantContext
                    }
                };

                context.Engine.DeriveWantAction(requests);

                foreach (var usedRule in wantContext.WantAction.GetUsedRules())
                    wantAction.AddUsedRule(usedRule);

                using var rWriter = context.Container.GetWriter();
                rWriter.Remove(resultFact);

                result = resultFact;
                return true;
            }
            else if (!condition.Condition(rule, rulesContext))
            {
                throw CommonHelper.CreateDeriveException(
                    ErrorCode.RuntimeCondition,
                    $"Failed to meet {rulesContext.Cache.GetFactType(condition).FactName} for {rule} and find another solution.");
            }

            return false;
        }

        /// <summary>
        /// Checks for a <paramref name="condition"/>
        /// </summary>
        /// <typeparam name="TWantAction">Type wantAction.</typeparam>
        /// <typeparam name="TFactContainer">Type fact container.</typeparam>
        /// <param name="condition">Condition.</param>
        /// <param name="context">Context.</param>
        /// <returns>Result <see cref="IRuntimeConditionFact.Condition{TFactWork, TFactRule, TWantAction, TFactContainer}(TFactWork, IFactRulesContext{TFactRule, TWantAction, TFactContainer})"/>.</returns>
        private bool RuntimeCondition<TWantAction, TFactContainer>(IRuntimeConditionFact condition, IWantActionContext<TWantAction, TFactContainer> context)
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            var wantAction = context.WantAction;
            var rulesContext = new FactRulesContext<IFactRule, TWantAction, TFactContainer>
            {
                Cache = context.Cache,
                Container = context.Container,
                SingleEntity = context.SingleEntity,
                TreeBuilding = context.TreeBuilding,
                WantAction = wantAction,
                Engine = context.Engine,
            };

            return condition.Condition(wantAction, rulesContext);
        }
    }
}
