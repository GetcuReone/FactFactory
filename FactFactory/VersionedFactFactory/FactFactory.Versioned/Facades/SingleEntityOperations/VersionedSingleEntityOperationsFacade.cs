﻿using GetcuReone.FactFactory.Facades.SingleEntityOperations;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using GetcuReone.FactFactory.Versioned.Constants;
using GetcuReone.FactFactory.Versioned.Helpers;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations
{
    /// <inheritdoc/>
    public class VersionedSingleEntityOperationsFacade : SingleEntityOperationsFacade
    {
        /// <inheritdoc/>
        public override int CompareFactRules<TFactRule, TWantAction, TFactContainer>(TFactRule first, TFactRule second, IWantActionContext<TWantAction, TFactContainer> context)
        {
            int resultByVersion = CompareRulesByVersion(first, second, context);
            if (resultByVersion != 0)
                return resultByVersion;

            return base.CompareFactRules(first, second, context);
        }

        /// <summary>
        /// Compare rules by version.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual int CompareRulesByVersion<TFactRule, TWantAction, TFactContainer>(TFactRule x, TFactRule y, IWantActionContext<TWantAction, TFactContainer> context)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            var xVersionType = x.InputFactTypes?.SingleOrDefault(type => type.IsFactType<IVersionFact>());
            var yVersionType = y.InputFactTypes?.SingleOrDefault(type => type.IsFactType<IVersionFact>());

            if (xVersionType == null)
                return yVersionType == null ? 0 : 1;
            if (yVersionType == null)
                return -1;

            IVersionFact xVersion = context.Container.GetVersionFact(xVersionType);
            IVersionFact yVersion = context.Container.GetVersionFact(yVersionType);

            return xVersion.CompareTo(yVersion);
        }

        /// <inheritdoc/>
        public override IEnumerable<TFactRule> GetCompatibleRules<TFactWork, TFactRule, TWantAction, TFactContainer>(TFactWork target, IEnumerable<TFactRule> factRules, IWantActionContext<TWantAction, TFactContainer> context)
        {
            var result = base.GetCompatibleRules(target, factRules, context);
            var maxVersion = VersionedSingleEntityOperationsHelper.GetMinVersion(
                target.InputFactTypes.GetVersionFact(context),
                context.WantAction.InputFactTypes.GetVersionFact(context));

            if (maxVersion == null)
                return result;

            return result.Where(rule => rule.CompatibleRule(maxVersion, context));
        }

        /// <inheritdoc/>
        public override bool CompatibleRule<TFactWork, TFactRule, TWantAction, TFactContainer>(TFactWork target, TFactRule rule, IWantActionContext<TWantAction, TFactContainer> context)
        {
            if (!base.CompatibleRule(target, rule, context))
                return false;

            var maxVersion = VersionedSingleEntityOperationsHelper.GetMinVersion(
                target.InputFactTypes.GetVersionFact(context),
                context.WantAction.InputFactTypes.GetVersionFact(context));

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

            var maxVersion = VersionedSingleEntityOperationsHelper.GetMinVersion(
                factWork.InputFactTypes.GetVersionFact(context),
                context.WantAction.InputFactTypes.GetVersionFact(context));

            if (maxVersion == null)
                return true;

            return facts.Exists(fact => fact.IsCompatibleWithVersion(maxVersion));
        }

        /// <inheritdoc/>
        public override IEnumerable<IFactType> GetRequiredTypesOfFacts<TFactWork, TWantAction, TFactContainer>(TFactWork factWork, IWantActionContext<TWantAction, TFactContainer> context)
        {
            var maxVersion = VersionedSingleEntityOperationsHelper.GetMinVersion(
                factWork.InputFactTypes.GetVersionFact(context),
                context.WantAction.InputFactTypes.GetVersionFact(context));

            return factWork.InputFactTypes.Where(factType =>
                context.GetFactsFromContainerByFactType(factType).All(fact => !fact.IsCompatibleWithVersion(maxVersion)));
        }
    }
}
