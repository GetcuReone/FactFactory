using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Desired action information.
    /// </summary>
    /// <typeparam name="TFactBase"></typeparam>
    public interface IWantAction<TFactBase> : IFactWork<TFactBase>
        where TFactBase : IFact
    {
        /// <summary>
        /// Run action.
        /// </summary>
        /// <typeparam name="TFactContainer">container with <see cref="IFactWork{TFactBase}.InputFactTypes"/>.</typeparam>
        /// <param name="container"></param>
        void Invoke<TFactContainer>(TFactContainer container) where TFactContainer : IFactContainer<TFactBase>;

        /// <summary>
        /// Get the necessary fact types.
        /// </summary>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        List<IFactType> GetNecessaryFactTypes<TFactContainer>(TFactContainer container)
            where TFactContainer : IFactContainer<TFactBase>;
    }
}
