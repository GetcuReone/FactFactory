using System.Collections.Generic;
using System.Threading.Tasks;

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

        /// <summary>
        /// Async run action.
        /// </summary>
        /// <param name="requireFacts">The facts required for run.</param>
        ValueTask InvokeAsync(IEnumerable<IFact> requireFacts);
    }
}
