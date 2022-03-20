using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GetcuReone.FactFactory.Interfaces.Operations
{
    /// <summary>
    /// Single operations on entities of the FactFactory.
    /// </summary>
    public interface ISingleEntityOperations : IFactTypeCreation
    {
        /// <summary>
        /// Validate and return a copy of the container.
        /// </summary>
        /// <typeparam name="TFactContainer">Fact container type.</typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        void ValidateContainer<TFactContainer>(TFactContainer container) where TFactContainer : IFactContainer;

        /// <summary>
        /// Validate and return a copy of the rules.
        /// </summary>
        /// <typeparam name="TFactRule">Rule type.</typeparam>
        /// <typeparam name="TFactRuleCollection">Rule collection type.</typeparam>
        /// <param name="ruleCollection">Rules.</param>
        /// <returns>Rules.</returns>
        TFactRuleCollection ValidateAndGetRules<TFactRule, TFactRuleCollection>(TFactRuleCollection ruleCollection)
            where TFactRule : IFactRule
            where TFactRuleCollection : IFactRuleCollection<TFactRule>;

        /// <summary>
        /// Returns comparer for <see cref="IFactRule"/>.
        /// <typeparam name="TFactRule">Rule type.</typeparam>
        /// <typeparam name="TWantAction">WantAction type.</typeparam>
        /// <typeparam name="TFactContainer">Fact container type.</typeparam>
        /// </summary>
        /// <param name="context">Context.</param>
        /// <returns>Compare for rule.</returns>
        IComparer<TFactRule> GetRuleComparer<TFactRule, TWantAction, TFactContainer>(IWantActionContext<TWantAction, TFactContainer> context)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;

        /// <summary>
        /// Returns rules compatible with <paramref name="target"/>.
        /// </summary>
        /// <typeparam name="TFactWork">Work type.</typeparam>
        /// <typeparam name="TFactRule">Rule type.</typeparam>
        /// <typeparam name="TWantAction">WantAction type.</typeparam>
        /// <typeparam name="TFactContainer">Fact container type.</typeparam>
        /// <param name="target">The purpose with which the rules must be compatible.</param>
        /// <param name="factRules">List of rules.</param>
        /// <param name="context">Context.</param>
        /// <returns>Compatible rules.</returns>
        IFactRuleCollection<TFactRule> GetCompatibleRules<TFactWork, TFactRule, TWantAction, TFactContainer>(TFactWork target, IFactRuleCollection<TFactRule> factRules, IWantActionContext<TWantAction, TFactContainer> context)
            where TFactWork : IFactWork
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;

        /// <summary>
        /// True - if the target is consistent with the rule.
        /// </summary>
        /// <typeparam name="TFactWork">Work type.</typeparam>
        /// <typeparam name="TFactRule">Rule type.</typeparam>
        /// <typeparam name="TWantAction">WantAction type.</typeparam>
        /// <typeparam name="TFactContainer">Fact container type.</typeparam>
        /// <param name="target">The purpose with which the rules must be compatible.</param>
        /// <param name="rule">Fact rule.</param>
        /// <param name="context">Context.</param>
        /// <returns>Are the rules compatible?</returns>
        bool CompatibleRule<TFactWork, TFactRule, TWantAction, TFactContainer>(TFactWork target, TFactRule rule, IWantActionContext<TWantAction, TFactContainer> context)
            where TFactWork : IFactWork
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;

        /// <summary>
        /// Is it possible to get a fact by type <paramref name="factType"/> from a container for a <paramref name="factWork"/>.
        /// </summary>
        /// <typeparam name="TFactWork">Work type.</typeparam>
        /// <typeparam name="TWantAction">WantAction type.</typeparam>
        /// <typeparam name="TFactContainer">Fact container type.</typeparam>
        /// <param name="factType">Extracted fact type.</param>
        /// <param name="factWork"><see cref="IFactWork"/> for which to extract a fact.</param>
        /// <param name="context">Context.</param>
        /// <returns>Is it possible to extract a fact?</returns>
        bool CanExtractFact<TFactWork, TWantAction, TFactContainer>(IFactType factType, TFactWork factWork, IWantActionContext<TWantAction, TFactContainer> context)
            where TFactWork : IFactWork
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;

        /// <summary>
        /// Returns types of facts that cannot be extracted from the container.
        /// </summary>
        /// <typeparam name="TFactWork">Work type.</typeparam>
        /// <typeparam name="TWantAction">WantAction type.</typeparam>
        /// <typeparam name="TFactContainer">Fact container type.</typeparam>
        /// <param name="factWork">Purpose for which facts are needed.</param>
        /// <param name="context">Context.</param>
        /// <returns>Types of facts that cannot be extracted from the container.</returns>
        IEnumerable<IFactType> GetRequiredTypesOfFacts<TFactWork, TWantAction, TFactContainer>(TFactWork factWork, IWantActionContext<TWantAction, TFactContainer> context)
            where TFactWork : IFactWork
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;

        /// <summary>
        /// Do I need to recalculate the fact.
        /// </summary>
        /// <typeparam name="TFactRule">Rule type.</typeparam>
        /// <typeparam name="TWantAction">WantAction type.</typeparam>
        /// <typeparam name="TFactContainer">Fact container type.</typeparam>
        /// <param name="node">Node.</param>
        /// <param name="context">Context.</param>
        /// <returns>Do I need to recalculate the fact?</returns>
        bool NeedCalculateFact<TFactRule, TWantAction, TFactContainer>(NodeByFactRule<TFactRule> node, IWantActionContext<TWantAction, TFactContainer> context)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;

        /// <summary>
        /// Calculate fact by rule from node.
        /// </summary>
        /// <typeparam name="TFactRule">Rule type.</typeparam>
        /// <typeparam name="TWantAction">WantAction type.</typeparam>
        /// <typeparam name="TFactContainer">Fact container type.</typeparam>
        /// <param name="node">Node.</param>
        /// <param name="context">Context.</param>
        /// <returns>Fact.</returns>
        IFact CalculateFact<TFactRule, TWantAction, TFactContainer>(NodeByFactRule<TFactRule> node, IWantActionContext<TWantAction, TFactContainer> context)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;

        /// <summary>
        /// Calculate fact by rule from node.
        /// </summary>
        /// <typeparam name="TFactRule">Rule type.</typeparam>
        /// <typeparam name="TWantAction">WantAction type.</typeparam>
        /// <typeparam name="TFactContainer">Fact container type.</typeparam>
        /// <param name="node">Node.</param>
        /// <param name="context">Context.</param>
        /// <returns>Fact.</returns>
        ValueTask<IFact> CalculateFactAsync<TFactRule, TWantAction, TFactContainer>(NodeByFactRule<TFactRule> node, IWantActionContext<TWantAction, TFactContainer> context)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;

        /// <summary>
        /// Run <paramref name="wantActionInfo"/> with input facts.
        /// </summary>
        /// <typeparam name="TWantAction">WantAction type.</typeparam>
        /// <typeparam name="TFactContainer">Fact container type.</typeparam>
        /// <param name="wantActionInfo">WantAction info.</param>
        void DeriveWantFacts<TWantAction, TFactContainer>(WantActionInfo<TWantAction, TFactContainer> wantActionInfo)
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;

        /// <summary>
        /// Async run <paramref name="wantActionInfo"/> with input facts.
        /// </summary>
        /// <typeparam name="TWantAction">WantAction type.</typeparam>
        /// <typeparam name="TFactContainer">Fact container type.</typeparam>
        /// <param name="wantActionInfo">WantAction info.</param>
        ValueTask DeriveWantFactsAsync<TWantAction, TFactContainer>(WantActionInfo<TWantAction, TFactContainer> wantActionInfo)
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;

        /// <summary>
        /// Returns <see cref="IEqualityComparer{T}"/> for <see cref="IFact"/>.
        /// </summary>
        /// <typeparam name="TWantAction">WantAction type.</typeparam>
        /// <typeparam name="TFactContainer">Fact container type.</typeparam>
        /// <returns><see cref="IEqualityComparer{T}"/> for <see cref="IFact"/></returns>
        IEqualityComparer<IFact> GetFactEqualityComparer<TWantAction, TFactContainer>(IWantActionContext<TWantAction, TFactContainer> context)
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;

        /// <summary>
        /// Returns <see cref="IComparer{T}"/> for <see cref="IFact"/>.
        /// </summary>
        /// <typeparam name="TWantAction">WantAction type.</typeparam>
        /// <typeparam name="TFactContainer">Fact container type.</typeparam>
        /// <returns><see cref="IComparer{T}"/> for <see cref="IFact"/></returns>
        IComparer<IFact> GetFactComparer<TWantAction, TFactContainer>(IWantActionContext<TWantAction, TFactContainer> context)
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;

        /// <summary>
        /// Creates <typeparamref name="TWantAction"/>.
        /// </summary>
        /// <param name="wantAction">Action taken after deriving a fact.</param>
        /// <param name="factTypes">Facts required to launch an action.</param>
        /// <param name="option">WantAction option.</param>
        /// <returns>WantAction.</returns>
        TWantAction CreateWantAction<TWantAction>(Action<IEnumerable<IFact>> wantAction, List<IFactType> factTypes, FactWorkOption option)
            where TWantAction : IWantAction;

        /// <inheritdoc cref="CreateWantAction{TWantAction}(Action{IEnumerable{IFact}}, List{IFactType}, FactWorkOption)"/>
        TWantAction CreateWantAction<TWantAction>(Func<IEnumerable<IFact>, ValueTask> wantAction, List<IFactType> factTypes, FactWorkOption option)
            where TWantAction : IWantAction;
    }
}
