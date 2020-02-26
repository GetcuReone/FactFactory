using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Entities
{
    /// <summary>
    /// Error detail for method <see cref="FactFactoryBase{TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction}.Derive"/>
    /// </summary>
    public sealed class DeriveErrorDetail<TFcat, TWantAction> : ErrorDetail
        where TFcat : IFact
        where TWantAction : IWantAction<TFcat>
    {
        /// <inheritdoc />
        public DeriveErrorDetail(string code, string reason, TWantAction action, Dictionary<IFactType, List<List<IFactType>>> notFoundFacts) : base(code, reason)
        {
            Action = action;
            NotFoundFacts = notFoundFacts;
        }

        /// <summary>
        /// The action, the calculation of which led to an error
        /// </summary>
        public TWantAction Action { get; }

        /// <summary>
        /// The sets of facts which were not enough to calculate. The presence of any of these sets allows you to calculate <see cref="DeriveErrorDetail{TFcat, TWantAction}.Action"/>
        /// </summary>
        public Dictionary<IFactType, List<List<IFactType>>> NotFoundFacts { get; }
    }
}
