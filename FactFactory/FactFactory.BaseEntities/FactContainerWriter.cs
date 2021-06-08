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

        /// <summary>
        /// Adds fact.
        /// </summary>
        /// <param name="fact">Fact.</param>
        /// <typeparam name="TFact">Type of fact to add.</typeparam>
        public void Add<TFact>(TFact fact) 
            where TFact : IFact
        {
            _container.Add(fact);
        }

        /// <summary>
        /// Adds facts.
        /// </summary>
        /// <param name="facts">Fact set.</param>
        public void AddRange(IEnumerable<IFact> facts)
        {
            _container.AddRange(facts);
        }

        /// <summary>
        /// Removes fact.
        /// </summary>
        /// <typeparam name="TFact">Type of fact to delete.</typeparam>
        public void Remove<TFact>()
            where TFact : IFact
        {
            _container.Remove<TFact>();
        }

        /// <summary>
        /// Removes fact.
        /// </summary>
        /// <param name="fact"></param>
        /// <typeparam name="TFact">Type of fact to delete.</typeparam>
        public void Remove<TFact>(TFact fact) where TFact : IFact
        {
            _container.Remove(fact);
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
