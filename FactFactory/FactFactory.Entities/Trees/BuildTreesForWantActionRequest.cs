using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Entities.Trees
{
    /// <summary>
    /// Request to build a trees for WantAction.
    /// </summary>
    public class BuildTreesForWantActionRequest<TFactBase, TFactRule, TWantAction, TFactContainer>
        where TFactBase : IFact
        where TFactRule : FactRuleBase<TFactBase>
        where TWantAction : WantActionBase<TFactBase>
        where TFactContainer : FactContainerBase<TFactBase>
    {
        /// <summary>
        /// WantAction for which you need to build an action.
        /// </summary>
        public TWantAction WantAction { get; set; }

        /// <summary>
        /// A container with facts on which to build trees for <see cref="WantAction"/>.
        /// </summary>
        public TFactContainer Container { get; set; }

        /// <summary>
        /// A collection of rules that will be used to build the tree.
        /// </summary>
        public List<TFactRule> FactRules { get; set; }
    }
}
