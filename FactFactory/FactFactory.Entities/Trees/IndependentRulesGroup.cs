using GetcuReone.FactFactory.Entities.Trees;
using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Entities.Trees
{
    /// <summary>
    /// Independent Rules Group.
    /// </summary>
    public class IndependentRulesGroup<TFactBase, TFactRule> : List<NodeByFactRule<TFactBase, TFactRule>>
        where TFactBase : IFact
        where TFactRule : IFactRule<TFactBase>
    {

    }
}
