﻿using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Node info.
    /// </summary>
    public class NodeByFactRuleInfo
    {
        /// <summary>
        /// Rule.
        /// </summary>
        public IFactRule Rule { get; set; }

        /// <summary>
        /// List of successfully <see cref="IBuildConditionFact"/>. Successfully completed conditions for <see cref="Rule"/>.
        /// </summary>
        public List<IBuildConditionFact> BuildSuccessConditions { get; set; }

        /// <summary>
        /// List of failed <see cref="IBuildConditionFact"/>. Failed conditions for <see cref="Rule"/>.
        /// </summary>
        public List<IBuildConditionFact> BuildFailedConditions { get; set; }

        /// <summary>
        /// List of <see cref="IRuntimeConditionFact"/>.
        /// </summary>
        public List<IRuntimeConditionFact> RuntimeConditions { get; set; }

        /// <summary>
        /// Required fact types.
        /// </summary>
        public List<IFactType> RequiredFactTypes { get; set; }

        /// <summary>
        /// Compatible rules.
        /// </summary>
        public IFactRuleCollection CompatibleRules { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "Info <" + Rule.ToString() + ">";
        }
    }
}
