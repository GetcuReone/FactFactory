using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Entities
{
    /// <summary>
    /// Fact collection.
    /// </summary>
    public class FactContainer : FactContainerBase<FactBase>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public FactContainer() { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="facts">An array of facts to add to the container.</param>
        public FactContainer(IEnumerable<IFact> facts) : base(facts) { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="facts">An array of facts to add to the container.</param>
        /// <param name="isReadOnly"></param>
        public FactContainer(IEnumerable<IFact> facts, bool isReadOnly) : base(facts, isReadOnly)
        {
        }

        /// <inheritdoc/>
        public override FactContainerBase<FactBase> Copy()
        {
            return new FactContainer(this, IsReadOnly);
        }
    }
}
