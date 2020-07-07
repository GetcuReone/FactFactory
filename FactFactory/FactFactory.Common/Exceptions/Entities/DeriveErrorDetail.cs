using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Exceptions.Entities
{
    /// <summary>
    /// Detailed information about the calculation error action
    /// </summary>
    public class DeriveErrorDetail<TFact> : ErrorDetail
        where TFact : IFact
    {
        /// <summary>
        /// Action for which it was not possible to derive the facts.
        /// </summary>
        public IWantAction<TFact> RequiredAction { get; }

        /// <summary>
        /// The facts that tried to derive.
        /// </summary>
        public IReadOnlyCollection<DeriveFactErrorDetail> RequiredFacts { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="code">Error code.</param>
        /// <param name="reason">Error reason.</param>
        /// <param name="requiredAction">Action for which it was not possible to derive the facts.</param>
        /// <param name="requiredFacts">The facts that tried to derive.</param>
        public DeriveErrorDetail(string code, string reason, IWantAction<TFact> requiredAction, IReadOnlyCollection<DeriveFactErrorDetail> requiredFacts) : base(code, reason)
        {
            RequiredAction = requiredAction;
            RequiredFacts = requiredFacts;
        }
    }
}
