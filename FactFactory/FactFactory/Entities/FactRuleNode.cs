using ComboPatterns.Interfaces;
using FactFactory.Interfaces;
using System.Collections.Generic;

namespace FactFactory.Entities
{
    internal sealed class FactRuleNode
    {
        internal FactRuleNode Parent { get; set; }

        internal IFactRule FactRule { get; set; }

        internal List<FactRuleNode> Childs { get; } = new List<FactRuleNode>();

        internal bool ExistsBranch(IFactRule factRule)
        {
            if (factRule == FactRule)
                return true;

            return Parent?.ExistsBranch(factRule) ?? false;
        }
    }
}
