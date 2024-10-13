using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Exceptions.Entities
{
    /// <summary>
    /// Detailed fact calculation error information
    /// </summary>
    public class DeriveFactErrorDetail
    {
        /// <summary>
        /// Contsructor.
        /// </summary>
        /// <param name="requiredFact">The fact that tried to derive.</param>
        /// <param name="needFacts">Facts that were not enough to derive.</param>
        public DeriveFactErrorDetail(IFactType requiredFact, IReadOnlyCollection<IFactType>? needFacts)
        {
            RequiredFact = requiredFact;
            NeedFacts = needFacts;
        }

        /// <summary>
        /// The fact that tried to derive.
        /// </summary>
        public IFactType RequiredFact { get; }

        /// <summary>
        /// Facts that were not enough to derive.
        /// </summary>
        public IReadOnlyCollection<IFactType>? NeedFacts { get; }
    }
}
