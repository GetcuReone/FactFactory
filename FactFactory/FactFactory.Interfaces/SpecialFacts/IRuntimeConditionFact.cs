﻿using GetcuReone.FactFactory.Interfaces.Context;
using System;

namespace GetcuReone.FactFactory.Interfaces.SpecialFacts
{
    /// <summary>
    /// A special fact that is created when calculating facts. Used to check the condition.
    /// </summary>
    public interface IRuntimeConditionFact : ISpecialFact
    {
        /// <summary>
        /// Sets the method for getting related fact rules.
        /// </summary>
        /// <typeparam name="TFactRule">Type rule.</typeparam>
        /// <typeparam name="TWantAction">Type wantAction.</typeparam>
        /// <param name="getRelatedRulesFunc">Method for getting related fact rules.</param>
        /// <param name="rule">Rule in which the condition was found.</param>
        /// <param name="rules">Fact rules under which the condition was found.</param>
        void SetGetRelatedRulesFunc<TFactRule, TWantAction>(
            Func<TFactRule, IFactRuleCollection<TFactRule>, IWantActionContext<TWantAction>,
                IFactRuleCollection<TFactRule>> getRelatedRulesFunc,
            TFactRule rule,
            IFactRuleCollection<TFactRule> rules)
            where TFactRule : IFactRule
            where TWantAction : IWantAction;

        /// <summary>
        /// Try get method for related fact rules.
        /// </summary>
        /// <typeparam name="TFactRule">Type rule.</typeparam>
        /// <typeparam name="TWantAction">Type wantAction.</typeparam>
        /// <param name="context">Context.</param>
        /// <param name="relatedRules">Related fact rules.</param>
        /// <returns>True - was able to return the associated fact rules.</returns>
        bool TryGetRelatedRules<TFactRule, TWantAction>(
            IWantActionContext<TWantAction> context,
            out IFactRuleCollection<TFactRule> relatedRules)
            where TFactRule : IFactRule
            where TWantAction : IWantAction;

        /// <summary>
        /// A condition that determines whether the current fact can be added to the container when deriving.
        /// </summary>
        /// <typeparam name="TFactWork">Type <paramref name="factWork"/>.</typeparam>
        /// <typeparam name="TFactRule">Type rule.</typeparam>
        /// <typeparam name="TWantAction">Type wantAction.</typeparam>
        /// <param name="factWork">Work for which we learn about the possibility of using the fact.</param>
        /// <param name="context">Context.</param>
        /// <returns>Has the condition been met?</returns>
        /// <remarks>
        /// With it, you can determine which rule and under what conditions can be used when calculating facts.
        /// </remarks>
        bool Condition<TFactWork, TFactRule, TWantAction>(TFactWork factWork, IFactRulesContext<TFactRule, TWantAction> context)
            where TFactWork : IFactWork
            where TFactRule : IFactRule
            where TWantAction : IWantAction;
    }
}
