using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Container interface with facts for deriving other facts
    /// </summary>
    public interface IFactContainer : IEnumerable<IFact>
    {
        /// <summary>
        /// Add fact
        /// </summary>
        /// <typeparam name="TFact">type fact</typeparam>
        /// <param name="fact">fact</param>
        void Add<TFact>(TFact fact) where TFact : IFact;

        /// <summary>
        /// Remove fact
        /// </summary>
        /// <typeparam name="TFact">type fact</typeparam>
        void Remove<TFact>() where TFact : IFact;

        /// <summary>
        /// Remove fact
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <param name="fact"></param>
        void Remove<TFact>(TFact fact) where TFact : IFact;

        /// <summary>
        /// Try get fact
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <param name="fact"></param>
        /// <returns></returns>
        bool TryGetFact<TFact>(out TFact fact) where TFact : IFact;

        /// <summary>
        /// Get fact
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <returns></returns>
        TFact GetFact<TFact>() where TFact : IFact;

        /// <summary>
        /// Is this type of fact contained
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <returns></returns>
        bool Contains<TFact>() where TFact : IFact;
    }
}
