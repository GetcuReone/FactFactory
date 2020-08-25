using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned.BaseEntities;
using System;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Versioned.Entities
{
    /// <summary>
    /// Version rule for calculating a fact.
    /// </summary>
    public class VersionedFactRule : VersionedFactRuleBase
    {
        /// <inheritdoc/>
        public VersionedFactRule(Func<IEnumerable<IFact>, IFact> func, List<IFactType> inputFactTypes, IFactType outputFactType) : base(func, inputFactTypes, outputFactType)
        {
        }
    }
}
