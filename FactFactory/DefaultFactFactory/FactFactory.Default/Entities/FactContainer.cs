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
        public FactContainer(IEnumerable<FactBase> facts) : base(facts) { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="facts">An array of facts to add to the container.</param>
        /// <param name="isReadOnly"></param>
        public FactContainer(IEnumerable<FactBase> facts, bool isReadOnly) : base(facts, isReadOnly)
        {
        }

        /// <summary>
        /// Get copy container.
        /// </summary>
        /// <returns></returns>
        public override FactContainerBase<FactBase> Copy()
        {
            return new FactContainer(this, IsReadOnly);
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
