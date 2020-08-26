using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Independent node group.
    /// </summary>
    /// <typeparam name="TFactRule"></typeparam>
    public class IndependentNodeGroup<TFactRule> : List<NodeByFactRule<TFactRule>>
        where TFactRule : IFactRule
    {
        /// <inheritdoc/>
        public IndependentNodeGroup()
        {

        }

        /// <inheritdoc/>
        public IndependentNodeGroup(IEnumerable<NodeByFactRule<TFactRule>> factRules) : base(factRules)
        {

        }

        /// <summary>
        /// Can add node.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public virtual bool CanAdd(NodeByFactRule<TFactRule> node)
        {
            if (Count == 0)
                return true;

            return this
                .All(n => n.Info.Rule.InputFactTypes
                    .All(type => !node.Info.Rule.OutputFactType.EqualsFactType(type)));
        }
    }
}
