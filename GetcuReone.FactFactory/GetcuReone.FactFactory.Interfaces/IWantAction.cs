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

        /// <summary>
        /// Adds a rule used to calculate the fact.
        /// </summary>
        /// <param name="rule">Fact rule.</param>
        void AddUsedRule(IFactRule rule);

        /// <summary>
        /// Returns the rules used to calculate facts.
        /// </summary>
        /// <returns>Rules used to calculate facts.</returns>
        IEnumerable<IFactRule> GetUsedRules();
    }
}
