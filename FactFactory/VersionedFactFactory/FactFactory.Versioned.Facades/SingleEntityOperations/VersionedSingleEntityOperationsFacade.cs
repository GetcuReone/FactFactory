using GetcuReone.FactFactory.Facades.SingleEntityOperations;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations.Entities;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using GetcuReone.FactFactory.Versioned.Constants;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations
{
    /// <inheritdoc/>
    public class VersionedSingleEntityOperationsFacade : SingleEntityOperationsFacade
    {
        /// <inheritdoc/>
        public override int CompareFactRules<TFactRule, TWantAction, TFactContainer>(TFactRule x, TFactRule y, IWantActionContext<TWantAction, TFactContainer> context)
        {
            int resultByVersion = x.CompareByVersion(y, context);
            if (resultByVersion != 0)
                return resultByVersion;

            return base.CompareFactRules(x, y, context);
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

        /// <summary>
        /// Comparison of facts.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        protected virtual int CompareFacts(IFact x, IFact y)
        {
            if (x.IsCalculatedByRule())
            {
                if (!y.IsCalculatedByRule())
                    return 1;
            }
            else if (y.IsCalculatedByRule())
                return -1;

            var xVersion = x.GetParameter(VersionedFactParametersCodes.Version)?.Value as IVersionFact;
            var yVersion = y.GetParameter(VersionedFactParametersCodes.Version)?.Value as IVersionFact;

            if (xVersion == null)
                return yVersion == null ? 0 : 1;
            if (yVersion == null)
                return -1;

            return xVersion.CompareTo(yVersion);
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
        protected override bool NeedRecalculateFact<TFactRule, TWantAction, TFactContainer>(TFactRule rule, IWantActionContext<TWantAction, TFactContainer> context)
        {
            var maxVersion = context.WantAction.InputFactTypes.GetVersionFact(context);

            if (maxVersion == null)
                return false;

            return context
                .GetFactsFromContainerByFactType(rule.OutputFactType)
                .Any(fact => !fact.IsCompatibleWithVersion(maxVersion));
        }
    }
}
