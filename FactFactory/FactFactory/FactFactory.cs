﻿using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GetcuReone.FactFactory
{
    /// <inheritdoc />
    public class FactFactory : FactFactoryBase<FactContainer, FactRule, FactRuleCollection>
    {
        private ReadOnlyCollection<FactRule> _tempRule;

        /// <summary>
        /// Fact container
        /// </summary>
        public override FactContainer Container { get; } = new FactContainer();

        /// <summary>
        /// Collection of rules for derive facts
        /// </summary>
        public override FactRuleCollection Rules { get; } = new FactRuleCollection();

        /// <summary>
        /// Derive the facts
        /// </summary>
        public override void Derive()
        {
            _tempRule = new ReadOnlyCollection<FactRule>(Rules);

            base.Derive();

            _tempRule = null;
        }

        /// <summary>
        /// Return a list with the appropriate rules at the time of the derive of the facts
        /// </summary>
        /// <param name="readOnlyFactContainer">read-only fact container</param>
        /// <param name="wantAction"></param>
        /// <returns></returns>
        protected override IReadOnlyCollection<FactRule> GetRulesForWantAction(WantAction wantAction, IReadOnlyCollection<IFact> readOnlyFactContainer)
        {
            return _tempRule;
        }

        /// <summary>
        /// Get copy container
        /// </summary>
        /// <returns></returns>
        protected override FactContainer GetContainerForDerive()
        {
            return new FactContainer(Container);
        }
    }
}
