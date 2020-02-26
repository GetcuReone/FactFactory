using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Entities
{
    /// <summary>
    /// Fact collection
    /// </summary>
    public class FactContainer : FactContainerBase<IFact>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FactContainer() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="facts">an array of facts to add to the container</param>
        public FactContainer(IEnumerable<IFact> facts) : base(facts) { }

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
