using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.InnerEntities
{
    internal sealed class WorkFactCompare<TFactBase, TFactWork, TFactContainer> : IComparer<TFactWork>
        where TFactBase : IFact
        where TFactWork : IFactWork<TFactBase>
        where TFactContainer : IFactContainer<TFactBase>
    {
        private readonly TFactContainer _container;

        public WorkFactCompare(TFactContainer container)
        {
            _container = container;
        }

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
