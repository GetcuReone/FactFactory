using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Facts
{
    /// <summary>
    /// All deriving facts
    /// </summary>
    public sealed class DerivingFacts : FactBase<List<IFactType>>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factTypes"></param>
        public DerivingFacts(List<IFactType> factTypes) : base(factTypes)
        {

        }

        /// <summary>
        /// Get fact type
        /// </summary>
        /// <returns>fact type</returns>
        public override IFactType GetFactType()
        {
            return new FactType<DerivingFacts>();
        }
    }
}
