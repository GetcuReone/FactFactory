using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Rule of fact calculation.
    /// </summary>
    /// <typeparam name="TFact">The type of fact from which the facts in the container should be inherited.</typeparam>
    public interface IFactRule<TFact>
        where TFact : IFact
    {
        /// <summary>
        /// Information on input factacles rules.
        /// </summary>
        IReadOnlyCollection<IFactType> InputFactTypes { get; }

        /// <summary>
        /// Information on output fact.
        /// </summary>
        IFactType OutputFactType { get; }

        /// <summary>
        /// is it possible to calculate the fact.
        /// </summary>
        /// <param name="container"></param>
        /// <typeparam name="TContainer"></typeparam>
        /// <returns></returns>
        bool CanCalculate<TContainer>(TContainer container) where TContainer : IFactContainer<TFact>;

        /// <summary>
        /// Rule of fact calculate.
        /// </summary>
        /// <param name="container"></param>
        /// <typeparam name="TContainer"></typeparam>
        /// <returns></returns>
        TFact Calculate<TContainer>(TContainer container) where TContainer : IFactContainer<TFact>;

        /// <summary>
        /// Compare rules.
        /// </summary>
        /// <typeparam name="TFactRule"></typeparam>
        /// <param name="factRule"></param>
        /// <returns></returns>
        bool Compare<TFactRule>(TFactRule factRule) where TFactRule : IFactRule<TFact>;
    }
}
