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
        IReadOnlyCollection<IFactType> InpuTFactTypes { get; }

        /// <summary>
        /// Rule exit information
        /// </summary>
        IFactType OutpuTFactType { get; }

        /// <summary>
        /// is it possible to derive the fact
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        bool CanDerive<TFactContainer>(TFactContainer container) where TFactContainer : IFactContainer;

        /// <summary>
        /// Rule of fact derive
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        IFact Derive<TFactContainer>(TFactContainer container) where TFactContainer : IFactContainer;

        /// <summary>
        /// Compare rules
        /// </summary>
        /// <typeparam name="TFactRule"></typeparam>
        /// <param name="factRule"></param>
        /// <returns></returns>
        bool Compare<TFactRule>(TFactRule factRule) where TFactRule : IFactRule;
    }
}
