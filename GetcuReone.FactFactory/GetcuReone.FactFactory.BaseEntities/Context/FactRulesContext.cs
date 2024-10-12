using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;

namespace GetcuReone.FactFactory.BaseEntities.Context
{
    /// <inheritdoc/>
    public class FactRulesContext : WantActionContext, IFactRulesContext
    {
        /// <inheritdoc/>
        public IFactRuleCollection FactRules { get; set; }
    }
}
