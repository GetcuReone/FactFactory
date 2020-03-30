using GetcuReone.FactFactory.InnerEntities.Enums;
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
        internal TreeStatus Status { get; private set; } = TreeStatus.BeingBuilt;
        internal List<TFactRule> ContainedRules { get; } = new List<TFactRule>();

        internal void Built()
        {
            Status = TreeStatus.Built;
        }

        internal void Cencel()
        {
            Root = null;

            foreach (var level in Levels)
                level.Clear();

            Levels.Clear();
            ContainedRules.Clear();

            Status = TreeStatus.Cencel;
        }
    }
}
