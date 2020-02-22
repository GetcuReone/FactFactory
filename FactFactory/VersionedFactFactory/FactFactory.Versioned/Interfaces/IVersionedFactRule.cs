﻿using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.Versioned.Interfaces
{
    /// <summary>
    /// Version rule for calculating a fact
    /// </summary>
    public interface IVersionedFactRule : IFactRule, IFactTypeVersionInformation
    {
        /// <summary>
        /// Comparison of rules for calculating facts without regard to version
        /// </summary>
        /// <typeparam name="TVersionedFactRule"></typeparam>
        /// <param name="versionedFactRule"></param>
        /// <returns></returns>
        bool CompareWithoutVersion<TVersionedFactRule>(TVersionedFactRule versionedFactRule) where TVersionedFactRule : IVersionedFactRule;
    }
}