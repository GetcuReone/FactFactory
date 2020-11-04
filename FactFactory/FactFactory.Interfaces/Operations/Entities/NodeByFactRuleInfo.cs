using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System.Collections.Generic;

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
        /// Required fact types.
        /// </summary>
        public List<IFactType> RequiredFactTypes { get; set; }

        /// <summary>
        /// Compatible rules.
        /// </summary>
        public List<TFactRule> CompatibleRules { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "Info <" + Rule.ToString() + ">";
        }
    }
}
