using System.Collections.Generic;

namespace FactFactory.Entities
{
    internal class FactRuleTree
    {
        internal FactRuleNode Root { get; set; }

        internal List<FactRuleNode> CurrentLevel { get; } = new List<FactRuleNode>();
    }
}
