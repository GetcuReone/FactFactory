using GetcuReone.FactFactory.BaseEntities;
using System;

namespace GetcuReone.FactFactory.Helpers
{
    internal class IgnoreReadOnlySpace : IDisposable
    {
        private readonly FactContainerBase _container;

        internal IgnoreReadOnlySpace(FactContainerBase container)
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
