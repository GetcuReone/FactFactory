﻿using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Basic interface for objects that work directly with facts.
    /// </summary>
    /// <typeparam name="TFactBase"></typeparam>
    public interface IFactWork<TFactBase>
        where TFactBase : IFact
    {
        /// <summary>
        /// Information on input factacles rules.
        /// </summary>
        IReadOnlyCollection<IFactType> InputFactTypes { get; }

        /// <summary>
        /// True, the current object is more priority than <paramref name="workFact"/>.
        /// </summary>
        /// <typeparam name="TFactWork"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="workFact"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        bool IsMorePriorityThan<TFactWork, TFactContainer>(TFactWork workFact, TFactContainer container)
            where TFactWork : IFactWork<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>;

        /// <summary>
        /// True, the current object is less priority than <paramref name="workFact"/>.
        /// </summary>
        /// <typeparam name="TFactWork"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="workFact"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        bool IsLessPriorityThan<TFactWork, TFactContainer>(TFactWork workFact, TFactContainer container)
            where TFactWork : IFactWork<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>;

        /// <summary>
        /// Work equality.
        /// </summary>
        /// <typeparam name="TFactWork"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="workFact">Work with which equality is determined.</param>
        /// <param name="wantAction">The action in the context of which this occurs</param>
        /// <param name="container"></param>
        /// <returns></returns>
        bool EqualsWork<TFactWork, TWantAction, TFactContainer>(TFactWork workFact, TWantAction wantAction, TFactContainer container)
            where TFactWork : IFactWork<TFactBase>
            where TWantAction : IWantAction<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>;

        /// <summary>
        /// Is the <paramref name="factRule"/> rule compatible with the current <see cref="IFactWork{TFactBase}"/>.
        /// </summary>
        /// <typeparam name="TFactRule"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="factRule">Compatibility check rule.</param>
        /// <param name="wantAction">The action within which compatibility check.</param>
        /// <param name="container">Container.</param>
        /// <returns></returns>
        bool СompatibilityWithRule<TFactRule, TWantAction, TFactContainer>(TFactRule factRule, TWantAction wantAction, TFactContainer container)
            where TFactRule : IFactRule<TFactBase>
            where TWantAction : IWantAction<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>;
    }
}
