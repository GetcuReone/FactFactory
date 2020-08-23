using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Node info.
    /// </summary>
    public class NodeByFactRuleInfo<TFactRule>
        where TFactRule : IFactRule
    {
        /// <summary>
        /// Rule.
        /// </summary>
        public TFactRule Rule { get; set; }

        /// <summary>
        /// List of fact conditions. Successfully completed conditions for <see cref="Rule"/>.
        /// </summary>
        public List<IConditionFact> SuccessConditions { get; set; }

        /// <summary>
        /// List of fact conditions. Failed conditions for <see cref="Rule"/>.
        /// </summary>
        public List<IConditionFact> FailedConditions { get; set; }

        /// <summary>
        /// Fact rules for <see cref="Rule"/>.
        /// </summary>
        public List<TFactRule> FactRules { get; set; }
    }
}
