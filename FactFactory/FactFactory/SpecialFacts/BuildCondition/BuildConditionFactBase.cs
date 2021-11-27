using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.SpecialFacts.BuildCondition
{
    /// <summary>
    /// Base class for <see cref="IBuildConditionFact"/>.
    /// </summary>
    public abstract class BuildConditionFactBase : SpecialFactBase, IBuildConditionFact
    {
        /// <inheritdoc/>
        public abstract bool Condition<TFactWork, TFactRule, TWantAction, TFactContainer>(TFactWork factWork, IEnumerable<TFactRule> compatibleRules, IWantActionContext<TWantAction, TFactContainer> context)
            where TFactWork : IFactWork
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;

        /// <inheritdoc/>
        public override bool EqualsInfo(ISpecialFact specialFact)
        {
            return false;
        }
    }

    /// <inheritdoc/>
    /// <typeparam name="TFact">The type of fact for which the condition is met.</typeparam>
    public abstract class BuildConditionFactBase<TFact> : BuildConditionFactBase, IFactTypeCreation
        where TFact : IFact
    {
        /// <inheritdoc/>
        public virtual IFactType GetFactType<TFact1>() where TFact1 : IFact
        {
            return new FactType<TFact1>();
        }
    }
}
