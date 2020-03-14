using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using System;

namespace GetcuReone.FactFactory.Helpers
{
    internal class IgnoreReadOnlySpace<TFact> : IDisposable
        where TFact : IFact
    {
        private readonly FactContainerBase<TFact> _container;

        internal IgnoreReadOnlySpace(FactContainerBase<TFact> container)
        {
            _container = container;
            _container.IsReadOnly = false;
        }

        public void Dispose()
        {
            _container.IsReadOnly = true;
        }
    }
}
