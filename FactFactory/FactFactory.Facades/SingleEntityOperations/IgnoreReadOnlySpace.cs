using GetcuReone.FactFactory.Interfaces;
using System;

namespace GetcuReone.FactFactory.Facades.SingleEntityOperations
{
    internal class IgnoreReadOnlySpace<TFactContainer> : IDisposable
        where TFactContainer : IFactContainer
    {
        private readonly TFactContainer _container;

        internal IgnoreReadOnlySpace(TFactContainer container)
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
