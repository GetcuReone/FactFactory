using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Desired action information.
    /// </summary>
    public interface IWantAction: IFactWork
    {
        /// <summary>
        /// Run action.
        /// </summary>
        /// <typeparam name="TFactContainer">container with <see cref="IFactWork.InputFactTypes"/>.</typeparam>
        /// <param name="container"></param>
        void Invoke<TFactContainer>(TFactContainer container) where TFactContainer : IFactContainer;

        /// <summary>
        /// Run action.
        /// </summary>
        /// <param name="requireFacts">The facts required for run.</param>
        void Invoke(IEnumerable<IFact> requireFacts);

        /// <summary>
        /// Get the necessary fact types.
        /// </summary>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        List<IFactType> GetNecessaryFactTypes<TFactContainer>(TFactContainer container) where TFactContainer : IFactContainer;
    }
}
