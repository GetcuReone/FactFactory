using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;

namespace GetcuReone.FactFactory.BaseEntities.Context
{
    /// <inheritdoc/>
    public class FactRulesContext<TFactRule, TWantAction> : WantActionContext<TWantAction>, IFactRulesContext<TFactRule, TWantAction>
        where TFactRule : IFactRule
        where TWantAction : IWantAction
    {
        /// <inheritdoc/>
        public IFactRuleCollection<TFactRule> FactRules { get; set; }
    }
}
