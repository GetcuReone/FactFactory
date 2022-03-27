using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Entities
{
    /// <summary>
    /// Fact collection.
    /// </summary>
    public class FactContainer : FactContainerBase
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public FactContainer() { }

        /// <inheritdoc/>
        public FactContainer(IEnumerable<IFact> facts) : base(facts) { }

        /// <inheritdoc/>
        public FactContainer(IEnumerable<IFact> facts, bool isReadOnly) : base(facts, isReadOnly)
        {
        }
    }
}
