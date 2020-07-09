using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Entities.Trees
{
    /// <summary>
    /// Node info.
    /// </summary>
    public class NodeInfoByFactRyle<TFactBase, TFactRule>
        where TFactBase : IFact
        where TFactRule : IFactRule<TFactBase>
    {
        /// <summary>
        /// Rule.
        /// </summary>
        public TFactRule Rule { get; set; }

        /// <summary>
        /// ConditionFacts for <see cref="Rule"/>.
        /// </summary>
        public List<IConditionFact> ConditionFacts { get; set; }

        /// <summary>
        /// Fact rules for <see cref="Rule"/>.
        /// </summary>
        public List<TFactRule> FactRules { get; set; }
    }
}
