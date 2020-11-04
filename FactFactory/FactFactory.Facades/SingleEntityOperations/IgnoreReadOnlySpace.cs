using GetcuReone.FactFactory.Interfaces;
using System;
using System.Threading;

namespace GetcuReone.FactFactory.Facades.SingleEntityOperations
{
    internal class IgnoreReadOnlySpace<TFactContainer> : IDisposable
        where TFactContainer : IFactContainer
    {
        private readonly TFactContainer _container;

        internal IgnoreReadOnlySpace(TFactContainer container)
        {
            _container = container;
            Monitor.Enter(_container);
            _container.IsReadOnly = false;
        }

        public void Dispose()
        {
            _container.IsReadOnly = true;
            Monitor.Exit(_container);
        }
    }
}
