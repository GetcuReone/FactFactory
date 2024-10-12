using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Exceptions.Entities
{
    /// <summary>
    /// Detailed information about the calculation error action.
    /// </summary>
    public class DeriveErrorDetail : ErrorDetail
    {
        /// <summary>
        /// Action for which it was not possible to derive the facts.
        /// </summary>
        public IWantAction RequiredAction { get; }

        /// <summary>
        /// The container that was used for <see cref="RequiredAction"/>.
        /// </summary>
        public IFactContainer Container { get; }

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
        /// <param name="container"></param>
        /// <param name="requiredFacts">The facts that tried to derive.</param>
        public DeriveErrorDetail(string code, string reason, IWantAction requiredAction, IFactContainer container, IReadOnlyCollection<DeriveFactErrorDetail> requiredFacts) 
            : base(code, reason)
        {
            RequiredAction = requiredAction;
            RequiredFacts = requiredFacts;
            Container = container;
        }
    }
}
