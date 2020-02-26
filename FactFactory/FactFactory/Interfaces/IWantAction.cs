using System;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Desired action information.
    /// </summary>
    /// <typeparam name="TFact"></typeparam>
    public interface IWantAction<TFact>
        where TFact : IFact
    {
        /// <summary>
        /// Facts required to launch an action.
        /// </summary>
        IReadOnlyCollection<IFactType> InputFactTypes { get; }

        /// <summary>
        /// Run action.
        /// </summary>
        /// <typeparam name="TFactContainer">container with <see cref="InputFactTypes"/>.</typeparam>
        /// <param name="container"></param>
        void Invoke<TFactContainer>(TFactContainer container) where TFactContainer : IFactContainer<TFact>;
    }
}
