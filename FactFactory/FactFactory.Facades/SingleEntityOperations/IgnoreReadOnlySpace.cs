using GetcuReone.FactFactory.Interfaces;
using System;
using System.Threading;

namespace GetcuReone.FactFactory.Facades.SingleEntityOperations
{
    internal class IgnoreReadOnlySpace<TFactContainer> : IDisposable
        where TFactContainer : IFactContainer
    {
        private readonly TFactContainer _container;
        private readonly bool _previousValue;

        internal IgnoreReadOnlySpace(TFactContainer container)
        {
            _container = container;
            Monitor.Enter(_container);
            _previousValue = _container.IsReadOnly;
            if (_previousValue)
                _container.IsReadOnly = false;
        }

        public void Dispose()
        {
            if (_previousValue != _container.IsReadOnly)
                _container.IsReadOnly = _previousValue;
            Monitor.Exit(_container);
        }
    }
}
