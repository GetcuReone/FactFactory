using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using System;

namespace GetcuReone.FactFactory.SpecialFacts.BuildCondition
{
    /// <summary>
    /// Fact condition. Checks if a <typeparamref name="TFact"/> fact can be retrieved from a container at the tree building stage.
    /// </summary>
    /// <typeparam name="TFact">The type of fact for which the condition is met.</typeparam>
    public class BuildContained<TFact> : BaseBuildConditionFact<TFact>
        where TFact : IFact
    {
        /// <summary>
        /// Checks if a <typeparamref name="TFact"/> fact can be retrieved from a container.
        /// </summary>
        /// <inheritdoc/>
        public override bool Condition<TFactWork, TFactRule>(
            TFactWork factWork,
            IWantActionContext context,
            Func<IWantActionContext, IFactRuleCollection<TFactRule>> compatibleRules)
        {
            return context.SingleEntity.CanExtractFact(GetFactType<TFact>(), factWork, context);
        }
    }
}
