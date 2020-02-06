using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GetcuReone.FactFactory.Facts
{
    /// <summary>
    /// All deriving facts
    /// </summary>
    public sealed class DerivingFacts : FactBase<ReadOnlyCollection<IFactType>>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factTypes"></param>
        public DerivingFacts(ReadOnlyCollection<IFactType> factTypes) : base(factTypes)
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factTypes"></param>
        public DerivingFacts(IList<IFactType> factTypes) : this(new ReadOnlyCollection<IFactType>(factTypes))
        {

        }

        /// <summary>
        /// Get fact type
        /// </summary>
        /// <returns>fact type</returns>
        public override IFactType GetFactType()
        {
            return new FactType<DerivingCurrentFacts>();
        }
    }
}
