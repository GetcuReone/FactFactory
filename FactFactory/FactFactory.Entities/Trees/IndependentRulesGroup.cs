using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Entities.Trees
{
    /// <summary>
    /// Independent Rules Group.
    /// </summary>
    public class IndependentRulesGroup<TFactRule> : List<NodeByFactRule<TFactRule>>
        where TFactRule : IFactRule
    {
    }
}
