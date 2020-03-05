using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned.Facts;
using GetcuReone.FactFactory.Versioned.Helpers;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.Versioned.Entities
{
    /// <summary>
    /// Version rule for calculating a fact
    /// </summary>
    public class VersionedFactRule : FactRuleBase<VersionedFactBase>, IVersionedFactRule<VersionedFactBase>
    {
        /// <summary>
        /// Type of fact with rule version
        /// </summary>
        public IFactType VersionType { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="func"></param>
        /// <param name="inputFactTypes"></param>
        /// <param name="outputFactType"></param>
        public VersionedFactRule(Func<IFactContainer<VersionedFactBase>, VersionedFactBase> func, List<IFactType> inputFactTypes, IFactType outputFactType) : base(func, inputFactTypes, outputFactType)
        {
            outputFactType.CannotIsType<IVersionFact>(nameof(outputFactType));

            VersionType = inputFactTypes?.SingleOrNullFactVersion();
        }

        /// <summary>
        /// Comparison of rules for calculating facts without regard to version
        /// </summary>
        /// <typeparam name="TVersionedFactRule"></typeparam>
        /// <param name="versionedFactRule"></param>
        /// <returns></returns>
        public bool CompareWithoutVersion<TVersionedFactRule>(TVersionedFactRule versionedFactRule) where TVersionedFactRule : IVersionedFactRule<VersionedFactBase>
        {
            if (!OutputFactType.Compare(versionedFactRule.OutputFactType))
                return false;

            return CompareFactTypes(
                InputFactTypes.Where(factType => !factType.IsFactType<IVersionFact>()).ToList(),
                versionedFactRule.InputFactTypes.Where(factType => !factType.IsFactType<IVersionFact>()).ToList());
        }

        /// <summary>
        /// Rule of fact calculate.
        /// </summary>
        /// <param name="container"></param>
        /// <typeparam name="TContainer"></typeparam>
        /// <exception cref="InvalidOperationException">The rule did not return a fact.</exception>
        /// <returns></returns>
        public override VersionedFactBase Calculate<TContainer>(TContainer container)
        {
            VersionedFactBase versionedFact = base.Calculate(container);

            if (VersionType != null)
                versionedFact.Version = (IVersionFact)container.First(fact => fact is IVersionFact && fact.GetFactType().Compare(VersionType));

            return versionedFact;
        }
    }
}
