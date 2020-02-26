using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Container interface with facts for deriving other facts
    /// </summary>
    /// <typeparam name="TFact">The type from which all facts in this container should be inherited</typeparam>
    public interface IFactContainer<TFact> : IEnumerable<TFact>
        where TFact : IFact
    {
        /// <summary>
        /// Add fact
        /// </summary>
        /// <param name="fact">fact</param>
        void Add(TFact fact);

        /// <summary>
        /// Remove fact
        /// </summary>
        /// <typeparam name="TRemoveFact">Type of fact to delete</typeparam>
        void Remove<TRemoveFact>() where TRemoveFact : TFact;

        /// <summary>
        /// Remove fact
        /// </summary>
        /// <param name="fact"></param>
        void Remove(TFact fact);

        /// <summary>
        /// Try get fact
        /// </summary>
        /// <typeparam name="TGetFact">Type of fact to return</typeparam>
        /// <param name="fact"></param>
        /// <returns></returns>
        bool TryGetFact<TGetFact>(out TGetFact fact) where TGetFact : TFact;

        /// <summary>
        /// Get fact
        /// </summary>
        /// <typeparam name="TGetFact">Type of fact to return</typeparam>
        /// <returns></returns>
        TGetFact GetFact<TGetFact>() where TGetFact : TFact;

        /// <summary>
        /// Is this type of fact contained
        /// </summary>
        /// <typeparam name="TContainsFact">type of fact to check for</typeparam>
        /// <returns></returns>
        bool Contains<TContainsFact>() where TContainsFact : TFact;
    }
}
