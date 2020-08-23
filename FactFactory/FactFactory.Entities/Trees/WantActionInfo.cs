using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Entities.Trees
{
    /// <summary>
    /// Info for <see cref="WantAction"/>.
    /// </summary>
    /// <typeparam name="TWantAction"></typeparam>
    /// <typeparam name="TFactContainer"></typeparam>
    public class WantActionInfo<TWantAction, TFactContainer>
        where TWantAction : IWantAction
        where TFactContainer : IFactContainer
    {
        /// <summary>
        /// WantAction.
        /// </summary>
        public TWantAction WantAction { get; set; }

        /// <summary>
        /// Fact container.
        /// </summary>
        public TFactContainer Container { get; set; }

        /// <summary>
        /// List of fact conditions. Successfully completed conditions for <see cref="WantAction"/>.
        /// </summary>
        public List<IConditionFact> SuccessConditions { get; set; }

        /// <summary>
        /// List of fact conditions. Failed conditions for <see cref="WantAction"/>.
        /// </summary>
        public List<IConditionFact> FailedConditions { get; set; }
    }
}
