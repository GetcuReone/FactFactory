using GetcuReone.FactFactory.Entities.Trees.Enums;
using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Entities.Trees
{
    /// <summary>
    /// A tree built by type of fact rule.
    /// </summary>
    public class TreeByFactRule<TFactBase, TFactRule>
        where TFactBase : IFact
        where TFactRule : IFactRule<TFactBase>
    {
        /// <summary>
        /// Root node.
        /// </summary>
        public NodeByFactRule<TFactBase, TFactRule> Root { get; set; }

        /// <summary>
        /// Information about all the rules that were tested for the ability to use when building a tree.
        /// </summary>
        public List<NodeInfoByFactRyle<TFactBase, TFactRule>> NodeInfos { get; set; }

        /// <summary>
        /// Tree levels.
        /// </summary>
        public List<List<NodeByFactRule<TFactBase, TFactRule>>> Levels { get; set; }

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
