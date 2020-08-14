using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Entities.Trees
{
    /// <summary>
    /// Node.
    /// </summary>
    /// <typeparam name="TFactRule"></typeparam>
    public class NodeByFactRule<TFactRule>
        where TFactRule : IFactRule
    {
        /// <summary>
        /// Parent node.
        /// </summary>
        public NodeByFactRule<TFactRule> Parent { get; set; }

        /// <summary>
        /// Childs node.
        /// </summary>
        public List<NodeByFactRule<TFactRule>> Childs { get; set; }

        /// <summary>
        /// Node info.
        /// </summary>
        public NodeInfoByFactRyle<TFactRule> Info { get; set; }
    }
}
