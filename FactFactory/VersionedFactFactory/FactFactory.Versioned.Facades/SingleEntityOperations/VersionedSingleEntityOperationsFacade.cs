using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations.Entities;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using GetcuReone.FactFactory.Priority;
using GetcuReone.FactFactory.Priority.Facades.SingleEntityOperations;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations
{
    /// <inheritdoc/>
    public class VersionedSingleEntityOperationsFacade : PrioritySingleEntityOperationsFacade
    {
        /// <inheritdoc/>
        public override int CompareFactRules<TFactRule, TWantAction, TFactContainer>(TFactRule x, TFactRule y, IWantActionContext<TWantAction, TFactContainer> context)
        {
            int resultByPriority = x.CompareByPriority(y, context);
            if (resultByPriority != 0)
                return resultByPriority;

            int resultByVersion = x.CompareByVersion(y, context);
            if (resultByVersion != 0)
                return resultByVersion;

            return x.CompareTo(y);
        }

        /// <inheritdoc/>
        public override IEnumerable<TFactRule> GetCompatibleRules<TFactWork, TFactRule, TWantAction, TFactContainer>(TFactWork target, IEnumerable<TFactRule> factRules, IWantActionContext<TWantAction, TFactContainer> context)
        {
            var result = base.GetCompatibleRules(target, factRules, context);
            var maxVersion = context.WantAction.InputFactTypes.GetVersionFact(context);

            if (maxVersion == null)
                return result;

            return result.Where(rule => rule.CompatibleRule(maxVersion, context));
        }

        /// <inheritdoc/>
        public override bool CompatibleRule<TFactWork, TFactRule, TWantAction, TFactContainer>(TFactWork target, TFactRule rule, IWantActionContext<TWantAction, TFactContainer> context)
        {
            if (!base.CompatibleRule(target, rule, context))
                return false;

            var maxVersion = context.WantAction.InputFactTypes.GetVersionFact(context);

            if (maxVersion == null)
                return true;

            var ruleVersion = rule.InputFactTypes.GetVersionFact(context);

            return ruleVersion != null
                ? maxVersion.CompareTo(ruleVersion) >= 0
                : false;
        }

        /// <inheritdoc/>
        public override bool CanExtractFact<TFactWork, TWantAction, TFactContainer>(IFactType factType, TFactWork factWork, IWantActionContext<TWantAction, TFactContainer> context)
        {
            if (factType.IsFactType<ISpecialFact>())
                return base.CanExtractFact(factType, factWork, context);

            List<IFact> facts = context.GetFactsFromContainerByFactType(factType).ToList();

            if (facts.Count == 0)
                return false;

            var maxVersion = context.WantAction.InputFactTypes.GetVersionFact(context);

            if (maxVersion == null)
                return true;

            return facts.Exists(fact => fact.IsCompatibleWithVersion(maxVersion));
        }

        /// <inheritdoc/>
        public override IEnumerable<IFactType> GetRequiredTypesOfFacts<TFactWork, TWantAction, TFactContainer>(TFactWork factWork, IWantActionContext<TWantAction, TFactContainer> context)
        {
            var maxVersion = context.WantAction.InputFactTypes.GetVersionFact(context);

            return factWork.InputFactTypes.Where(factType =>
                context.GetFactsFromContainerByFactType(factType).All(fact => !fact.IsCompatibleWithVersion(maxVersion)));
        }

        /// <inheritdoc/>
        protected override IEnumerable<IFact> GetRequireFacts<TFactWork, TWantAction, TFactContainer>(TFactWork factWork, IWantActionContext<TWantAction, TFactContainer> context)
        {
            var maxVersion = context.WantAction.InputFactTypes.GetVersionFact(context);

            if (maxVersion == null)
                return base.GetRequireFacts(factWork, context);

            return context
                .GetFactsFromContainerByFactTypes(factWork.InputFactTypes)
                .Where(fact => fact.IsCompatibleWithVersion(maxVersion))
                .OrderByDescending(fact => fact, Comparer<IFact>.Create(CompareFacts))
                .ToList();
        }

        /// <inheritdoc/>
        public override int CompareFacts(IFact x, IFact y)
        {
            int result = x.CompareTo(y);
            if (result != 0)
                return result;

            result = x.CompareByPriority(y);
            if (result != 0)
                return result;

            return x.CompareByVersion(y);
        }

        /// <inheritdoc/>
        public override bool TryCalculateFact<TFactRule, TWantAction, TFactContainer>(NodeByFactRule<TFactRule> node, IWantActionContext<TWantAction, TFactContainer> context, out IFact fact)
        {
            var result = base.TryCalculateFact(node, context, out fact);

            if (result)
            {
                var version = node.Info.Rule.InputFactTypes.GetVersionFact(context);
                if (version != null)
                    fact.SetVersion(version);
            }

            return result;
        }

        /// <inheritdoc/>
        protected override bool NeedRecalculateFact<TFactRule, TWantAction, TFactContainer>(NodeByFactRule<TFactRule> node, IWantActionContext<TWantAction, TFactContainer> context)
        {
            var maxVersion = context.WantAction.InputFactTypes.GetVersionFact(context);

            if (maxVersion == null)
                return false;

            return context
                .GetFactsFromContainerByFactType(node.Info.Rule.OutputFactType)
                .Any(fact => !fact.IsCompatibleWithVersion(maxVersion));
        }
    }
}
