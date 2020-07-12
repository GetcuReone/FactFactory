using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <summary>
    /// Base class for comparer for <see cref="IWantAction{TFactBase}"/>.
    /// </summary>
    public abstract class WantActionComparerBase<TFactBase, TWantAction, TFactContainer> : IComparer<TWantAction>
        where TFactBase : IFact
        where TWantAction : IWantAction<TFactBase>
        where TFactContainer : IFactContainer<TFactBase>
    {
        /// <summary>
        /// Fact container.
        /// </summary>
        protected TFactContainer Container { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="container"></param>
        protected WantActionComparerBase(TFactContainer container)
        {
            Container = container;
        }

        /// <inheritdoc/>
        public virtual int Compare(TWantAction x, TWantAction y)
        {
            return 0;
        }
    }
}
