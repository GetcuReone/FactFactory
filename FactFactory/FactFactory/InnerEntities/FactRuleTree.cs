using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.InnerEntities
{
    internal sealed class FactRuleTree<TFact, TFactRule>
        where TFact : IFact
        where TFactRule : IFactRule<TFact>
    {
        internal FactRuleNode<TFact, TFactRule> Root { get; set; }
        internal List<List<FactRuleNode<TFact, TFactRule>>> Levels { get; } = new List<List<FactRuleNode<TFact, TFactRule>>>();
    }
}
