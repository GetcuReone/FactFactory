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
        /// <param name="requireFacts">The facts required for run.</param>
        void Invoke(IEnumerable<IFact> requireFacts);
    }
}
