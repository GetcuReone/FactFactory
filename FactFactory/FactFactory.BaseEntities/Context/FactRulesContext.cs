using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;

namespace GetcuReone.FactFactory.BaseEntities.Context
{
    /// <inheritdoc/>
    public class FactRulesContext<TFactRule, TWantAction, TFactContainer> : WantActionContext<TWantAction, TFactContainer>, IFactRulesContext<TFactRule, TWantAction, TFactContainer>
        where TFactRule : IFactRule
        where TWantAction : IWantAction
        where TFactContainer : IFactContainer
    {
        /// <inheritdoc/>
        public IFactRuleCollection<TFactRule> FactRules { get; set; }
    }
}
