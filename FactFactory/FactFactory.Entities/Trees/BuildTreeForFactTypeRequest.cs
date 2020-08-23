using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Entities.Trees
{
    /// <summary>
    /// Request to build a trees for FactType.
    /// </summary>
    /// <typeparam name="TFactRule"></typeparam>
    /// <typeparam name="TWantAction"></typeparam>
    /// <typeparam name="TFactContainer"></typeparam>
    public class BuildTreeForFactTypeRequest<TFactRule, TWantAction, TFactContainer>
        where TFactRule : FactRuleBase
        where TWantAction : WantActionBase
        where TFactContainer : FactContainerBase
    {
        /// <summary>
        /// The type of fact for which you want to build a tree.
        /// </summary>
        public IFactType WantFactType { get; set; }

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
