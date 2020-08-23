using GetcuReone.FactFactory.BaseEntities;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Entities.Trees
{
    /// <summary>
    /// Request to build a trees.
    /// </summary>
    /// <typeparam name="TFactRule"></typeparam>
    /// <typeparam name="TFactRuleCollection"></typeparam>
    /// <typeparam name="TWantAction"></typeparam>
    /// <typeparam name="TFactContainer"></typeparam>
    public class BuildTreesRequest<TFactRule, TFactRuleCollection, TWantAction, TFactContainer>
        where TFactRule : FactRuleBase
        where TFactRuleCollection : FactRuleCollectionBase<TFactRule>
        where TWantAction : WantActionBase
        where TFactContainer : FactContainerBase
    {
        /// <summary>
        /// List of actions for which to build trees.
        /// </summary>
        public List<TWantAction> WantActions { get; set; }

        /// <summary>
        /// A container with facts on which to build trees for <see cref="WantActions"/>.
        /// </summary>
        public TFactContainer Container { get; set; }

        /// <summary>
        /// A collection of rules that will be used to build the tree.
        /// </summary>
        public TFactRuleCollection FactRules { get; set; }
    }
}
