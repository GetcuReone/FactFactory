using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Independent node group.
    /// </summary>
    public class IndependentNodeGroup : List<NodeByFactRule>
    {
        /// <inheritdoc/>
        public IndependentNodeGroup() { }

        /// <inheritdoc/>
        public IndependentNodeGroup(IEnumerable<NodeByFactRule> factRules) : base(factRules) { }

        /// <summary>
        /// Can add node.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public virtual bool CanAdd(NodeByFactRule node)
        {
            // If there are no other rules, then you can add to the group
            if (Count == 0)
                return true;

            var rule = node.Info.Rule;

            foreach(var independentNode in this)
            {
                var independentRule = independentNode.Info.Rule;

                // If the rules have the same output parameters, they cannot be included in the same group
                if (independentRule.OutputFactType.EqualsFactType(rule.OutputFactType))
                    return false;

                foreach (var inputType in independentRule.InputFactTypes)
                {
                    // If at least one of the input parameters matches the output parameter of the second rule,
                    // then they cannot be included in the same group
                    if (inputType.EqualsFactType(rule.OutputFactType))
                        return false;

                    // If at least one input parameter of the second rule matches the input parameter of the first,
                    // then they cannot be in the same group.
                    // If there are matches among the input parameters of the rules and they are conditional,
                    // then they cannot be included in the same group
                    if (rule.InputFactTypes.Any(type => type.EqualsFactType(independentRule.OutputFactType)
                        || (type.EqualsFactType(inputType) && (inputType.IsFactType<IBuildConditionFact>() || inputType.IsFactType<IRuntimeConditionFact>()))))
                        return false;
                }
            }

            return true;
        }
    }
}
