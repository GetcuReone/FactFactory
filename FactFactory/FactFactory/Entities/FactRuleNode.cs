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

        internal void Derive(IAbstractFactory factory, IFactContainer container)
        {
            foreach (FactRuleNode child in Childs)
                child.Derive(factory, container);

            if (!FactRule.OutputFactInfo.ContainsContainer(container))
                container.Add(
                    factory.CreateObject(ct => FactRule.Derive(container), container));
        }

        internal bool ExistsBranch(IFactRule factRule)
        {
            if (factRule == FactRule)
                return true;

            return Parent?.ExistsBranch(factRule) ?? false;
        }
    }
}
