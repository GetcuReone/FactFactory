using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Node info
    /// </summary>
    public class NodeByFactRuleInfo
    {
        /// <summary>
        /// Rule
        /// </summary>
        public IFactRule Rule { get; }

        /// <summary>
        /// List of successfully <see cref="IBuildConditionFact"/>. Successfully completed conditions for <see cref="Rule"/>
        /// </summary>
        public List<IBuildConditionFact> BuildSuccessConditions { get; set; } = new List<IBuildConditionFact>();

        /// <summary>
        /// List of failed <see cref="IBuildConditionFact"/>. Failed conditions for <see cref="Rule"/>
        /// </summary>
        public List<IBuildConditionFact> BuildFailedConditions { get; set; } = new List<IBuildConditionFact>();

        /// <summary>
        /// List of <see cref="IRuntimeConditionFact"/>
        /// </summary>
        public List<IRuntimeConditionFact> RuntimeConditions { get; set; } = new List<IRuntimeConditionFact>();

        /// <summary>
        /// Required fact types
        /// </summary>
        public List<IFactType> RequiredFactTypes { get; set; } = new List<IFactType>();

        /// <summary>
        /// Compatible rules
        /// </summary>
        public IFactRuleCollection? CompatibleRules { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="rule">Rule</param>
        public NodeByFactRuleInfo(IFactRule rule)
        {
            Rule = rule;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "Info <" + Rule.ToString() + ">";
        }
    }
}
