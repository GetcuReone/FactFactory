using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.SpecialFacts.RuntimeCondition
{
    /// <summary>
    /// Base class for <see cref="IRuntimeConditionFact"/>.
    /// </summary>
    public abstract class RuntimeConditionFactBase : SpecialFactBase, IRuntimeConditionFact
    {
        private IFactRule _rule;
        private object _rules;
        private object _getRelatedRulesFunc;
        private object _relatedRules;

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
        public void SetGetRelatedRulesFunc<TFactRule, TWantAction, TFactContainer>(Func<TFactRule, IFactRuleCollection<TFactRule>, IWantActionContext<TWantAction, TFactContainer>, IFactRuleCollection<TFactRule>> getRelatedRulesFunc, TFactRule rule, IFactRuleCollection<TFactRule> rules)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            _getRelatedRulesFunc = getRelatedRulesFunc;
            _rules = rules;
            _rule = rule;
        }

        /// <inheritdoc/>
        public virtual bool TryGetRelatedRules<TFactRule, TWantAction, TFactContainer>(IWantActionContext<TWantAction, TFactContainer> context, out IFactRuleCollection<TFactRule> relatedRules)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            relatedRules = null;

            if (_relatedRules is IFactRuleCollection<TFactRule> result)
            {
                relatedRules = result;
                return true;
            }

            if(_getRelatedRulesFunc is Func<TFactRule, IFactRuleCollection<TFactRule>, IWantActionContext<TWantAction, TFactContainer>, IFactRuleCollection<TFactRule>> getRelatedRulesFunc 
                && _rules is IFactRuleCollection<TFactRule> rules
                && _rule is TFactRule rule)
            {
                relatedRules = getRelatedRulesFunc(rule, rules, context);
                _relatedRules = relatedRules;
                return true;
            }

            return false;
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
