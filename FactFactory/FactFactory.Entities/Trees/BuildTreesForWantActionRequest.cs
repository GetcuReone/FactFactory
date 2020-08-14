using GetcuReone.FactFactory.BaseEntities;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Entities.Trees
{
    /// <summary>
    /// Request to build a trees for WantAction.
    /// </summary>
    public class BuildTreesForWantActionRequest<TFactRule, TWantAction, TFactContainer>
        where TFactRule : FactRuleBase
        where TWantAction : WantActionBase
        where TFactContainer : FactContainerBase
    {
        /// <summary>
        /// WantAction for which you need to build an action.
        /// </summary>
        public WantActionInfo<TWantAction, TFactContainer> WantActionInfo { get; set; }

        /// <summary>
        /// A collection of rules that will be used to build the tree.
        /// </summary>
        public List<TFactRule> FactRules { get; set; }
    }
}
