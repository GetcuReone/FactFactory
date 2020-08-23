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
        /// Get the necessary fact types.
        /// </summary>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        List<IFactType> GetNecessaryFactTypes<TFactContainer>(TFactContainer container) where TFactContainer : IFactContainer;
    }
}
