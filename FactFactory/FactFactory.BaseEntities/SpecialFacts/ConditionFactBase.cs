﻿using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.BaseEntities.SpecialFacts
{
    /// <summary>
    /// Base class for <see cref="IConditionFact"/>.
    /// </summary>
    public abstract class ConditionFactBase : SpecialFactBase, IConditionFact
    {
        private IFactType _selfFactType;
        /// <inheritdoc/>
        public virtual IFactType FactType { get; protected set; }

        /// <inheritdoc/>
        public abstract bool Condition<TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
            where TFactWork : IFactWork
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;

        /// <inheritdoc/>
        public abstract bool Condition<TFactWork, TFactRule, TWantAction, TFactContainer>(TFactWork factWork, IEnumerable<TFactRule> compatibleRules, IWantActionContext<TWantAction, TFactContainer> context)
            where TFactWork : IFactWork
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;

        /// <inheritdoc/>
        public override IFactType GetFactType()
        {
            return _selfFactType ?? (_selfFactType = base.GetFactType());
        }
    }

    /// <inheritdoc/>
    /// <typeparam name="TFact">Type for <see cref="IConditionFact.FactType"/>.</typeparam>
    public abstract class ConditionFactBase<TFact> : ConditionFactBase, IFactTypeCreation
        where TFact : IFact
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public ConditionFactBase()
        {
            FactType = GetFactType<TFact>();
        }

        /// <inheritdoc/>
        public virtual IFactType GetFactType<TFact1>() where TFact1 : IFact
        {
            return new FactType<TFact1>();
        }
    }
}
