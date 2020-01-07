using System.Collections.Generic;

namespace FactFactory.Entities
{
    /// <summary>
    /// Collection fo <see cref="FactRule"/>
    /// </summary>
    public class FactRuleCollection: List<FactRule>
    {
        /// <inheritdoc />
        public FactRuleCollection() { }

        /// <inheritdoc />
        public FactRuleCollection(IList<FactRule> factRules) : base(factRules) { }
    }
}
