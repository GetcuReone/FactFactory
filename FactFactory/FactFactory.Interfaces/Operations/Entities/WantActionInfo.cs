using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Info for WantAction from context.
    /// </summary>
    /// <typeparam name="TWantAction">WantAction type.</typeparam>
    /// <typeparam name="TFactContainer">Fact container type.</typeparam>
    public class WantActionInfo<TWantAction, TFactContainer>
        where TWantAction : IWantAction
        where TFactContainer : IFactContainer
    {
        /// <summary>
        /// Context.
        /// </summary>
        public IWantActionContext<TWantAction, TFactContainer> Context { get; set; }

        /// <summary>
        /// List of fact conditions. Successfully completed conditions for WantAction from context.
        /// </summary>
        public List<IConditionFact> SuccessConditions { get; set; }

        /// <summary>
        /// List of fact conditions. Failed conditions for WantAction from context.
        /// </summary>
        public List<IConditionFact> FailedConditions { get; set; }
    }
}
