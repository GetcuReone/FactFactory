using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.InnerEntities
{
    internal sealed class FactRuleNode<TFact, TFactRule>
        where TFact : IFact
        where TFactRule : IFactRule<TFact>
    {
        internal FactRuleNode<TFact, TFactRule> Parent { get; set; }

        internal TFactRule FactRule { get; set; }

        internal List<FactRuleNode<TFact, TFactRule>> Childs { get; } = new List<FactRuleNode<TFact, TFactRule>>();

        internal bool ExistsBranch(TFactRule rule)
        {
            if (rule == null && FactRule == null)
                return true;
            else if (rule == null || FactRule == null)
                return false;
            else if (rule.Equals(FactRule))
                return true;

            else if (Parent != null)
                return Parent.ExistsBranch(rule);

            return false;
        }
    }
}
