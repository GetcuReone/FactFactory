﻿using GetcuReone.FactFactory.Interfaces.Context;
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
        /// <param name="container"></param>
        /// <returns></returns>
        void ValidateContainer(IFactContainer container);

        /// <summary>
        /// Validate and return a copy of the rules.
        /// </summary>
        /// <typeparam name="TFactRuleCollection">Rule collection type.</typeparam>
        /// <param name="ruleCollection">Rules.</param>
        /// <returns>Rules.</returns>
        TFactRuleCollection ValidateAndGetRules<TFactRuleCollection>(TFactRuleCollection ruleCollection)
            where TFactRuleCollection : IFactRuleCollection;

        /// <summary>
        /// Returns comparer for <see cref="IFactRule"/>.
        /// </summary>
        /// <param name="context">Context.</param>
        /// <returns>Compare for rule.</returns>
        IComparer<IFactRule> GetRuleComparer(IWantActionContext context);

        /// <summary>
        /// Returns rules compatible with <paramref name="target"/>.
        /// </summary>
        /// <typeparam name="TFactWork">Work type.</typeparam>
        /// <param name="target">The purpose with which the rules must be compatible.</param>
        /// <param name="factRules">List of rules.</param>
        /// <param name="context">Context.</param>
        /// <returns>Compatible rules.</returns>
        IFactRuleCollection GetCompatibleRules<TFactWork>(
            TFactWork target,
            IFactRuleCollection factRules,
            IWantActionContext context)
            where TFactWork : IFactWork;

        /// <summary>
        /// True - if the target is consistent with the rule.
        /// </summary>
        /// <typeparam name="TFactWork">Work type.</typeparam>
        /// <param name="target">The purpose with which the rules must be compatible.</param>
        /// <param name="rule">Fact rule.</param>
        /// <param name="context">Context.</param>
        /// <returns>Are the rules compatible?</returns>
        bool CompatibleRule<TFactWork>(TFactWork target, IFactRule rule, IWantActionContext context)
            where TFactWork : IFactWork;

        /// <summary>
        /// Is it possible to get a fact by type <paramref name="factType"/> from a container for a <paramref name="factWork"/>.
        /// </summary>
        /// <typeparam name="TFactWork">Work type.</typeparam>
        /// <param name="factType">Extracted fact type.</param>
        /// <param name="factWork"><see cref="IFactWork"/> for which to extract a fact.</param>
        /// <param name="context">Context.</param>
        /// <returns>Is it possible to extract a fact?</returns>
        bool CanExtractFact<TFactWork>(IFactType factType, TFactWork factWork, IWantActionContext context)
            where TFactWork : IFactWork;

        /// <summary>
        /// Returns types of facts that cannot be extracted from the container.
        /// </summary>
        /// <typeparam name="TFactWork">Work type.</typeparam>
        /// <param name="factWork">Purpose for which facts are needed.</param>
        /// <param name="context">Context.</param>
        /// <returns>Types of facts that cannot be extracted from the container.</returns>
        IEnumerable<IFactType> GetRequiredTypesOfFacts<TFactWork>(TFactWork factWork, IWantActionContext context)
            where TFactWork : IFactWork;

        /// <summary>
        /// Do I need to recalculate the fact.
        /// </summary>
        /// <param name="node">Node.</param>
        /// <param name="context">Context.</param>
        /// <returns>Do I need to recalculate the fact?</returns>
        bool NeedCalculateFact(NodeByFactRule node, IWantActionContext context);

        /// <summary>
        /// Calculate fact by rule from node.
        /// </summary>
        /// <param name="node">Node.</param>
        /// <param name="context">Context.</param>
        /// <returns>Fact.</returns>
        IFact CalculateFact(NodeByFactRule node, IWantActionContext context);

        /// <summary>
        /// Calculate fact by rule from node.
        /// </summary>
        /// <param name="node">Node.</param>
        /// <param name="context">Context.</param>
        /// <returns>Fact.</returns>
        ValueTask<IFact> CalculateFactAsync(NodeByFactRule node, IWantActionContext context);

        /// <summary>
        /// Run <paramref name="wantActionInfo"/> with input facts.
        /// </summary>
        /// <param name="wantActionInfo">WantAction info.</param>
        void DeriveWantFacts(WantActionInfo wantActionInfo);

        /// <summary>
        /// Async run <paramref name="wantActionInfo"/> with input facts.
        /// </summary>
        /// <param name="wantActionInfo">WantAction info.</param>
        ValueTask DeriveWantFactsAsync(WantActionInfo wantActionInfo);

        /// <summary>
        /// Returns <see cref="IEqualityComparer{T}"/> for <see cref="IFact"/>.
        /// </summary>
        /// <returns><see cref="IEqualityComparer{T}"/> for <see cref="IFact"/></returns>
        IEqualityComparer<IFact> GetFactEqualityComparer(IWantActionContext context);

        /// <summary>
        /// Returns <see cref="IComparer{T}"/> for <see cref="IFact"/>.
        /// </summary>
        /// <returns><see cref="IComparer{T}"/> for <see cref="IFact"/></returns>
        IComparer<IFact> GetFactComparer(IWantActionContext context);

        /// <summary>
        /// Creates instanse <see cref="IWantAction"/>.
        /// </summary>
        /// <param name="wantAction">Action taken after deriving a fact.</param>
        /// <param name="factTypes">Facts required to launch an action.</param>
        /// <param name="option">WantAction option.</param>
        /// <returns>WantAction.</returns>
        IWantAction CreateWantAction(Action<IEnumerable<IFact>> wantAction, List<IFactType> factTypes, FactWorkOption option);

        /// <inheritdoc cref="CreateWantAction(Action{IEnumerable{IFact}}, List{IFactType}, FactWorkOption)"/>
        IWantAction CreateWantAction(Func<IEnumerable<IFact>, ValueTask> wantAction, List<IFactType> factTypes, FactWorkOption option);
    }
}
