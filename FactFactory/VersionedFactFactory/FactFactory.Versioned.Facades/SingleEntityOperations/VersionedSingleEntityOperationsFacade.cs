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
    /// <summary>
    /// Single operations on entities of the FactFactory. Sharpened for work with <see cref="Interfaces.IVersionFact"/>.
    /// </summary>
    public class VersionedSingleEntityOperationsFacade : PrioritySingleEntityOperationsFacade
    {
        /// <inheritdoc/>
        /// <remarks>Additionally checks version compatibility.</remarks>
        public override int CompareFactRules<TFactRule>(TFactRule x, TFactRule y, IWantActionContext context)
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
        /// <remarks>Additionally checks version compatibility.</remarks>
        public override IFactRuleCollection<TFactRule> GetCompatibleRules<TFactWork, TFactRule>(TFactWork target, IFactRuleCollection<TFactRule> factRules, IWantActionContext context)
        {
            var result = base.GetCompatibleRules(target, factRules, context);
            var maxVersion = context.WantAction.InputFactTypes.GetVersionFact(context);

            if (maxVersion == null)
                return result;

            return result.FindAll(rule => rule.CompatibleRule(maxVersion, context));
        }

        /// <inheritdoc/>
        /// <remarks>Additionally checks version compatibility.</remarks>
        public override bool CompatibleRule<TFactWork, TFactRule>(TFactWork target, TFactRule rule, IWantActionContext context)
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
        /// <remarks>Additionally checks version compatibility.</remarks>
        public override bool CanExtractFact<TFactWork>(IFactType factType, TFactWork factWork, IWantActionContext context)
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
        /// <remarks>Additionally checks version compatibility.</remarks>
        public override IEnumerable<IFactType> GetRequiredTypesOfFacts<TFactWork>(TFactWork factWork, IWantActionContext context)
        {
            var maxVersion = context.WantAction.InputFactTypes.GetVersionFact(context);

            return factWork.InputFactTypes.Where(factType => context
                .Container
                .WhereFactsByFactType(factType, context.Cache)
                .All(fact => !fact.IsRelevantFactByVersioned(maxVersion))
            );
        }

        /// <inheritdoc/>
        /// <remarks>Additionally checks version compatibility.</remarks>
        protected override IEnumerable<IFact> GetRequireFacts<TFactWork>(TFactWork factWork, IWantActionContext context)
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
        /// <remarks>Additionally checks version compatibility.</remarks>
        public override int CompareFacts(IFact x, IFact y)
        {
            int result = x.CompareTo(y);
            if (result != 0)
                return result;

            result = x.CompareByPriorityParameter(y);
            if (result != 0)
                return result;

            return x.CompareByVersionParameter(y);
        }

        /// <inheritdoc/>
        /// <remarks>Adds a versioned fact to the parameters of the calculated fact.</remarks>
        public override IFact CalculateFact<TFactRule>(NodeByFactRule<TFactRule> node, IWantActionContext context)
        {
            var version = node.Info.Rule.InputFactTypes.GetVersionFact(context);
            return base.CalculateFact(node, context).AddVerionParameter(version);
        }

        /// <inheritdoc/>
        /// <remarks>Adds a <see cref="Interfaces.IVersionFact"/> to the parameters of the calculated fact.</remarks>
        public override async ValueTask<IFact> CalculateFactAsync<TFactRule>(NodeByFactRule<TFactRule> node, IWantActionContext context)
        {
            var version = node.Info.Rule.InputFactTypes.GetVersionFact(context);
            return (await base.CalculateFactAsync(node, context).ConfigureAwait(false)).AddVerionParameter(version);
        }
    }
}
