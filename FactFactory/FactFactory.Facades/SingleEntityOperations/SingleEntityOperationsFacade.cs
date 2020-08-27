using GetcuReone.ComboPatterns.Facade;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Interfaces.Operations.Entities;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System.Collections.Generic;
using System.Linq;
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
        public virtual TFactContainer ValidateAndGetContainer<TFactContainer>(TFactContainer container) 
            where TFactContainer : IFactContainer
        {
            if (container == null)
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidData, "Container cannot be null.");

            IFactContainer containerCopy = container.Copy();
            if (containerCopy == null)
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidData, "IFactContainer.Copy method return null.");
            if (container.Equals(containerCopy))
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidData, "IFactContainer.Copy method return original container.");
            if (!(containerCopy is TFactContainer container1))
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidData, "IFactContainer.Copy method returned a different type of container.");
            if (container1.Any(fact => fact is IConditionFact))
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidData, $"Container contains {nameof(IConditionFact)} facts.");

            container1.IsReadOnly = true;
            return container1;
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
        public virtual IEnumerable<TFactRule> GetCompatibleRules<TFactWork, TFactRule, TWantAction, TFactContainer>(TFactWork target, IEnumerable<TFactRule> factRules, IWantActionContext<TWantAction, TFactContainer> context)
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
            return factWork.InputFactTypes.Where(factType => !CanExtractFact(factType, factWork, context));
        }

        /// <inheritdoc/>
        public virtual bool TryCalculateFact<TFactRule, TWantAction, TFactContainer>(NodeByFactRule<TFactRule> node, IWantActionContext<TWantAction, TFactContainer> context, out IFact fact)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            fact = null;
            var rule = node.Info.Rule;
            if (context.Container.Any(f => context.Cache.GetFactType(f).EqualsFactType(rule.OutputFactType)))
            {
                if (!NeedRecalculateFact(rule, context))
                    return false;
            }

            foreach (var condition in node.Info.SuccessConditions)
                using (context.Container.CreateIgnoreReadOnlySpace())
                    context.Container.Add(condition);

            fact = Factory
                .CreateObject(
                    facts => rule.Calculate(facts),
                    GetRequireFacts(rule, context))
                .SetCalculateByRule();


            foreach (var condition in node.Info.SuccessConditions)
                using (context.Container.CreateIgnoreReadOnlySpace())
                    context.Container.Remove(condition);

            return true;
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

        /// <summary>
        /// Do I need to recalculate the fact.
        /// </summary>
        /// <typeparam name="TFactRule"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="rule"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        protected virtual bool NeedRecalculateFact<TFactRule, TWantAction, TFactContainer>(TFactRule rule, IWantActionContext<TWantAction, TFactContainer> context)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            return false;
        }

        /// <inheritdoc/>
        public virtual void DeriveWantFacts<TWantAction, TFactContainer>(WantActionInfo<TWantAction, TFactContainer> wantActionInfo)
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            var context = wantActionInfo.Context;

            foreach (var condition in wantActionInfo.SuccessConditions)
                using (context.Container.CreateIgnoreReadOnlySpace())
                    context.Container.Add(condition);

            context.WantAction.Invoke(GetRequireFacts(context.WantAction, context));

            foreach (var condition in wantActionInfo.SuccessConditions)
                using (context.Container.CreateIgnoreReadOnlySpace())
                    context.Container.Remove(condition);
        }

        /// <summary>
        /// Comparison of facts.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        protected virtual int CompareFacts(IFact x, IFact y)
        {
            return x.CompareTo(y);
        }
    }
}
