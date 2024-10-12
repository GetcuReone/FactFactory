using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using System;

namespace GetcuReone.FactFactory.SpecialFacts.BuildCondition
{
    /// <summary>
    /// Fact condition that checks if a tree can be built for the fact <typeparamref name = "TFact" /> at the tree building stage.
    /// </summary>
    /// <typeparam name="TFact">The type of fact for which the condition is met.</typeparam>
    public class BuildCanDerived<TFact> : BaseBuildConditionFact<TFact>
        where TFact : IFact
    {
        /// <summary>
        /// Checks if a tree can be built for the fact.
        /// </summary>
        /// <inheritdoc/>
        public override bool Condition(
            IFactWork factWork,
            IWantActionContext context,
            Func<IWantActionContext, IFactRuleCollection> getCompatibleRules)
        {
            return ConditionHelper.CanDeriveFact(
                this,
                GetFactType<TFact>(),
                factWork,
                getCompatibleRules(context),
                context);
        }
    }
}
