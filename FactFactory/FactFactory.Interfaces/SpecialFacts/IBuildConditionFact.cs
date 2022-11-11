using GetcuReone.FactFactory.Interfaces.Context;
using System;

namespace GetcuReone.FactFactory.Interfaces.SpecialFacts
{
    /// <summary>
    /// A special fact that is created when building a tree. Used to check the condition.
    /// </summary>
    public interface IBuildConditionFact : ISpecialFact
    {
        /// <summary>
        /// A condition that determines whether the current fact can be added to the container when deriving.
        /// </summary>
        /// <param name="factWork">Work for which we learn about the possibility of using the fact.</param>
        /// <param name="getCompatibleRules">Func for get compatible rules.</param>
        /// <param name="context">Context.</param>
        /// <returns>Has the condition been met?</returns>
        /// <remarks>
        /// Using it, you can determine which rule and under what conditions can be used to build a rule tree.
        /// </remarks>
        bool Condition(
            IFactWork factWork,
            IWantActionContext context,
            Func<IWantActionContext, IFactRuleCollection> getCompatibleRules);
    }
}
