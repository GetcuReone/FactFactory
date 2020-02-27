using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned.Facts;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Versioned.Entities
{
    /// <summary>
    /// Versioned fact container.
    /// </summary>
    public class VersionedFactContainer : FactContainerBase<VersionedFactBase>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public VersionedFactContainer()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="facts">an array of facts to add to the container</param>
        public VersionedFactContainer(IEnumerable<VersionedFactBase> facts) : base(facts)
        {
        }

        /// <summary>
        /// Return fact type information.
        /// </summary>
        /// <typeparam name="TGetFact">The type of fact to return information about.</typeparam>
        /// <returns></returns>
        protected override IFactType GetFactType<TGetFact>()
        {
            return new FactType<TGetFact>();
        }
    }
}
