using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Info for WantAction from context.
    /// </summary>
    /// <typeparam name="TWantAction">WantAction type.</typeparam>
    public class WantActionInfo<TWantAction>
        where TWantAction : IWantAction
    {
        /// <summary>
        /// Context.
        /// </summary>
        public IWantActionContext<TWantAction> Context { get; set; }

        /// <summary>
        /// List of successfully <see cref="IBuildConditionFact"/>. Successfully completed conditions for WantAction from <see cref="Context"/>.
        /// </summary>
        public List<IBuildConditionFact> BuildSuccessConditions { get; set; }

        /// <summary>
        /// List of failed <see cref="IBuildConditionFact"/>. Failed conditions for WantAction from <see cref="Context"/>.
        /// </summary>
        public List<IBuildConditionFact> BuildFailedConditions { get; set; }

        /// <summary>
        /// List of <see cref="IRuntimeConditionFact"/>.
        /// </summary>
        public List<IRuntimeConditionFact> RuntimeConditions { get; set; }
    }
}
