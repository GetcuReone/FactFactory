using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Node.
    /// </summary>
    public class NodeByFactRule
    {
        /// <summary>
        /// Parent node.
        /// </summary>
        public NodeByFactRule Parent { get; set; }

        /// <summary>
        /// Childs node.
        /// </summary>
        public List<NodeByFactRule> Childs { get; set; }

        /// <summary>
        /// Node info.
        /// </summary>
        public NodeByFactRuleInfo Info { get; set; }
    }
}
