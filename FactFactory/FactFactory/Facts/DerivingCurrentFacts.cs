using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GetcuReone.FactFactory.Facts
{
    /// <summary>
    /// Current calculated facts
    /// </summary>
    public sealed class DerivingCurrentFacts : FactBase<ReadOnlyCollection<IFactType>>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factTypes"></param>
        public DerivingCurrentFacts(ReadOnlyCollection<IFactType> factTypes) : base(factTypes)
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factTypes"></param>
        public DerivingCurrentFacts(IList<IFactType> factTypes) : this(new ReadOnlyCollection<IFactType>(factTypes))
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
