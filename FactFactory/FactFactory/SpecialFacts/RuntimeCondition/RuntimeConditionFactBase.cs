using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.SpecialFacts.RuntimeCondition
{
    /// <summary>
    /// Base class for <see cref="IRuntimeConditionFact"/>.
    /// </summary>
    public abstract class RuntimeConditionFactBase : SpecialFactBase, IRuntimeConditionFact
    {
        private object _relatedRules;

        /// <inheritdoc/>
        public List<IFactRule> FactRules { get; set; }

        /// <inheritdoc/>
        public abstract bool Condition<TFactWork, TFactRule, TWantAction, TFactContainer>(TFactWork factWork, IFactRulesContext<TFactRule, TWantAction, TFactContainer> context)
            where TFactWork : IFactWork
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;

        /// <inheritdoc/>
        public override bool EqualsInfo(ISpecialFact specialFact)
        {
            return false;
        }

        /// <inheritdoc/>
        public void SetRelatedRules<TFactRule>(IFactRuleCollection<TFactRule> rules) where TFactRule : IFactRule
        {
            _relatedRules = rules;
        }

        /// <inheritdoc/>
        public bool TryGetRelatedRulse<TFactRule>(out IFactRuleCollection<TFactRule> rules) where TFactRule : IFactRule
        {
            rules = null;

            if (_relatedRules is IFactRuleCollection<TFactRule> result)
                rules = result;

            return rules != null;
        }
    }

    /// <inheritdoc/>
    public abstract class RuntimeConditionFactBase<TFact> : RuntimeConditionFactBase, IFactTypeCreation
        where TFact : IFact
    {
        /// <inheritdoc/>
        public virtual IFactType GetFactType<TFact1>() where TFact1 : IFact
        {
            return new FactType<TFact1>();
        }
    }
}
