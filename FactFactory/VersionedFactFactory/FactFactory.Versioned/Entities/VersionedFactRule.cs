using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
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
    public class VersionedFactRule : FactRule, IVersionedFactRule
    {
        /// <summary>
        /// Type of fact with rule version
        /// </summary>
        public IFactType TypeFactVersion { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="func"></param>
        /// <param name="inputFactTypes"></param>
        /// <param name="outputFactType"></param>
        public VersionedFactRule(Func<IFactContainer, IFact> func, List<IFactType> inputFactTypes, IFactType outputFactType) : base(func, inputFactTypes, outputFactType)
        {
            TypeFactVersion = inputFactTypes?.SingleOrNullFactVersion();
        }

        /// <summary>
        /// Comparison of rules for calculating facts without regard to version
        /// </summary>
        /// <typeparam name="TVersionedFactRule"></typeparam>
        /// <param name="versionedFactRule"></param>
        /// <returns></returns>
        public bool CompareWithoutVersion<TVersionedFactRule>(TVersionedFactRule versionedFactRule) where TVersionedFactRule : IVersionedFactRule
        {
            if (!OutputFactType.Compare(versionedFactRule.OutputFactType))
                return false;

            List<IFactType> innerInputFactTypeWithoutVersion = InputFactTypes.Where(factType => !factType.IsFactType<IVersionFact>()).ToList();
            List<IFactType> externalInputFactTypeWithoutVersion = versionedFactRule.InputFactTypes.Where(factType => !factType.IsFactType<IVersionFact>()).ToList();

            if (innerInputFactTypeWithoutVersion.IsNullOrEmpty() && externalInputFactTypeWithoutVersion.IsNullOrEmpty())
                return true;
            else if (innerInputFactTypeWithoutVersion.IsNullOrEmpty() || externalInputFactTypeWithoutVersion.IsNullOrEmpty())
                return false;
            else if (innerInputFactTypeWithoutVersion.Count != externalInputFactTypeWithoutVersion.Count)
                return false;
            else
            {
                foreach (var fact in externalInputFactTypeWithoutVersion)
                {
                    if (innerInputFactTypeWithoutVersion.All(f => !f.Compare(fact)))
                        return false;
                }

                return true;
            }
        }
    }
}
