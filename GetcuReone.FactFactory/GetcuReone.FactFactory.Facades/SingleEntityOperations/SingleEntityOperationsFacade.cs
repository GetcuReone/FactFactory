﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.BaseEntities.Context;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Extensions;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Interfaces.Operations.Entities;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using CommonHelper = GetcuReone.FactFactory.FactFactoryHelper;

namespace GetcuReone.FactFactory.Facades.SingleEntityOperations
{
    /// <summary>
    /// Single operations on entities of the FactFactory.
    /// </summary>
    public class SingleEntityOperationsFacade : ISingleEntityOperations
    {
        /// <inheritdoc/>
        public virtual IComparer<IFactRule> GetRuleComparer(IWantActionContext context)
        {
            return Comparer<IFactRule>.Create(
                (x, y) => CompareFactRules(x, y, context));
        }

        /// <summary>
        /// Compare <see cref="IFactRule"/>.
        /// </summary>
        /// <param name="firstRule"></param>
        /// <param name="secondRule"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual int CompareFactRules(IFactRule firstRule, IFactRule secondRule, IWantActionContext context)
        {
            return firstRule.CompareTo(secondRule);
        }

        /// <inheritdoc/>
        public virtual void ValidateContainer(IFactContainer container)
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
                var countFoundFact = container.Count(f => comparer.Equals(f, fact));

                if (countFoundFact < 1)
                    throw CommonHelper.CreateDeriveException(
                        ErrorCode.InvalidData,
                        $"Using the IEqualityComparer<IFact>, the '{fact.GetFactType().FactName}' fact was not found in the container.");

