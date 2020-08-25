using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Versioned.BaseEntities
{
    /// <summary>
    /// Version rule for calculating a fact.
    /// </summary>
    public abstract class VersionedFactRuleBase : FactRuleBase
    {

        /// <inheritdoc/>
        protected VersionedFactRuleBase(Func<IEnumerable<IFact>, IFact> func, List<IFactType> inputFactTypes, IFactType outputFactType) : base(func, inputFactTypes, outputFactType)
        {
        }
    }
}
