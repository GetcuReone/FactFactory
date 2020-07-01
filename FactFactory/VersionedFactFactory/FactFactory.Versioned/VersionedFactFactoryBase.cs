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
    /// Base class for versioned fact factory.
    /// </summary>
    public abstract class VersionedFactFactoryBase<TFactBase, TFactContainer, TFactRule, TFactRuleCollection, TWantAction> : FactFactoryBase<TFactBase, TFactContainer, TFactRule, TFactRuleCollection, TWantAction>, IVersionedFactFactory<TFactBase, TFactContainer, TFactRule, TFactRuleCollection, TWantAction>
        where TFactBase : class, IVersionedFact
        where TFactContainer : VersionedFactContainerBase<TFactBase>
        where TFactRule : VersionedFactRuleBase<TFactBase>
        where TFactRuleCollection : VersionedFactRuleCollectionBase<TFactBase, TFactRule>
        where TWantAction : VersionedWantActionBase<TFactBase>
    {
        private List<IFactType> _calculatedFactTypes;
        private TWantAction _calculatingWantAction;

        /// <summary>
        /// Return the correct fact.
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <param name="container"></param>
        /// <param name="inputFactTypes"></param>
        /// <returns></returns>
        protected override TFact GetCorrectFact<TFact>(IFactContainer<TFactBase> container, IReadOnlyCollection<IFactType> inputFactTypes)
        {
            IFactType versionType = inputFactTypes.SingleOrDefault(type => type.IsFactType<IVersionFact>());

            IVersionFact version = versionType != null
                ? container.GetVersionFact(versionType)
                : null;

            return (TFact)container.GetRightFactByVersion(GetFactType<TFact>(), version);
        }

        /// <summary>
        /// Returns only those lambdas that fit the requested version.
        /// </summary>
        /// <param name="rules">Current set of rules.</param>
        /// <param name="container">Current fact set.</param>
        /// <param name="wantAction">Current wantAction</param>
        /// <returns></returns>
        protected override IList<TFactRule> GetRulesForWantAction(TWantAction wantAction, TFactContainer container, TFactRuleCollection rules)
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
        /// Returns instances of all used versions.
        /// </summary>
        /// <returns></returns>
        protected abstract IEnumerable<IVersionFact> GetAllVersions();

        /// <summary>
        /// Return the fact set that will be contained in the default container.
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        protected override IEnumerable<TFactBase> GetDefaultFacts(TFactContainer container)
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
        /// <param name="needRemoveFact">If the method returns the true, then this fact will be removed from the container. There will be no deletion if the fact is empty.</param>
        /// <returns>True - fact needs to be recalculated.</returns>
        protected override bool NeedRecalculateFact(TFactRule rule, TFactContainer container, TWantAction wantAction, out TFactBase needRemoveFact)
        {
            bool result = false;
            needRemoveFact = null;

            IVersionFact maxVersion = wantAction.VersionType != null
                ? container.GetRightFactByVersionType(wantAction.VersionType, null) as IVersionFact
                : null;
            IVersionFact ruleVersion =  rule.VersionType != null
                ? container.GetRightFactByVersionType(rule.VersionType, null) as IVersionFact
                : null;
            TFactBase currentFact = container.GetRightFactByVersion(rule.OutputFactType, maxVersion);

            if (currentFact == null)
                result = true;
            else if (!currentFact.CalculatedByRule)
                result = false;
            else
            {
                // The last fact that is accepted or given by the rule
                IFactType lastSuitableFactType = _calculatedFactTypes.LastOrDefault(type => type.Compare(rule.OutputFactType) || rule.InputFactTypes.Any(t => t.Compare(type)));

                // If the last time one of the input facts was recounted
                if (lastSuitableFactType != null && !lastSuitableFactType.Compare(rule.OutputFactType))
                    result = true;

                if (!result)
                {
                    // If the maximum version is not specified
                    if (maxVersion == null)
                    {
                        if (currentFact.Version != null)
                        {
                            if (ruleVersion == null)
                                result = true;
                            else
                                result = currentFact.Version.IsLessThan(ruleVersion);
                        }
                    }
                    else
                    {
                        if (currentFact.Version == null)
                            result = true;
                        else if (currentFact.Version.IsMoreThan(maxVersion))
                            result = true;
                        else if (ruleVersion == null)
                            result = true;
                        else
                            result = currentFact.Version.IsLessThan(ruleVersion);
                    }
                }
            }

            if (result && currentFact != null)
            {
                if (ruleVersion == null)
                {
                    if (currentFact.Version == null)
                        needRemoveFact = currentFact;
                }
                else if (currentFact.Version != null && ruleVersion.EqualVersion(currentFact.Version))
                    needRemoveFact = currentFact;
            }

            return result;
        }

        /// <summary>
        /// Fact calculation event handler for an <paramref name="wantAction"/>.
        /// </summary>
        /// <param name="factType">Type calculated fact.</param>
        /// <param name="container">Container.</param>
        /// <param name="wantAction">The action for which the fact was calculated.</param>
        protected override void OnFactCalculatedForWantAction(IFactType factType, TFactContainer container, TWantAction wantAction)
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
        /// Derive the facts.
        /// </summary>
        public override void Derive()
        {
            _calculatedFactTypes = new List<IFactType>();

            base.Derive();

            _calculatedFactTypes.Clear();
            _calculatedFactTypes = null;
        }

        /// <summary>
        /// Derive <typeparamref name="TFact"/> with version.
        /// </summary>
        /// <typeparam name="TFact">Type of desired fact.</typeparam>
        /// <typeparam name="TVersion">Type of version fact.</typeparam>
        /// <returns></returns>
        public virtual TFact DeriveFact<TFact, TVersion>()
            where TFact : TFactBase
            where TVersion : TFactBase, IVersionFact
        {
            TFact fact = default;

            var wantActions = new List<TWantAction>(WantActions);
            WantActions.Clear();

            var inputFacts = new List<IFactType> { GetFactType<TFact>(), GetFactType<TVersion>() };

            WantFact(CreateWantAction(
                container => fact = GetCorrectFact<TFact>(container, inputFacts),
                inputFacts));

            Derive();

            WantActions.AddRange(wantActions);

            return fact;
        }
    }
}
