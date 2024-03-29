﻿using GetcuReone.FactFactory.Interfaces.SpecialFacts;
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
            if (Count == 0)
                return true;

            var rule = node.Info.Rule;

            foreach(var independentNode in this)
            {
                var independentRule = independentNode.Info.Rule;

                if (independentRule.OutputFactType.EqualsFactType(rule.OutputFactType))
                    return false;

                foreach (var inputType in independentRule.InputFactTypes)
                {
                    if (inputType.EqualsFactType(rule.OutputFactType))
                        return false;

                    if (rule.InputFactTypes.Any(type => type.EqualsFactType(inputType)) && inputType.IsFactType<IBuildConditionFact>())
                        return false;
                }
            }

            return true;
        }
    }
}