                if (countFoundFact > 1)
                    throw CommonHelper.CreateDeriveException(
                        ErrorCode.InvalidData,
                        $"Using the IEqualityComparer<IFact>, the '{fact.GetFactType().FactName}' fact was found multiple times in the container.");
            }
        }

        /// <inheritdoc/>
        public virtual IFactRuleCollection ValidateAndGetRules(IFactRuleCollection ruleCollection)
        {
            // Get a copy of the rules
            if (ruleCollection == null)
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidData, "Rules cannot be null.");

            IFactRuleCollection rulesCopy = ruleCollection.Copy();

            if (rulesCopy == null)
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidData, "IFactRuleCollection.Copy method return null.");

            if (rulesCopy.Equals(ruleCollection))
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidData, "IFactRuleCollection.Copy method return original rule collection.");
            
            rulesCopy.IsReadOnly = true;

            return rulesCopy;
        }

        /// <inheritdoc/>
        public virtual IFactRuleCollection GetCompatibleRules(
            IFactWork target,
            IFactRuleCollection factRules,
            IWantActionContext context)
        {
            return factRules;
        }

        /// <inheritdoc/>
        public virtual bool CompatibleRule(
            IFactWork target,
            IFactRule rule,
            IWantActionContext context)
        {
            return true;
        }

        /// <inheritdoc/>
        public virtual bool CanExtractFact(
            IFactType factType,
            IFactWork factWork,
            IWantActionContext context)
        {
            return context.Container.Any(fact => context.Cache.GetFactType(fact).EqualsFactType(factType));
        }

        /// <inheritdoc/>
        public virtual IEnumerable<IFactType> GetRequiredTypesOfFacts(IFactWork factWork, IWantActionContext context)
        {
            return factWork.InputFactTypes.Where(factType => !context.SingleEntity.CanExtractFact(factType, factWork, context));
        }

        /// <summary>
        /// Get the facts needed to enter the work.
        /// </summary>
        /// <param name="factWork"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        protected virtual IEnumerable<IFact> GetRequireFacts(IFactWork factWork, IWantActionContext context)
        {
            return context.Container
                .Where(fact => factWork.InputFactTypes
                    .Any(inputType => context.Cache.GetFactType(fact).EqualsFactType(inputType)))
                .OrderByDescending(fact => fact, Comparer<IFact>.Create(CompareFacts))
                .ToList();
        }

        /// <inheritdoc/>
        public virtual bool NeedCalculateFact(NodeByFactRule node, IWantActionContext context)
        {
            return node.Parent != null
                ? !CanExtractFact(node.Info.Rule.OutputFactType, node.Parent.Info.Rule, context)
                : !CanExtractFact(node.Info.Rule.OutputFactType, context.WantAction, context);
        }

        /// <inheritdoc/>
        public virtual IFact CalculateFact(NodeByFactRule node, IWantActionContext context)
        {
            (var rule, var buildSuccessConditions, var runtimeConditions) = 
                (node.Info.Rule, node.Info.BuildSuccessConditions, node.Info.RuntimeConditions);

            foreach (IRuntimeConditionFact condition in runtimeConditions)
            {
                (bool calculated, IFact result) = TryCalculateFactByRuntimeCondition(rule, condition, context);

                if (calculated)
                    return result;
            }

            using (var writer = context.Container.GetWriter())
            {
                buildSuccessConditions.ForEach(writer.Add);
                runtimeConditions.ForEach(writer.Add); 
            }

            var requiredFacts = GetRequireFacts(rule, context);
            if (!CanInvokeWork(requiredFacts, rule, context.Cache))
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidOperation, $"Can't calculate the '{rule}' rule.", context.WantAction, context.Container);

            var fact = rule.Calculate(requiredFacts);

            fact.SetCalculateByRule(context.ParameterCache);
            context.WantAction.AddUsedRule(rule);

            using (var writer = context.Container.GetWriter())
            {
                buildSuccessConditions.ForEach(writer.Remove);
                runtimeConditions.ForEach(writer.Remove); 
            }

            return fact;
        }

        /// <inheritdoc/>
        public virtual async ValueTask<IFact> CalculateFactAsync(NodeByFactRule node, IWantActionContext context)
        {
            (var rule, var buildSuccessConditions, var runtimeConditions) =
                (node.Info.Rule, node.Info.BuildSuccessConditions, node.Info.RuntimeConditions);

            foreach (IRuntimeConditionFact condition in runtimeConditions)
            {
                (bool calculated, IFact result) = await TryCalculateFactByRuntimeConditionAsync(rule, condition, context);

                if (calculated)
                    return result;
            }

            using (var writer = context.Container.GetWriter())
            {
                buildSuccessConditions.ForEach(writer.Add);
                runtimeConditions.ForEach(writer.Add); 
            }

            var requiredFacts = GetRequireFacts(rule, context);
            if (!CanInvokeWork(requiredFacts, rule, context.Cache))
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidOperation, $"Can't calculate the '{rule}' rule.", context.WantAction, context.Container);

            IFact fact = await rule.CalculateAsync(requiredFacts)
                .ConfigureAwait(false);

            fact.SetCalculateByRule(context.ParameterCache);
            context.WantAction.AddUsedRule(rule);

            using (var writer = context.Container.GetWriter())
            {
                buildSuccessConditions.ForEach(writer.Remove);
                runtimeConditions.ForEach(writer.Remove); 
            }

            return fact;
        }

        /// <inheritdoc/>
        public virtual void DeriveWantFacts(WantActionInfo wantActionInfo)
        {
            (var context, var wantAction, var buildSuccessConditions, var runtimeConditions) =
                (wantActionInfo.Context, wantActionInfo.Context.WantAction, wantActionInfo.BuildSuccessConditions, wantActionInfo.RuntimeConditions);

            foreach (var condition in runtimeConditions)
                if (!RuntimeCondition(condition, context))
                    throw CommonHelper.CreateDeriveException(
                        ErrorCode.RuntimeCondition,
                        $"Failed to meet {context.Cache.GetFactType(condition).FactName} for {wantAction} and find another solution.");

            using (var writer = context.Container.GetWriter())
            {
                buildSuccessConditions.ForEach(writer.Add);
                runtimeConditions.ForEach(writer.Add);
            }

            var requiredFacts = GetRequireFacts(context.WantAction, context);
            if (!CanInvokeWork(requiredFacts, context.WantAction, context.Cache))
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidOperation, $"Can't invoke the '{context.WantAction}' action.", context.WantAction, context.Container);

            context.WantAction.Invoke(requiredFacts);

            using (var writer = context.Container.GetWriter())
            {
                buildSuccessConditions.ForEach(writer.Remove);
                runtimeConditions.ForEach(writer.Remove); 
            }
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
        public virtual async ValueTask DeriveWantFactsAsync(WantActionInfo wantActionInfo)
        {
            (var context, var wantAction, var buildSuccessConditions, var runtimeConditions) =
                (wantActionInfo.Context, wantActionInfo.Context.WantAction, wantActionInfo.BuildSuccessConditions, wantActionInfo.RuntimeConditions);

            foreach (IRuntimeConditionFact condition in runtimeConditions)
                if (!RuntimeCondition(condition, context))
                    throw CommonHelper.CreateDeriveException(
                        ErrorCode.RuntimeCondition,
                        $"Failed to meet {context.Cache.GetFactType(condition).FactName} for {wantAction} and find another solution.");

            using (var writer = context.Container.GetWriter())
            {
                buildSuccessConditions.ForEach(writer.Add);
                runtimeConditions.ForEach(writer.Add); 
            }

            var requiredFacts = GetRequireFacts(context.WantAction, context);
            if (!CanInvokeWork(requiredFacts, context.WantAction, context.Cache))
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidOperation, $"Can't invoke the '{context.WantAction}' action.", context.WantAction, context.Container);

            await context.WantAction.InvokeAsync(requiredFacts).ConfigureAwait(false);

            using (var writer = context.Container.GetWriter())
            {
                buildSuccessConditions.ForEach(writer.Remove);
                runtimeConditions.ForEach(writer.Remove); 
            }
        }

        /// <summary>
        /// Is it possible to start a <see cref="IFactWork"/>.
        /// </summary>
        /// <param name="inputFacts">Input facts.</param>
        /// <param name="factWork"></param>
        /// <param name="cache"></param>
        /// <returns></returns>
        public virtual bool CanInvokeWork(IEnumerable<IFact> inputFacts, IFactWork factWork, IFactTypeCache cache)
        {
            foreach(IFactType requiredFactType in factWork.InputFactTypes)
            {
                if (inputFacts.All(inputFact => !cache.GetFactType(inputFact).EqualsFactType(requiredFactType)))
                    return false;
            }

            return true;
        }

        /// <inheritdoc/>
        public virtual IEqualityComparer<IFact> GetFactEqualityComparer(IWantActionContext context)
        {
            return new FactEqualityComparer((first, second) => EqualsFacts(first, second, context));
        }

        /// <inheritdoc/>
        public virtual IComparer<IFact> GetFactComparer(IWantActionContext context)
        {
            return Comparer<IFact>.Create(CompareFacts);
        }

        /// <summary>
        /// Checking the equality of facts.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual bool EqualsFacts(IFact? first, IFact? second, IWantActionContext context)
        {
            if (first == null && second == null)
                return true;

            if (!FactEqualityComparer.EqualsFacts(first, second, cache: context.Cache, includeFactParams: false))
                return false;

            IReadOnlyCollection<IFactParameter> firstParameters = first!.GetParameters();
            IReadOnlyCollection<IFactParameter> secondParameters = second!.GetParameters();

            if (firstParameters.IsNullOrEmpty())
                return secondParameters.IsNullOrEmpty();
            else if (secondParameters.IsNullOrEmpty())
                return false;
            else if (firstParameters!.Count != secondParameters!.Count)
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
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual bool EqualsFactParameters(
            IFactParameter first,
            IFactParameter second,
            IWantActionContext context)
        {
            return FactEqualityComparer.EqualsFactParameters(first, second);
        }

        /// <inheritdoc/>
        public IWantAction CreateWantAction(Action<IEnumerable<IFact>> wantAction, List<IFactType> factTypes, FactWorkOption option)
        {
            return new WantAction(wantAction, factTypes, option);
        }

        /// <inheritdoc/>
        public IWantAction CreateWantAction(Func<IEnumerable<IFact>, ValueTask> wantAction, List<IFactType> factTypes, FactWorkOption option)
        {
            return new WantAction(wantAction, factTypes, option);
        }

        /// <inheritdoc/>
        public virtual IFactType GetFactType<TFact>() where TFact : IFact
        {
            return new FactType<TFact>();
        }

        /// <summary>
        /// Try to calculate a fact based on a <paramref name="condition"/>.
        /// </summary>
        /// <param name="rule">Rule for which the condition is checked.</param>
        /// <param name="condition">Condition.</param>
        /// <param name="context">Context.</param>
        /// <returns>True - The <paramref name="condition"/> was not fulfilled and the fact had to be recalculated.</returns>
        private (bool, IFact) TryCalculateFactByRuntimeCondition(
            IFactRule rule,
            IRuntimeConditionFact condition,
            IWantActionContext context)
        {
            (var wantAction, var container, var engine, var singleOperations, var treeOperations, var cache, var parameterCahce) =
                (context.WantAction, context.Container, context.Engine, context.SingleEntity, context.TreeBuilding, context.Cache, context.ParameterCache);

            var rulesContext = new FactRulesContext(
                cache,
                singleOperations,
                treeOperations,
                engine,
                parameterCahce,
                wantAction,
                container);

            if (condition.TryGetRelatedRules(context, out IFactRuleCollection? rules))
            {
                rulesContext.FactRules = rules;

                if (condition.Condition(rule, rulesContext))
                    return (false, default!);

                if (rules.Count == 0 || !rules.Any(r => r.OutputFactType.EqualsFactType(rule.OutputFactType)))
                    throw CommonHelper.CreateDeriveException(
                        ErrorCode.RuntimeCondition,
                        $"Failed to meet {rulesContext.Cache.GetFactType(condition).FactName} for {rule} and find another solution.");

                IFact resultFact = null!;
                var inputTypes = new List<IFactType>(wantAction.InputFactTypes.Where(t => t.IsFactType<ISpecialFact>()))
                {
                    rule.OutputFactType
                };

                IWantAction newAction = singleOperations.CreateWantAction(
                        facts => { resultFact = facts.FirstFactByFactType(rule.OutputFactType, context.Cache)!; },
                        inputTypes,
                        wantAction.Option);

                var wantContext = new WantActionContext(
                    cache,
                    singleOperations,
                    treeOperations,
                    engine,
                    parameterCahce,
                    newAction,
                    container);

                var requests = new List<DeriveWantActionRequest>
                {
                    new DeriveWantActionRequest(wantContext, rules),
                };

                context.Engine.DeriveWantAction(requests);

                foreach (var usedRule in wantContext.WantAction.GetUsedRules())
                    wantAction.AddUsedRule(usedRule);

                using var rWriter = context.Container.GetWriter();
                rWriter.Remove(resultFact);

                return (true, resultFact);
            }
            else if (!condition.Condition(rule, rulesContext))
            {
                throw CommonHelper.CreateDeriveException(
                    ErrorCode.RuntimeCondition,
                    $"Failed to meet {rulesContext.Cache.GetFactType(condition).FactName} for {rule} and find another solution.");
            }

            return (false, default!);
        }

        /// <summary>
        /// Try to calculate a fact based on a <paramref name="condition"/>.
        /// </summary>
        /// <param name="rule">Rule for which the condition is checked.</param>
        /// <param name="condition">Condition.</param>
        /// <param name="context">Context.</param>
        /// <returns>True - The <paramref name="condition"/> was not fulfilled and the fact had to be recalculated.</returns>
        private async ValueTask<(bool, IFact)> TryCalculateFactByRuntimeConditionAsync(
            IFactRule rule,
            IRuntimeConditionFact condition,
            IWantActionContext context)
        {
            (var wantAction, var container, var engine, var singleOperations, var treeOperations, var cache, var parameterCache) =
                (context.WantAction, context.Container, context.Engine, context.SingleEntity, context.TreeBuilding, context.Cache, context.ParameterCache);

            var rulesContext = new FactRulesContext(context);

            if (condition.TryGetRelatedRules(context, out IFactRuleCollection? rules))
            {
                rulesContext.FactRules = rules;

                if (condition.Condition(rule, rulesContext))
                    return (false, default!);

                if (rules.Count == 0 || !rules.Any(r => r.OutputFactType.EqualsFactType(rule.OutputFactType)))
                    throw CommonHelper.CreateDeriveException(
                        ErrorCode.RuntimeCondition,
                        $"Failed to meet {rulesContext.Cache.GetFactType(condition).FactName} for {rule} and find another solution.");

                IFact resultFact = null!;
                var inputTypes = new List<IFactType>(wantAction.InputFactTypes.Where(t => t.IsFactType<ISpecialFact>()))
                {
                    rule.OutputFactType
                };

                IWantAction newAction = singleOperations.CreateWantAction(
                        facts => { resultFact = facts.FirstFactByFactType(rule.OutputFactType, context.Cache)!; },
                        inputTypes,
                        wantAction.Option);

                var wantContext = new WantActionContext(
                    cache,
                    singleOperations,
                    treeOperations,
                    engine,
                    parameterCache,
                    newAction,
                    container);

                var requests = new List<DeriveWantActionRequest>
                {
                    new DeriveWantActionRequest(wantContext, rules),
                };

                await context.Engine.DeriveWantActionAsync(requests);

                foreach (var usedRule in wantContext.WantAction.GetUsedRules())
                    wantAction.AddUsedRule(usedRule);

                using var rWriter = context.Container.GetWriter();
                rWriter.Remove(resultFact);

                return (true, resultFact);
            }
            else if (!condition.Condition(rule, rulesContext))
            {
                throw CommonHelper.CreateDeriveException(
                    ErrorCode.RuntimeCondition,
                    $"Failed to meet {rulesContext.Cache.GetFactType(condition).FactName} for {rule} and find another solution.");
            }

            return (false, default!);
        }

        /// <summary>
        /// Checks for a <paramref name="condition"/>
        /// </summary>
        /// <param name="condition">Condition.</param>
        /// <param name="context">Context.</param>
        /// <returns>Result <see cref="IRuntimeConditionFact.Condition(IFactWork, IFactRulesContext)"/>.</returns>
        private bool RuntimeCondition(IRuntimeConditionFact condition, IWantActionContext context)
        {
            var wantAction = context.WantAction;
            var rulesContext = new FactRulesContext(context);

            return condition.Condition(wantAction, rulesContext);
        }
    }
}
