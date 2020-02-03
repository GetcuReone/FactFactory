using System;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Rule of fact derivation
    /// </summary>
    public interface IFactRule
    {
        /// <summary>
        /// Information on input factacles rules
        /// </summary>
        IReadOnlyCollection<IFactType> InputFactTypes { get; }

        /// <summary>
        /// Rule exit information
        /// </summary>
        IFactType OutputFactType { get; }

        /// <summary>
        /// is it possible to derive the fact
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        bool CanDerive<TFactContainer>(TFactContainer container) where TFactContainer : IFactContainer;

        /// <summary>
        /// Rule of fact calculate
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        IFact Calculate<TFactContainer>(TFactContainer container) where TFactContainer : IFactContainer;

        /// <summary>
        /// Compare rules
        /// </summary>
        /// <typeparam name="TFactRule"></typeparam>
        /// <param name="factRule"></param>
        /// <returns></returns>
        bool Compare<TFactRule>(TFactRule factRule) where TFactRule : IFactRule;
    }
}
