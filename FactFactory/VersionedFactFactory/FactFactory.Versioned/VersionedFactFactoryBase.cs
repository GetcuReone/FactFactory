using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
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
    public abstract class VersionedFactFactoryBase<TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction> : FactFactoryBase<TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction>
        where TFact : class, IVersionedFact
        where TFactContainer : FactContainerBase<TFact>
        where TFactRule : class, IVersionedFactRule<TFact>
        where TFactRuleCollection : FactRuleCollectionBase<TFact, TFactRule>
        where TWantAction : class, IWantAction<TFact>, IFactTypeVersionInformation
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
        protected override IList<TFactRule> GetRulesForWantAction(TWantAction wantAction, FactContainerBase<TFact> container, FactRuleCollectionBase<TFact, TFactRule> rules)
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
        /// Calculate fact.
        /// </summary>
        /// <param name="rule">Rule for calculating the fact.</param>
        /// <param name="container">Fact container.</param>
        /// <param name="wantAction">The initial action for which the parameters are calculated.</param>
        /// <remarks>True - fact calculate. False - fact already exists</remarks>
        protected override bool CalculateFact(TFactRule rule, FactContainerBase<TFact> container, TWantAction wantAction)
        {
            if (_calculatingWantAction == null)
                _calculatingWantAction = wantAction;
            else if (_calculatingWantAction != wantAction)
            {
                _calculatedFactTypes.Clear();
                _calculatingWantAction = wantAction;
            }

            // Recalculate fact if
            // 1. Versions of rule and fact are different
            // 2. Input fact has been recalculate
            TFact fact = container.FirstOrDefault(f => f.GetFactType().Compare(rule.OutputFactType));

            if (fact != null)
            {
                if (rule.VersionType != null)
                {
                    IVersionFact version = container.GetVersionFact(rule.VersionType);
                    if (version.IsLessThan(fact.Version) || version.IsMoreThan(fact.Version))
                        container.Remove(fact);
                }
                else if (fact.Version != null)
                    container.Remove(fact);

                if (rule.InputFactTypes.Any(type => _calculatedFactTypes.Any(calculatedFactType => calculatedFactType.Compare(type))))
                    container.Remove(fact);
            }

            bool result = base.CalculateFact(rule, container, wantAction);

            if (result)
                _calculatedFactTypes.Add(rule.OutputFactType);

            return result;
        }

        /// <summary>
        /// Returns instances of all used versions
        /// </summary>
        /// <returns></returns>
        protected abstract List<IVersionFact> GetAllVersions();

        /// <summary>
        /// Derive the facts
        /// </summary>
        public override void Derive()
        {
            _calculatedFactTypes = new List<IFactType>();

            // Get the version
            List<IVersionFact> versions = GetAllVersions();
            var invalidFacts = versions.Where(fact => !(fact is TFact)).ToList();

            if (!invalidFacts.IsNullOrEmpty())
                throw FactFactoryHelper.CreateDeriveException<TFact, TWantAction>(
                    CommonErrorCode.InvalidData,
                    $"{string.Join(", ", invalidFacts.ConvertAll(f => f.GetType().Name))} not inherited from type {typeof(TFact).FullName}");

            foreach (IVersionFact versionFact in versions)
            {
                if (versionFact.GetFactType().TryGetFact(Container, out TFact fact))
                    Container.Remove(fact);

                Container.Add((TFact)versionFact);
            }

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
            where TWantFact : TFact
            where TVersion : TFact, IVersionFact
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
