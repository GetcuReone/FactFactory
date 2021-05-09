using GetcuReone.FactFactory.Interfaces;
using System;
using System.Threading;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <summary>
    /// Writer to write facts in a container.
    /// </summary>
    public class FactContainerWriter<TFactContainer> : IDisposable
        where TFactContainer : IFactContainer
    {
        private readonly TFactContainer _container;
        private readonly bool _previousValue;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="container"></param>
        public FactContainerWriter(TFactContainer container)
        {
            _container = container;
            Monitor.Enter(_container);
            _previousValue = _container.IsReadOnly;
            if (_previousValue)
                _container.IsReadOnly = false;
        }

        /// <inheritdoc/>
        public virtual void Dispose()
        {
            if (_previousValue != _container.IsReadOnly)
                _container.IsReadOnly = _previousValue;
            Monitor.Exit(_container);
        }
    }
}
