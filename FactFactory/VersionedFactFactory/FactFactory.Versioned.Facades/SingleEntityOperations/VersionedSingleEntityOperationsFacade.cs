using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations.Entities;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using GetcuReone.FactFactory.Priority;
using GetcuReone.FactFactory.Priority.Facades.SingleEntityOperations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            List<IFact> facts = context
                .Container
                .WhereFactsByFactType(factType, context.Cache)
                .ToList();

            if (facts.Count == 0)
                return false;

            var maxVersion = context.WantAction.InputFactTypes.GetVersionFact(context);

            if (maxVersion == null)
                return true;

            return facts.Exists(fact => fact.IsRelevantFactByVersioned(maxVersion));
        }

        /// <inheritdoc/>
        public override IEnumerable<IFactType> GetRequiredTypesOfFacts<TFactWork, TWantAction, TFactContainer>(TFactWork factWork, IWantActionContext<TWantAction, TFactContainer> context)
        {
            var maxVersion = context.WantAction.InputFactTypes.GetVersionFact(context);

            return factWork.InputFactTypes.Where(factType => context
                .Container
                .WhereFactsByFactType(factType, context.Cache)
                .All(fact => !fact.IsRelevantFactByVersioned(maxVersion))
            );
        }

        /// <inheritdoc/>
        protected override IEnumerable<IFact> GetRequireFacts<TFactWork, TWantAction, TFactContainer>(TFactWork factWork, IWantActionContext<TWantAction, TFactContainer> context)
        {
            var maxVersion = context.WantAction.InputFactTypes.GetVersionFact(context);

            if (maxVersion == null)
                return base.GetRequireFacts(factWork, context);

            return context
                .Container
                .WhereFactsByFactTypes(factWork.InputFactTypes, context.Cache)
                .Where(fact => fact.IsRelevantFactByVersioned(maxVersion))
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
        public override IFact CalculateFact<TFactRule, TWantAction, TFactContainer>(NodeByFactRule<TFactRule> node, IWantActionContext<TWantAction, TFactContainer> context)
        {
            var version = node.Info.Rule.InputFactTypes.GetVersionFact(context);
            return base.CalculateFact(node, context).SetVersion(version);
        }

        /// <inheritdoc/>
        public override async ValueTask<IFact> CalculateFactAsync<TFactRule, TWantAction, TFactContainer>(NodeByFactRule<TFactRule> node, IWantActionContext<TWantAction, TFactContainer> context)
        {
            var version = node.Info.Rule.InputFactTypes.GetVersionFact(context);
            return (await base.CalculateFactAsync(node, context).ConfigureAwait(false)).SetVersion(version);
        }
    }
}
