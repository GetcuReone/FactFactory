using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Container interface with facts for deriving other facts.
    /// </summary>
    /// <typeparam name="TFactBase">The type from which all facts in this container should be inherited.</typeparam>
    public interface IFactContainer<TFactBase> : IEnumerable<TFactBase>
        where TFactBase : IFact
    {
        /// <summary>
        /// Gets a value indicating whether the <see cref="IFactContainer{TFact}"/> is read-only.
        /// </summary>
        bool IsReadOnly { get; }
        /// <summary>
        /// Add fact.
        /// </summary>
        /// <param name="fact">Fact.</param>
        /// <typeparam name="TFact">Type of fact to add.</typeparam>
        void Add<TFact>(TFact fact) where TFact : TFactBase;

        /// <summary>
        /// Remove fact.
        /// </summary>
        /// <typeparam name="TFact">Type of fact to delete.</typeparam>
        void Remove<TFact>() where TFact : TFactBase;

        /// <summary>
        /// Remove fact.
        /// </summary>
        /// <param name="fact"></param>
        /// <typeparam name="TFact">Type of fact to delete.</typeparam>
        void Remove<TFact>(TFact fact) where TFact : TFactBase;

        /// <summary>
        /// Try get fact.
        /// </summary>
        /// <typeparam name="TFact">Type of fact to return.</typeparam>
        /// <param name="fact"></param>
        /// <returns></returns>
        bool TryGetFact<TFact>(out TFact fact) where TFact : TFactBase;

        /// <summary>
        /// Get fact.
        /// </summary>
        /// <typeparam name="TFact">Type of fact to return.</typeparam>
        /// <returns></returns>
        TFact GetFact<TFact>() where TFact : TFactBase;

        /// <summary>
        /// Is this type of fact contained.
        /// </summary>
        /// <typeparam name="TFact">type of fact to check for.</typeparam>
        /// <returns></returns>
        bool Contains<TFact>() where TFact : TFactBase;

        /// <summary>
        /// Clear this container.
        /// </summary>
        void Clear();
    }
}
