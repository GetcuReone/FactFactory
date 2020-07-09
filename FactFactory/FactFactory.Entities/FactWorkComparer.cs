using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetcuReone.FactFactory.Entities
{
    /// <summary>
    /// Comparer for <see cref="IFactWork{TFactBase}"/>.
    /// </summary>
    public class FactWorkComparer<TFactBase, TFactWork, TWantAction, TFactContainer> : IComparer<TFactWork>
        where TFactBase : IFact
        where TFactWork : IFactWork<TFactBase>
        where TWantAction : IWantAction<TFactBase>
        where TFactContainer : IFactContainer<TFactBase>
    {
        private readonly TWantAction _wantAction;
        private readonly TFactContainer _container;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="wantAction"></param>
        /// <param name="container"></param>
        public FactWorkComparer(TWantAction wantAction, TFactContainer container)
        {
            _wantAction = wantAction;
            _container = container;
        }

        /// <inheritdoc/>
        public int Compare(TFactWork x, TFactWork y)
        {
            if (x.IsMorePriorityThan(y, _container))
                return -1;
            else if (x.IsLessPriorityThan(y, _container))
                return 1;
            else
                return 0;
        }
    }
}
