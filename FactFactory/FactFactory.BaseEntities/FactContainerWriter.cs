using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <summary>
    /// Writer to write facts in a container.
    /// </summary>
    public class FactContainerWriter<TFactContainer> : IDisposable
        where TFactContainer : IFactContainer
    {
        private const string disposeError = "The current writer has been disposed.";
        private TFactContainer _container;
        private readonly bool _previousValue;
        private bool _disposed;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="container"></param>
        public FactContainerWriter(TFactContainer container)
        {
            _container = container;
            Monitor.Enter(_container);
            _previousValue = _container.IsReadOnly;
            _disposed = false;
        }

        /// <summary>
        /// Adds fact.
        /// </summary>
        /// <param name="fact">Fact.</param>
        /// <typeparam name="TFact">Type of fact to add.</typeparam>
        public void Add<TFact>(TFact fact) 
            where TFact : IFact
        {
            if (_disposed)
                throw new ObjectDisposedException(GetType().Name, disposeError);

            if (_container.IsReadOnly)
                _container.IsReadOnly = false;

            _container.Add(fact);

            if (_previousValue != _container.IsReadOnly)
                _container.IsReadOnly = _previousValue;
        }

        /// <summary>
        /// Adds facts.
        /// </summary>
        /// <param name="facts">Fact set.</param>
        public void AddRange(IEnumerable<IFact> facts)
        {
            if (_disposed)
                throw new ObjectDisposedException(GetType().Name, disposeError);

            if (_container.IsReadOnly)
                _container.IsReadOnly = false;

            _container.AddRange(facts);

            if (_previousValue != _container.IsReadOnly)
                _container.IsReadOnly = _previousValue;
        }

        /// <summary>
        /// Removes fact.
        /// </summary>
        /// <typeparam name="TFact">Type of fact to delete.</typeparam>
        public void Remove<TFact>()
            where TFact : IFact
        {
            if (_disposed)
                throw new ObjectDisposedException(GetType().Name, disposeError);

            if (_container.IsReadOnly)
                _container.IsReadOnly = false;

            _container.Remove<TFact>();

            if (_previousValue != _container.IsReadOnly)
                _container.IsReadOnly = _previousValue;
        }

        /// <summary>
        /// Removes fact.
        /// </summary>
        /// <param name="fact"></param>
        /// <typeparam name="TFact">Type of fact to delete.</typeparam>
        public void Remove<TFact>(TFact fact) where TFact : IFact
        {
            if (_disposed)
                throw new ObjectDisposedException(GetType().Name, disposeError);

            if (_container.IsReadOnly)
                _container.IsReadOnly = false;

            _container.Remove(fact);

            if (_previousValue != _container.IsReadOnly)
                _container.IsReadOnly = _previousValue;
        }

        /// <inheritdoc/>
        public virtual void Dispose()
        {
            if (_disposed)
                return;

            _disposed = true;

            if (_previousValue != _container.IsReadOnly)
                _container.IsReadOnly = _previousValue;

            Monitor.Exit(_container);
            _container = default(TFactContainer);
        }
    }
}
