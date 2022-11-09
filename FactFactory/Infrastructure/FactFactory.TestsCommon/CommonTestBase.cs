using GetcuReone.FactFactory;
using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.BaseEntities.Context;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Facades.SingleEntityOperations;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.GetcuTestAdapter;
using System;
using System.Collections.Generic;

namespace FactFactory.TestsCommon
{
    /// <summary>
    /// Base test class.
    /// </summary>
    public abstract class CommonTestBase : GetcuReoneTestBase, IFactTypeCreation
    {
        /// <inheritdoc cref="BaseFact.GetFactType"/>
        public virtual IFactType GetFactType<TFact>() where TFact : IFact
        {
            return new FactType<TFact>();
        }

        /// <summary>
        /// Expect error <see cref="FactFactoryException"/>.
        /// </summary>
        /// <param name="action">Action</param>
        /// <returns>Error <see cref="FactFactoryException"/>.</returns>
        protected FactFactoryException ExpectedFactFactoryException(Action action)
        {
            return ExpectedException<FactFactoryException>(action);
        }

        /// <summary>
        /// Expect error <see cref="InvalidDeriveOperationException"/>.
        /// </summary>
        /// <param name="action">Action</param>
        /// <returns>Error <see cref="InvalidDeriveOperationException"/>.</returns>
        protected InvalidDeriveOperationException ExpectedDeriveException(Action action)
        {
            return ExpectedException<InvalidDeriveOperationException>(action);
        }

        /// <summary>
        /// Get fact type cache.
        /// </summary>
        /// <returns>Fact type cahce.</returns>
        protected IFactTypeCache GetFactTypeCache()
        {
            return new FactTypeCache();
        }

        /// <summary>
        /// Get context for <see cref="IWantAction"/>.
        /// </summary>
        /// <typeparam name="TWantAction">Type <paramref name="wantAction"/></typeparam>
        /// <param name="wantAction">Desired action information</param>
        /// <param name="container">Fact container</param>
        /// <param name="singleEntity">Single operations on entities of the FactFactory</param>
        /// <param name="cache">Cache for fact type</param>
        /// <returns>Context for <see cref="IWantAction"/>.</returns>
        protected virtual IWantActionContext<TWantAction> GetWantActionContext<TWantAction>(TWantAction wantAction, IFactContainer container, ISingleEntityOperations singleEntity = null, IFactTypeCache cache = null)
            where TWantAction : IWantAction
        {
            return new WantActionContext<TWantAction>
            {
                Cache = cache ?? GetFactTypeCache(),
                SingleEntity = singleEntity ?? GetFacade<SingleEntityOperationsFacade>(),
                WantAction = wantAction,
                Container = container,
            };
        }

        /// <inheritdoc cref="GetFactRule{TFact1, TFact2, TFact3, TFactResult}(Func{TFact1, TFact2, TFact3, TFactResult}, FactWorkOption)"/>
        protected FactRule GetFactRule<TFactResult>(Func<TFactResult> func, FactWorkOption option = FactWorkOption.CanExecuteSync)
            where TFactResult : IFact
        {
            return new FactRule(
                facts => func(),
                new List<IFactType>(),
                GetFactType<TFactResult>(),
                option);
        }

        /// <inheritdoc cref="GetFactRule{TFact1, TFact2, TFact3, TFactResult}(Func{TFact1, TFact2, TFact3, TFactResult}, FactWorkOption)"/>
        protected FactRule GetFactRule<TFact1, TFactResult>(Func<TFact1, TFactResult> func, FactWorkOption option = FactWorkOption.CanExecuteSync)
            where TFact1 : IFact
            where TFactResult : IFact
        {
            return new FactRule(
                facts => func(facts.GetFact<TFact1>()),
                new List<IFactType> { GetFactType<TFact1>() },
                GetFactType<TFactResult>(),
                option);
        }

        /// <inheritdoc cref="GetFactRule{TFact1, TFact2, TFact3, TFactResult}(Func{TFact1, TFact2, TFact3, TFactResult}, FactWorkOption)"/>
        protected FactRule GetFactRule<TFact1, TFact2, TFactResult>(Func<TFact1, TFact2, TFactResult> func, FactWorkOption option = FactWorkOption.CanExecuteSync)
            where TFact1 : IFact
            where TFact2 : IFact
            where TFactResult : IFact
        {
            return new FactRule(
                facts => func(facts.GetFact<TFact1>(), facts.GetFact<TFact2>()),
                new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>() },
                GetFactType<TFactResult>(),
                option);
        }

        /// <summary>
        /// Get fact rule.
        /// </summary>
        /// <typeparam name="TFact1">Fact rule parametr 1</typeparam>
        /// <typeparam name="TFact2">Fact rule parametr 2</typeparam>
        /// <typeparam name="TFact3">Fact rule parametr 3</typeparam>
        /// <typeparam name="TFactResult">Type result for fact rule</typeparam>
        /// <param name="func">Func for <typeparamref name="TFactResult"/></param>
        /// <param name="option">Options for fact rule</param>
        /// <returns>Fact rule.</returns>
        protected FactRule GetFactRule<TFact1, TFact2, TFact3, TFactResult>(Func<TFact1, TFact2, TFact3, TFactResult> func, FactWorkOption option = FactWorkOption.CanExecuteSync)
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFactResult : IFact
        {
            return new FactRule(
                facts => func(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>()),
                new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>() },
                GetFactType<TFactResult>(),
                option);
        }

        /// <inheritdoc cref="GetWantAction{TFact1, TFact2, TFact3}(Action{TFact1, TFact2, TFact3})"/>
        protected WantAction GetWantAction<TFact1>(Action<TFact1> action)
            where TFact1 : IFact
        {
            return new WantAction(
                facts => action(facts.GetFact<TFact1>()),
                new List<IFactType> { GetFactType<TFact1>() },
                FactWorkOption.CanExecuteSync);
        }

        /// <inheritdoc cref="GetWantAction{TFact1, TFact2, TFact3}(Action{TFact1, TFact2, TFact3})"/>
        protected WantAction GetWantAction<TFact1, TFact2>(Action<TFact1, TFact2> action)
            where TFact1 : IFact
            where TFact2 : IFact
        {
            return new WantAction(
                facts => action(facts.GetFact<TFact1>(), facts.GetFact<TFact2>()),
                new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>() },
                FactWorkOption.CanExecuteSync);
        }

        /// <summary>
        /// Get wantAction.
        /// </summary>
        /// <typeparam name="TFact1">Parameter 1</typeparam>
        /// <typeparam name="TFact2">Parameter 2</typeparam>
        /// <typeparam name="TFact3">Parameter 3</typeparam>
        /// <param name="action">Action</param>
        /// <returns>WantAction.</returns>
        protected WantAction GetWantAction<TFact1, TFact2, TFact3>(Action<TFact1, TFact2, TFact3> action)
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
        {
            return new WantAction(
                facts => action(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>()),
                new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>() },
                FactWorkOption.CanExecuteSync);
        }
    }
}
