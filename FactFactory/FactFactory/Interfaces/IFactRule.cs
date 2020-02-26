using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Rule of fact calculation.
    /// </summary>
    /// <typeparam name="TFact">The type of fact from which the facts in the container should be inherited.</typeparam>
    /// <typeparam name="TFactContainer">The type of container that will be input to the rule.</typeparam>
    public interface IFactRule<TFact, TFactContainer>
        where TFact : IFact
        where TFactContainer : IFactContainer<TFact>
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
        bool CanCalculate<TContainer>(TContainer container) where TContainer : TFactContainer;

        /// <summary>
        /// Rule of fact calculate.
        /// </summary>
        /// <param name="container"></param>
        /// <typeparam name="TContainer"></typeparam>
        /// <returns></returns>
        TFact Calculate<TContainer>(TContainer container) where TContainer : TFactContainer;

        /// <summary>
        /// Compare rules.
        /// </summary>
        /// <typeparam name="TFactRule"></typeparam>
        /// <param name="factRule"></param>
        /// <returns></returns>
        bool Compare<TFactRule>(TFactRule factRule) where TFactRule : IFactRule<TFact, TFactContainer>;
    }
}
