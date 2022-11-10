using System;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;

namespace GetcuReone.FactFactory.SpecialFacts.RuntimeCondition
{
    /// <summary>
    /// Base class for <see cref="IRuntimeConditionFact"/>.
    /// </summary>
    public abstract class BaseRuntimeConditionFact : BaseSpecialFact, IRuntimeConditionFact
    {
        private IFactRule _rule;
        private object _rules;
        private object _getRelatedRulesFunc;
        private object _relatedRules;

        /// <inheritdoc/>
        public abstract bool Condition(IFactWork factWork, IFactRulesContext context);

        /// <inheritdoc/>
        public override bool EqualsInfo(ISpecialFact specialFact)
        {
            return false;
        }

        /// <inheritdoc/>
        public void SetGetRelatedRulesFunc(
            Func<IFactRule, IFactRuleCollection, IWantActionContext, IFactRuleCollection> getRelatedRulesFunc,
            IFactRule rule,
            IFactRuleCollection rules)
        {
            _getRelatedRulesFunc = getRelatedRulesFunc;
            _rules = rules;
            _rule = rule;
        }

        /// <inheritdoc/>
        public virtual bool TryGetRelatedRules(
            IWantActionContext context,
            out IFactRuleCollection relatedRules)
        {
            relatedRules = null;

            if (_relatedRules is IFactRuleCollection result)
            {
                relatedRules = result;
                return true;
            }

            if(_getRelatedRulesFunc is Func<IFactRule, IFactRuleCollection, IWantActionContext, IFactRuleCollection> getRelatedRulesFunc 
                && _rules is IFactRuleCollection rules
                && _rule is IFactRule rule)
            {
                relatedRules = getRelatedRulesFunc(rule, rules, context);
                _relatedRules = relatedRules;
                return true;
            }

            return false;
        }
    }

    /// <inheritdoc/>
    public abstract class BaseRuntimeConditionFact<TFact> : BaseRuntimeConditionFact, IFactTypeCreation
        where TFact : IFact
    {
        /// <inheritdoc/>
        public virtual IFactType GetFactType<TFact1>() where TFact1 : IFact
        {
            return new FactType<TFact1>();
        }
    }
}
