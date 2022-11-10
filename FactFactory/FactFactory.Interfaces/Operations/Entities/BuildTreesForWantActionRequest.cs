using GetcuReone.FactFactory.Interfaces.Context;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Request.
    /// </summary>
    /// <typeparam name="TFactRule">Rule type.</typeparam>
    public class BuildTreesForWantActionRequest<TFactRule>
        where TFactRule : IFactRule
    {
        /// <summary>
        /// Context.
        /// </summary>
        public IWantActionContext Context { get; set; }

        /// <summary>
        /// Fact rules.
        /// </summary>
        public IFactRuleCollection<TFactRule> FactRules { get; set; }
    }
}
