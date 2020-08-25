using GetcuReone.FactFactory.Interfaces.Context;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces.SpecialFacts
{
    /// <summary>
    /// A special fact that is created using a factory when building a tree or calculating facts.
    /// </summary>
    public interface IConditionFact : ISpecialFact
    {
        /// <summary>
        /// A condition that determines whether the current fact can be added to the container when deriving.
        /// </summary>
        /// <typeparam name="TFactWork"></typeparam>
        /// <typeparam name="TFactRule"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="factWork">Work for which we learn about the possibility of using the fact.</param>
        /// <param name="compatibleRules">Compatible rules.</param>
        /// <param name="context">Context.</param>
        /// <returns></returns>
        /// <remarks>
        /// Using it, you can determine which rule and under what conditions can be used to build a rule tree.
        /// </remarks>
        bool Condition<TFactWork, TFactRule, TWantAction, TFactContainer>(TFactWork factWork, IEnumerable<TFactRule> compatibleRules, IWantActionContext<TWantAction, TFactContainer> context)
            where TFactWork : IFactWork
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;
    }
}
