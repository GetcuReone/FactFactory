using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Exceptions.Entities;
using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned.BaseEntities;
using GetcuReone.FactFactory.Versioned.Constants;
using GetcuReone.FactFactory.Versioned.Helpers;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System.Collections.Generic;
using System.Linq;
using CommonErrorCode = GetcuReone.FactFactory.Constants.ErrorCode;

namespace GetcuReone.FactFactory.Versioned
{
    /// <summary>
    /// Base class for versioned fact factory
    /// </summary>
    public abstract class VersionedFactFactoryBase<TFactBase, TFactContainer, TFactRule, TFactRuleCollection, TWantAction> : FactFactoryBase<TFactBase, TFactContainer, TFactRule, TFactRuleCollection, TWantAction>, IVersionedFactFactory<TFactBase, TFactContainer, TFactRule, TFactRuleCollection, TWantAction>
        where TFactBase : class, IVersionedFact
        where TFactContainer : VersionedFactContainerBase<TFactBase>
        where TFactRule : VersionedFactRuleBase<TFactBase>
        where TFactRuleCollection : FactRuleCollectionBase<TFactBase, TFactRule>
        where TWantAction : VersionedWantActionBase<TFactBase>
    {
        private List<IFactType> _calculatedFactTypes;
        private TWantAction _calculatingWantAction;

        /// <summary>
        /// Returns only those lambdas that fit the requested version.
        /// </summary>
        /// <param name="rules">Current set of rules.</param>
        /// <param name="container">Current fact set.</param>
        /// <param name="wantAction">Current wantAction</param>
        /// <returns></returns>
        protected override IList<TFactRule> GetRulesForWantAction(TWantAction wantAction, FactContainerBase<TFactBase> container, FactRuleCollectionBase<TFactBase, TFactRule> rules)
        {
            // We find out the version that we will focus on
            // If the version is not requested, then we consider that the last is necessary
            IVersionFact versionFact = null;

            if (wantAction.VersionType != null)
                versionFact = container.GetVersionFact(wantAction.VersionType);

            var factRules = new List<TFactRule>();

            foreach (TFactRule rule in rules)
            {
                if (versionFact != null)
                {
                    // No version means the highest possible version
                    if (rule.VersionType == null)
                        continue;

                    IVersionFact factRuleVersion = container.GetVersionFact(rule.VersionType);

                    if (factRuleVersion.IsMoreThan(versionFact))
                        continue;

                    TFactRule previousRule = factRules.SingleOrDefault(r => r.CompareWithoutVersion(rule));

                    if (previousRule != null)
                    {
                        IVersionFact previousFactRuleVersion = container.GetVersionFact(previousRule.VersionType);

                        if (previousFactRuleVersion.IsMoreThan(factRuleVersion))
                            continue;

                        factRules.Remove(previousRule);
                        factRules.Add(rule);
                    }
                    else
                        factRules.Add(rule);
                }
                else
                {
                    if (rule.VersionType != null)
                    {
                        IVersionFact factRuleVersion = container.GetVersionFact(rule.VersionType);

                        TFactRule previousRule = factRules.SingleOrDefault(r => r.CompareWithoutVersion(rule));

                        if (previousRule != null)
                        {
                            if (previousRule.VersionType == null)
                                continue;

                            IVersionFact previousFactRuleVersion = container.GetVersionFact(previousRule.VersionType);

                            if (previousFactRuleVersion.IsMoreThan(factRuleVersion))
                                continue;
                            else if (!previousFactRuleVersion.IsLessThan(factRuleVersion))
                                throw FactFactoryHelper.CreateException(ErrorCode.VersionConflict, "Found facts that are no less and no more than each other." +
                                    $"\nFirst rule :{rule.ToString()} version: {previousRule.VersionType.FactName}. Second rule: {previousRule.ToString()} version: {previousRule.VersionType.FactName}");

                            factRules.Remove(previousRule);
                            factRules.Add(rule);
                        }
                        else
                            factRules.Add(rule);
                    }
                    else
                    {
                        TFactRule previousRule = factRules.SingleOrDefault(r => r.CompareWithoutVersion(rule));

                        if (previousRule != null)
                        {
                            if (previousRule.VersionType == null)
                                throw FactFactoryHelper.CreateException(ErrorCode.VersionConflict, $"Same rules found without versions\n{rule.ToString()}");

                            factRules.Remove(previousRule);
                        }

                        factRules.Add(rule);
                    }
                }
            }

            return factRules;
        }

        /// <summary>
        /// Returns instances of all used versions
        /// </summary>
        /// <returns></returns>
        protected abstract IEnumerable<IVersionFact> GetAllVersions();

        /// <summary>
        /// Return the fact set that will be contained in the default container.
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        protected override IEnumerable<TFactBase> GetDefaultFacts(FactContainerBase<TFactBase> container)
        {
            IEnumerable<TFactBase> allVersionFacts = GetAllVersions()?.Select(version => version.ConvertFact<TFactBase>()) ?? Enumerable.Empty<TFactBase>();

            List<IVersionFact> defaultVersions = container.Where(version => version is IVersionFact).Select(version => (IVersionFact)version).ToList();
            List<IFactType> defaultVersionTypes = defaultVersions.ConvertAll(version => version.GetFactType());

            foreach(var version in allVersionFacts)
            {
                if (defaultVersionTypes.All(defaultVersion => !defaultVersion.Compare(version.GetFactType())))
                    defaultVersions.Add((IVersionFact)version);
            }

            List<DeriveErrorDetail<TFactBase>> errorDetails = new List<DeriveErrorDetail<TFactBase>>();

            foreach(var version1 in defaultVersions)
            {
                foreach(var version2 in defaultVersions)
                {
                    if (version1 == version2)
                        continue;

                    bool[] resultComparison = new bool[3]
                    {
                        version1.IsLessThan(version2),
                        version1.IsMoreThan(version2),
                        version1.EqualVersion(version2),
                    };

                    if (resultComparison.All(result => result == false) || resultComparison.Count(result => result == true) > 1)
                    {
                        errorDetails.Add(new DeriveErrorDetail<TFactBase>(
                        CommonErrorCode.InvalidData,
                        $"For versions {version1.GetFactType().FactName} and {version2.GetFactType().FactName}, comparison operations did not work correctly.",
                        null,
                        null));
                    }
                }
            }

            if (errorDetails.Count != 0)
                throw new InvalidDeriveOperationException<TFactBase>(errorDetails);

            return defaultVersions.Select(version => (TFactBase)version);
        }

        /// <summary>
        /// The method determines whether the fact should be recounted.
        /// </summary>
        /// <param name="rule">Rule for calculating the fact.</param>
        /// <param name="container">Fact container.</param>
        /// <param name="wantAction">The initial action for which the parameters are calculated.</param>
        /// <returns>True - fact needs to be recalculated.</returns>
        protected override bool NeedRecalculateFact(TFactRule rule, FactContainerBase<TFactBase> container, TWantAction wantAction)
        {
            // The last fact that is accepted or given by the rule
            IFactType lastSuitableFactType = _calculatedFactTypes.LastOrDefault(type => type.Compare(rule.OutputFactType) || rule.InputFactTypes.Any(t => t.Compare(type)));

            // If the last time one of the input facts was recounted
            if (lastSuitableFactType != null && !lastSuitableFactType.Compare(rule.OutputFactType))
                return true;

            // The extraction must always be successful.
            rule.OutputFactType.TryGetFact(container, out TFactBase containedFact);

            // If the maximum version is not specified
            if (wantAction.VersionType == null)
            {
                if (containedFact.Version == null)
                    return false;
                else if (rule.VersionType == null)
                    return true;

                // If less rule version
                IVersionFact ruleVersion = container.GetVersionFact(rule.VersionType);
                return containedFact.Version.IsLessThan(ruleVersion);
            }
            else
            {
                if (containedFact.Version == null)
                    return true;

                // If more than the maximum allowable version
                IVersionFact maxVersion = container.GetVersionFact(wantAction.VersionType);
                if (containedFact.Version.IsMoreThan(maxVersion))
                    return true;

                // If less rule version
                IVersionFact ruleVersion = container.GetVersionFact(rule.VersionType);
                return containedFact.Version.IsLessThan(ruleVersion);
            }
        }

        /// <summary>
        /// Fact calculation event handler for an <paramref name="wantAction"/>.
        /// </summary>
        /// <param name="factType">Type calculated fact.</param>
        /// <param name="container">Container.</param>
        /// <param name="wantAction">The action for which the fact was calculated.</param>
        protected override void OnFactCalculatedForWantAction(IFactType factType, FactContainerBase<TFactBase> container, TWantAction wantAction)
        {
            if (_calculatingWantAction == null)
                _calculatingWantAction = wantAction;
            else if (_calculatingWantAction != wantAction)
            {
                _calculatedFactTypes.Clear();
                _calculatingWantAction = wantAction;
            }

            _calculatedFactTypes.Add(factType);
        }

        /// <summary>
        /// Derive the facts
        /// </summary>
        public override void Derive()
        {
            _calculatedFactTypes = new List<IFactType>();

            base.Derive();

            _calculatedFactTypes.Clear();
            _calculatedFactTypes = null;
        }

        /// <summary>
        /// Derive <typeparamref name="TWantFact"/> with version.
        /// </summary>
        /// <typeparam name="TWantFact">Type of desired fact.</typeparam>
        /// <typeparam name="TVersion">Type of version fact.</typeparam>
        /// <returns></returns>
        public virtual TWantFact DeriveFact<TWantFact, TVersion>()
            where TWantFact : TFactBase
            where TVersion : TFactBase, IVersionFact
        {
            TWantFact fact = default;

            var wantActions = new List<TWantAction>(WantActions);
            WantActions.Clear();

            WantFact(CreateWantAction(
                container => fact = container.GetFact<TWantFact>(),
                new List<IFactType> { GetFactType<TVersion>(), GetFactType<TWantFact>() }));

            Derive();

            WantActions.AddRange(wantActions);

            return fact;
        }
    }
}
