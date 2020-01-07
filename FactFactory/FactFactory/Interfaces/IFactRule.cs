using System;
using System.Collections.Generic;

namespace FactFactory.Interfaces
{
    /// <summary>
    /// Rule of fact derivation
    /// </summary>
    public interface IFactRule
    {
        /// <summary>
        /// Information on input factacles rules
        /// </summary>
        IReadOnlyCollection<IFactInfo> InputFactInfos { get; }

        /// <summary>
        /// Rule exit information
        /// </summary>
        IFactInfo OutputFactInfo { get; }

        /// <summary>
        /// is it possible to derive the fact
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        bool IsCanDerive(IFactContainer container);

        /// <summary>
        /// Rule of fact derive
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        IFact Derive(IFactContainer container);
    }
}
