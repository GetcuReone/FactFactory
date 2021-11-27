using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;

namespace GetcuReone.FactFactory.SpecialFacts
{
    /// <summary>
    /// Base class for <see cref="IRuntimeConditionFact"/>.
    /// </summary>
    public abstract class RuntimeConditionFactBase : SpecialFactBase, IRuntimeConditionFact
    {
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
