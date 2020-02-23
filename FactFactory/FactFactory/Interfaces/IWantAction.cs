using System;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Desired action information
    /// </summary>
    public interface IWantAction
    {
        /// <summary>
        /// Facts required to launch an action
        /// </summary>
        IEnumerable<IFactType> InputFactTypes { get; }

        /// <summary>
        /// Start date for fact deriving for action
        /// </summary>
        DateTime DateOfDerive { get; set; }

        /// <summary>
        /// Run action
        /// </summary>
        /// <typeparam name="TFactContainer">container with <see cref="InputFactTypes"/></typeparam>
        /// <param name="container"></param>
        void Invoke<TFactContainer>(TFactContainer container) where TFactContainer : IFactContainer;
    }
}
