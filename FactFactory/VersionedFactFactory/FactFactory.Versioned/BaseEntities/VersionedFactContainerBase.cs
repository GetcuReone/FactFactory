using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Versioned.BaseEntities
{
    /// <summary>
    /// Base class for versioned fact container.
    /// </summary>
    /// <typeparam name="TFactBase"></typeparam>
    public abstract class VersionedFactContainerBase<TFactBase> : FactContainerBase<TFactBase>
        where TFactBase : IVersionedFact
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        protected VersionedFactContainerBase() : base(null)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="facts">An array of facts to add to the container.</param>
        protected VersionedFactContainerBase(IEnumerable<TFactBase> facts) : base(facts, false)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="facts">An array of facts to add to the container.</param>
        /// <param name="isReadOnly"></param>
        protected VersionedFactContainerBase(IEnumerable<TFactBase> facts, bool isReadOnly) : base(facts, isReadOnly)
        {
        }

        
    }
}
