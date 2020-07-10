using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Entities.Trees
{
    /// <summary>
    /// Node.
    /// </summary>
    /// <typeparam name="TFactBase"></typeparam>
    /// <typeparam name="TFactRule"></typeparam>
    public class NodeByFactRule<TFactBase, TFactRule>
        where TFactBase : IFact
        where TFactRule : IFactRule<TFactBase>
    {
        /// <summary>
        /// Parent node.
        /// </summary>
        public NodeByFactRule<TFactBase, TFactRule> Parent { get; set; }

        /// <summary>
        /// Childs node.
        /// </summary>
        public List<NodeByFactRule<TFactBase, TFactRule>> Childs { get; set; }

        /// <summary>
        /// Node info.
        /// </summary>
        public NodeInfoByFactRyle<TFactBase, TFactRule> Info { get; set; }
    }
}
