using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Rule of fact calculation.
    /// </summary>
    public interface IFactRule : IFactWork
    {
        /// <summary>
        /// Information on output fact.
        /// </summary>
        IFactType OutputFactType { get; }

        /// <summary>
        /// Is it possible to calculate the fact.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="wantAction"></param>
        /// <typeparam name="TContainer"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <returns></returns>
        bool CanCalculate<TContainer, TWantAction>(TContainer container, TWantAction wantAction) 
            where TContainer : IFactContainer
            where TWantAction : IWantAction;

        /// <summary>
        /// Rule of fact calculate.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="wantAction"></param>
        /// <typeparam name="TContainer"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <returns></returns>
        IFact Calculate<TContainer, TWantAction>(TContainer container, TWantAction wantAction) 
            where TContainer : IFactContainer
            where TWantAction : IWantAction;

        /// <summary>
        /// Calculate fact.
        /// </summary>
        /// <param name="requireFacts">The facts required for the calculation.</param>
        /// <returns></returns>
        IFact Calculate(IEnumerable<IFact> requireFacts);

        /// <summary>
        /// Get the necessary fact types.
        /// </summary>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="wantAction"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        List<IFactType> GetNecessaryFactTypes<TWantAction, TFactContainer>(TWantAction wantAction, TFactContainer container)
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;
    }
}
