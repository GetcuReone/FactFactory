using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned.Constants;
using GetcuReone.FactFactory.Versioned.Helpers;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GetcuReone.FactFactory.Versioned
{
    /// <summary>
    /// Base class for versioned fact factory
    /// </summary>
    public abstract class VersionedFactFactoryBase<TFactContainer, TFactRule, TFactRuleCollection, TWantAction> : FactFactoryBase<TFactContainer, TFactRule, TFactRuleCollection, TWantAction>
        where TFactContainer : class, IFactContainer
        where TFactRule : class, IVersionedFactRule
        where TFactRuleCollection : class, IList<TFactRule>
        where TWantAction : class, IWantAction, IFactTypeVersionInformation
    {
        /// <summary>
        /// Returns only those lambdas that fit the requested version
        /// </summary>
        /// <param name="wantAction"></param>
        /// <param name="readOnlyFactContainer"></param>
        /// <returns></returns>
        protected override IReadOnlyCollection<TFactRule> GetRulesForWantAction(TWantAction wantAction, IReadOnlyCollection<IFact> readOnlyFactContainer)
        {
            // We find out the version that we will focus on
            // If the version is not requested, then we consider that the last is necessary
            IVersionFact versionFact = null;

            if (wantAction.TypeFactVersion != null)
                versionFact = readOnlyFactContainer.GetVersionFact(wantAction.TypeFactVersion);

            var factRules = new List<TFactRule>();

            foreach(TFactRule rule in Rules)
            {
                if (versionFact != null)
                {
                    // No version means the highest possible version
                    if (rule.TypeFactVersion == null)
                        continue;

                    IVersionFact factRuleVersion = readOnlyFactContainer.GetVersionFact(rule.TypeFactVersion);

                    if (factRuleVersion.IsMoreThan(versionFact))
                        continue;

                    TFactRule previousRule = factRules.SingleOrDefault(r => r.CompareWithoutVersion(rule));

                    if (previousRule != null)
                    {
                        IVersionFact previousFactRuleVersion = readOnlyFactContainer.GetVersionFact(previousRule.TypeFactVersion);

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
                    if (rule.TypeFactVersion != null)
                    {
                        IVersionFact factRuleVersion = readOnlyFactContainer.GetVersionFact(rule.TypeFactVersion);

                        TFactRule previousRule = factRules.SingleOrDefault(r => r.CompareWithoutVersion(rule));

                        if (previousRule != null)
                        {
                            if (previousRule.TypeFactVersion == null)
                                continue;

                            IVersionFact previousFactRuleVersion = readOnlyFactContainer.GetVersionFact(previousRule.TypeFactVersion);

                            if (previousFactRuleVersion.IsMoreThan(factRuleVersion))
                                continue;
                            else if (!previousFactRuleVersion.IsLessThan(factRuleVersion))
                                throw FactFactoryHelper.CreateException(ErrorCode.VersionConflict, "Found facts that are no less and no more than each other." +
                                    $"\nFirst rule :{rule.ToString()} version: {previousRule.TypeFactVersion.FactName}. Second rule: {previousRule.ToString()} version: {previousRule.TypeFactVersion.FactName}");

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
                            if (previousRule.TypeFactVersion == null)
                                throw FactFactoryHelper.CreateException(ErrorCode.VersionConflict, $"Same rules found without versions\n{rule.ToString()}");

                            factRules.Remove(previousRule);
                        }

                        factRules.Add(rule);
                    }
                }
            }

            return new ReadOnlyCollection<TFactRule>(factRules);
        }
    }
}
