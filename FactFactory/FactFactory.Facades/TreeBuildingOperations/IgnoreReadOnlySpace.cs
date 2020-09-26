using GetcuReone.FactFactory.Interfaces;
using System;

namespace GetcuReone.FactFactory.Facades.TreeBuildingOperations
{
    internal class IgnoreReadOnlySpace : IDisposable
    {
        private readonly IFactContainer _container;

        internal IgnoreReadOnlySpace(IFactContainer container)
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
