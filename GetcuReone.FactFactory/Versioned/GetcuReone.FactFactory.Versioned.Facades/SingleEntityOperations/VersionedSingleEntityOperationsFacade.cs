﻿using GetcuReone.FactFactory.Extensions;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations.Entities;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using GetcuReone.FactFactory.Priority;
using GetcuReone.FactFactory.Priority.Common.Extensions;
using GetcuReone.FactFactory.Priority.Facades.SingleEntityOperations;
using GetcuReone.FactFactory.Versioned.Interfaces;
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
        public override int CompareFactRules(IFactRule firstRule, IFactRule secondRule, IWantActionContext context)
        {
            int resultByPriority = firstRule.CompareByPriority(secondRule, context);
            if (resultByPriority != 0)
                return resultByPriority;

            int resultByVersion = firstRule.CompareByVersion(secondRule, context);
            if (resultByVersion != 0)
                return resultByVersion;

            return firstRule.CompareTo(secondRule);
        }

        /// <inheritdoc/>
        /// <remarks>Additionally checks version compatibility.</remarks>
        public override IFactRuleCollection GetCompatibleRules(IFactWork target, IFactRuleCollection factRules, IWantActionContext context)
        {
            var result = base.GetCompatibleRules(target, factRules, context);
            var maxVersion = context.WantAction.InputFactTypes.FindVersionFact(context);

            if (maxVersion == null)
                return result;

            return result.FindAll(rule => rule.CompatibleRule(maxVersion, context));
        }

        /// <inheritdoc/>
        /// <remarks>Additionally checks version compatibility.</remarks>
        public override bool CompatibleRule(IFactWork target, IFactRule rule, IWantActionContext context)
        {
            if (!base.CompatibleRule(target, rule, context))
                return false;

            var maxVersion = context.WantAction.InputFactTypes.FindVersionFact(context);

            if (maxVersion == null)
                return true;

            var ruleVersion = rule.InputFactTypes.FindVersionFact(context);

            return ruleVersion != null && maxVersion.CompareTo(ruleVersion) >= 0;
        }

        /// <inheritdoc/>
        /// <remarks>Additionally checks version compatibility.</remarks>
        public override bool CanExtractFact(IFactType factType, IFactWork factWork, IWantActionContext context)
        {
            if (factType.IsFactType<ISpecialFact>())
                return base.CanExtractFact(factType, factWork, context);

            List<IFact> facts = context
                .Container
                .WhereFactsByFactType(factType, context.Cache)
                .ToList();

            if (facts.Count == 0)
                return false;

            var maxVersion = context.WantAction.InputFactTypes.FindVersionFact(context);

            if (maxVersion == null)
                return true;

            return facts.Exists(fact => fact.IsRelevantFactByVersioned(maxVersion));
        }

        /// <inheritdoc/>
        /// <remarks>Additionally checks version compatibility.</remarks>
        public override IEnumerable<IFactType> GetRequiredTypesOfFacts(IFactWork factWork, IWantActionContext context)
        {
            IVersionFact? maxVersion = context.WantAction.InputFactTypes.FindVersionFact(context);

            return factWork.InputFactTypes.Where(factType => context
                .Container
                .WhereFactsByFactType(factType, context.Cache)
                .All(fact => !fact.IsRelevantFactByVersioned(maxVersion))
            );
        }

        /// <inheritdoc/>
        /// <remarks>Additionally checks version compatibility.</remarks>
        protected override IEnumerable<IFact> GetRequireFacts(IFactWork factWork, IWantActionContext context)
        {
            var maxVersion = context.WantAction.InputFactTypes.FindVersionFact(context);

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
        public override IFact CalculateFact(NodeByFactRule node, IWantActionContext context)
        {
            IVersionFact? version = node.Info.Rule.InputFactTypes.FindVersionFact(context);

            IFact fact = base.CalculateFact(node, context);

            if (version != null)
                fact.AddVerionParameter(version, context.ParameterCache);

            return fact;
        }

        /// <inheritdoc/>
        /// <remarks>Adds a <see cref="IVersionFact"/> to the parameters of the calculated fact.</remarks>
        public override async ValueTask<IFact> CalculateFactAsync(NodeByFactRule node, IWantActionContext context)
        {
            IVersionFact? version = node.Info.Rule.InputFactTypes.FindVersionFact(context);

            IFact fact = await base.CalculateFactAsync(node, context)
                .ConfigureAwait(false);

            if (version != null)
                fact.AddVerionParameter(version, context.ParameterCache);

            return fact;
        }
    }
}
