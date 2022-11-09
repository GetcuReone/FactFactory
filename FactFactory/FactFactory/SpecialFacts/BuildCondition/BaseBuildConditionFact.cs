using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System;

namespace GetcuReone.FactFactory.SpecialFacts.BuildCondition
{
    /// <summary>
    /// Base class for <see cref="IBuildConditionFact"/>.
    /// </summary>
    public abstract class BaseBuildConditionFact : BaseSpecialFact, IBuildConditionFact
    {
        /// <inheritdoc/>
        public abstract bool Condition<TFactWork, TFactRule, TWantAction>(
            TFactWork factWork,
            IWantActionContext<TWantAction> context,
            Func<IWantActionContext<TWantAction>,
            IFactRuleCollection<TFactRule>> getCompatibleRules)
            where TFactWork : IFactWork
            where TFactRule : IFactRule
            where TWantAction : IWantAction;

        /// <inheritdoc/>
        public override bool EqualsInfo(ISpecialFact specialFact)
        {
            return false;
        }
    }

    /// <inheritdoc/>
    /// <typeparam name="TFact">The type of fact for which the condition is met.</typeparam>
    public abstract class BaseBuildConditionFact<TFact> : BaseBuildConditionFact, IFactTypeCreation
        where TFact : IFact
    {
        /// <inheritdoc/>
        public virtual IFactType GetFactType<TFact1>() where TFact1 : IFact
        {
            return new FactType<TFact1>();
        }
    }
}
