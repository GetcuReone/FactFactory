using System;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Entities
{
    internal class FactRuleTree
    {
        internal FactRuleNode Root { get; set; }
        internal List<List<FactRuleNode>> Levels { get; } = new List<List<FactRuleNode>>();
    }
}
