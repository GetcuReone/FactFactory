﻿using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Rule of fact calculation.
    /// </summary>
    /// <typeparam name="TFactBase">The type of fact from which the facts in the container should be inherited.</typeparam>
    public interface IFactRule<TFactBase> : IFactWork<TFactBase>
        where TFactBase : IFact
    {
        /// <summary>
        /// Information on output fact.
        /// </summary>
        IFactType OutputFactType { get; }

        /// <summary>
        /// Is it possible to calculate the fact.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="wantAction"></param>
        /// <typeparam name="TContainer"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <returns></returns>
        bool CanCalculate<TContainer, TWantAction>(TContainer container, TWantAction wantAction) 
            where TContainer : IFactContainer<TFactBase>
            where TWantAction : IWantAction<TFactBase>;

        /// <summary>
        /// Rule of fact calculate.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="wantAction"></param>
        /// <typeparam name="TContainer"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <returns></returns>
        TFactBase Calculate<TContainer, TWantAction>(TContainer container, TWantAction wantAction) 
            where TContainer : IFactContainer<TFactBase>
            where TWantAction : IWantAction<TFactBase>;

        /// <summary>
        /// Get the necessary fact types.
        /// </summary>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="wantAction"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        List<IFactType> GetNecessaryFactTypes<TWantAction, TFactContainer>(TWantAction wantAction, TFactContainer container)
            where TWantAction : IWantAction<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>;
    }
}