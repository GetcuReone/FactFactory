using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Rule of fact calculation.
    /// </summary>
    public interface IFactRule : IFactWork
    {
        /// <summary>
        /// Information on output fact.
        /// </summary>
        IFactType OutputFactType { get; }

        /// <summary>
        /// Calculate fact.
        /// </summary>
        /// <param name="requireFacts">The facts required for the calculation.</param>
        /// <returns></returns>
        IFact Calculate(IEnumerable<IFact> requireFacts);
    }
}
