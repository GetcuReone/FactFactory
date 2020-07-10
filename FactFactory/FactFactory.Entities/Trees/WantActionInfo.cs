using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetcuReone.FactFactory.Entities.Trees
{
    /// <summary>
    /// Info for <see cref="WantAction"/>.
    /// </summary>
    /// <typeparam name="TFactBase"></typeparam>
    /// <typeparam name="TWantAction"></typeparam>
    /// <typeparam name="TFactContainer"></typeparam>
    public class WantActionInfo<TFactBase, TWantAction, TFactContainer>
        where TFactBase : IFact
        where TWantAction : IWantAction<TFactBase>
        where TFactContainer : IFactContainer<TFactBase>
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
