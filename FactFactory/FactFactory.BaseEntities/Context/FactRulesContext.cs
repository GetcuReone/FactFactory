using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;

namespace GetcuReone.FactFactory.BaseEntities.Context
{
    /// <inheritdoc/>
    public class FactRulesContext<TFactRule> : WantActionContext, IFactRulesContext<TFactRule>
        where TFactRule : IFactRule
    {
        /// <inheritdoc/>
        public IFactRuleCollection<TFactRule> FactRules { get; set; }
    }
}
