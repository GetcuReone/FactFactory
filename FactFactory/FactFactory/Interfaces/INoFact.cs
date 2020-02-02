﻿namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Not calculated fact
    /// </summary>
    public interface INoFact : IFact
    {
        /// <summary>
        /// Information about a fact that cannot be calculated
        /// </summary>
        IFactType Value { get; }
    }
}
