using FactFactory.Exceptions;
using FactFactory.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FactFactory.Entities
{
    /// <summary>
    /// Fact collection
    /// </summary>
    public class FactContainer : IFactContainer
    {
        private readonly List<IFact> _container;

        /// <summary>
        /// Constructor
        /// </summary>
        public FactContainer()
        {
            _container = new List<IFact>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public FactContainer(IEnumerable<IFact> facts)
        {
            _container = new List<IFact>(facts);
        }

        /// <summary>
        /// Add fact
        /// </summary>
        /// <typeparam name="TFact">type fact</typeparam>
        /// <param name="fact">fact</param>
        public void Add<TFact>(TFact fact)
            where TFact: IFact
        {
            var factInfo = fact.GetFactInfo();

            if (this.Any(f => f.GetFactInfo().Compare(factInfo)))
                throw new ArgumentException($"The fact container already contains {typeof(TFact).FullName} type of fact");

            _container.Add(fact);
        }

        /// <summary>
        /// Remove fact
        /// </summary>
        /// <typeparam name="TFact">type fact</typeparam>
        public void Remove<TFact>(TFact fact)
            where TFact : IFact
        {
            _container.Remove(fact);
        }

        /// <summary>
        /// Remove fact
        /// </summary>
        /// <typeparam name="TFact">type fact</typeparam>
        public void Remove<TFact>()
            where TFact : IFact
        {
            _container.RemoveAll(fact => fact is TFact);
        }

        /// <summary>
        /// Try get fact
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <param name="fact"></param>
        /// <returns></returns>
        public bool TryGetFact<TFact>(out TFact fact)
            where TFact: IFact
        {
            IFact innerFact = _container.SingleOrDefault(item => item is TFact);

            if (innerFact == null)
            {
                fact = default;
                return false;
            }
            else
            {
                fact = (TFact)innerFact;
                return true;
            }
        }

        /// <summary>
        /// Get fact
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <returns></returns>
        public TFact GetFact<TFact>()
            where TFact : IFact
        {
            if (TryGetFact<TFact>(out var fact))
            {
                return fact;
            }

            throw new FactNotFoundException<TFact>();
        }

        /// <summary>
        /// Is this type of fact contained
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <returns></returns>
        public bool Contains<TFact>()
            where TFact : IFact
        {
            var factInfo = new FactInfo<TFact>();
            return this.Any(fact => fact.GetFactInfo().Compare(factInfo));
        }

        /// <inheritdoc />
        public IEnumerator<IFact> GetEnumerator()
        {
            return _container.GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _container.GetEnumerator();
        }
    }
}
