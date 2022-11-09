using GetcuReone.FactFactory.Interfaces.Context;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Request.
    /// </summary>
    /// <typeparam name="TFactRule">Rule type.</typeparam>
    /// <typeparam name="TWantAction">WantAction type.</typeparam>
    public class BuildTreesForWantActionRequest<TFactRule, TWantAction>
        where TFactRule : IFactRule
        where TWantAction : IWantAction
    {
        /// <summary>
        /// Context.
        /// </summary>
        public IWantActionContext<TWantAction> Context { get; set; }

        /// <summary>
        /// Fact rules.
        /// </summary>
        public IFactRuleCollection<TFactRule> FactRules { get; set; }
    }
}
