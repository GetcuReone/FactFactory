using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned.BaseEntities;
using System;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Versioned.Entities
{
    /// <summary>
    /// Version rule for calculating a fact.
    /// </summary>
    public class VersionedFactRule : VersionedFactRuleBase<VersionedFactBase>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="inputFactTypes"></param>
        /// <param name="outputFactType"></param>
        public VersionedFactRule(Func<IFactContainer<VersionedFactBase>, IWantAction<VersionedFactBase>, VersionedFactBase> func, List<IFactType> inputFactTypes, IFactType outputFactType) : base(func, inputFactTypes, outputFactType)
        {
        }
    }
}
