﻿using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned.Helpers;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.Versioned.BaseEntities
{
    /// <summary>
    /// Version rule for calculating a fact.
    /// </summary>
    /// <typeparam name="TFactBase">Base class for facts.</typeparam>
    public abstract class VersionedFactRuleBase<TFactBase> : FactRuleBase<TFactBase>, IVersionedFactRule<TFactBase>
        where TFactBase : IVersionedFact
    {
        /// <summary>
        /// Type of fact with rule version.
        /// </summary>
        public IFactType VersionType { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="inputFactTypes"></param>
        /// <param name="outputFactType"></param>
        public VersionedFactRuleBase(Func<IFactContainer<TFactBase>, TFactBase> func, List<IFactType> inputFactTypes, IFactType outputFactType) : base(func, inputFactTypes, outputFactType)
        {
            outputFactType.CannotIsType<IVersionFact>(nameof(outputFactType));

            VersionType = inputFactTypes?.SingleOrNullFactVersion();
        }

        /// <summary>
        /// Comparison of rules for calculating facts without regard to version.
        /// </summary>
        /// <typeparam name="TVersionedFactRule"></typeparam>
        /// <param name="versionedFactRule"></param>
        /// <returns></returns>
        public bool CompareWithoutVersion<TVersionedFactRule>(TVersionedFactRule versionedFactRule) where TVersionedFactRule : IVersionedFactRule<TFactBase>
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
        /// <returns></returns>
        public override TFactBase Calculate<TContainer>(TContainer container)
        {
            TFactBase versionedFact = base.Calculate(container);

            if (VersionType != null)
                versionedFact.Version = (IVersionFact)container.First(fact => fact is IVersionFact && fact.GetFactType().Compare(VersionType));

            return versionedFact;
        }
    }
}
