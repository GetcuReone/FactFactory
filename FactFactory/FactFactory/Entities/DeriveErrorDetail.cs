using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Entities
{
    /// <summary>
    /// Error detail for method <see cref="FactFactoryBase{TFactContainer, TFactRule, TFactRuleCollection, TWantAction}.Derive"/>
    /// </summary>
    public sealed class DeriveErrorDetail : ErrorDetail
    {
        /// <inheritdoc />
        public DeriveErrorDetail(string code, string reason, IWantAction action, Dictionary<IFactType, List<List<IFactType>>> notFoundFacts) : base(code, reason)
        {
            Action = action;
            NotFoundFacts = notFoundFacts;
        }

        /// <summary>
        /// The action, the calculation of which led to an error
        /// </summary>
        public IWantAction Action { get; }

        /// <summary>
        /// The sets of facts which were not enough to calculate. The presence of any of these sets allows you to calculate <see cref="DeriveErrorDetail.Action"/>
        /// </summary>
        public Dictionary<IFactType, List<List<IFactType>>> NotFoundFacts { get; }
    }
}
