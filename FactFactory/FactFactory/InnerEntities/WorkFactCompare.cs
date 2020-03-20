using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.InnerEntities
{
    internal sealed class WorkFactCompare<TFactBase, TWorkFact, TFactContainer> : IComparer<TWorkFact>
        where TFactBase : IFact
        where TWorkFact : IWorkFact<TFactBase>
        where TFactContainer : IFactContainer<TFactBase>
    {
        private readonly TFactContainer _container;

        public WorkFactCompare(TFactContainer container)
        {
            _container = container;
        }

        public int Compare(TWorkFact x, TWorkFact y)
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
