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
        /// Facts Required to Launch an Action
        /// </summary>
        IEnumerable<IFactType> InputFactTypes { get; }

        /// <summary>
        /// Start date for fact finding for action
        /// </summary>
        DateTime DateOfDerive { get; set; }

        /// <summary>
        /// Run actioin
        /// </summary>
        /// <typeparam name="TFactContainer">container with <see cref="InputFactTypes"/></typeparam>
        /// <param name="container"></param>
        void Invoke<TFactContainer>(TFactContainer container) where TFactContainer : IFactContainer;
    }
}
