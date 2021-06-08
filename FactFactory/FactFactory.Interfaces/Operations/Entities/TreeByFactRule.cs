using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations.Entities.Enums;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// A tree built by type of fact rule.
    /// </summary>
    /// <typeparam name="TFactRule">Rule type.</typeparam>
    /// <typeparam name="TWantAction">WantAction type.</typeparam>
    /// <typeparam name="TFactContainer">Fact container type.</typeparam>
    public class TreeByFactRule<TFactRule, TWantAction, TFactContainer>
        where TFactRule : IFactRule
        where TWantAction : IWantAction
        where TFactContainer : IFactContainer
    {
        /// <summary>
        /// Root node.
        /// </summary>
        public NodeByFactRule<TFactRule> Root { get; set; }

        /// <summary>
        /// Context.
        /// </summary>
        public IFactRulesContext<TFactRule, TWantAction, TFactContainer> Context { get; set; }

        /// <summary>
        /// Information about all the rules that were tested for the ability to use when building a tree.
        /// </summary>
        public List<NodeByFactRuleInfo<TFactRule>> NodeInfos { get; set; }

        /// <summary>
        /// Tree levels.
        /// </summary>
        public List<List<NodeByFactRule<TFactRule>>> Levels { get; set; }

        /// <summary>
        /// Tree work status.
        /// </summary>
        public TreeStatus Status { get; private set; } = TreeStatus.BeingBuilt;

        /// <summary>
        /// Tree built.
        /// </summary>
        public void Built()
        {
            Status = TreeStatus.Built;
        }

        /// <summary>
        /// The tree is canceled.
        /// </summary>
        public void Cencel()
        {
            Root = null;

            foreach (var level in Levels)
                level.Clear();

            Levels.Clear();

            Status = TreeStatus.Cencel;
        }
    }
}
