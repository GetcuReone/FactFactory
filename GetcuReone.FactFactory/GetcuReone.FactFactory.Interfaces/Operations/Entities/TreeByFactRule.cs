using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations.Entities.Enums;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// A tree built by type of fact rule
    /// </summary>
    public class TreeByFactRule
    {
        /// <summary>
        /// Root node
        /// </summary>
        public NodeByFactRule Root { get; set; }

        /// <summary>
        /// Context
        /// </summary>
        public IFactRulesContext Context { get; set; }

        /// <summary>
        /// Information about all the rules that were tested for the ability to use when building a tree
        /// </summary>
        public List<NodeByFactRuleInfo> NodeInfos { get; set; }

        /// <summary>
        /// Tree levels.
        /// </summary>
        public List<List<NodeByFactRule>> Levels { get; set; } = new List<List<NodeByFactRule>>();

        /// <summary>
        /// Tree work status
        /// </summary>
        public TreeStatus Status { get; private set; } = TreeStatus.BeingBuilt;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="root">Root node</param>
        /// <param name="context">Context</param>
        /// <param name="nodeInfos">Information about all the rules that were tested for the ability to use when building a tree</param>
        public TreeByFactRule(NodeByFactRule root, IFactRulesContext context, List<NodeByFactRuleInfo> nodeInfos)
        {
            Root = root;
            Context = context;
            NodeInfos = nodeInfos;
        }

        /// <summary>
        /// Tree built
        /// </summary>
        public void Built()
        {
            Status = TreeStatus.Built;
        }

        /// <summary>
        /// The tree is canceled
        /// </summary>
        public void Cencel()
        {
            foreach (var level in Levels)
                level.Clear();

            Levels.Clear();

            Status = TreeStatus.Cencel;
        }
    }
}
