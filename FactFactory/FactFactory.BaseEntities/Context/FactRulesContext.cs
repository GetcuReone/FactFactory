using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.BaseEntities.Context
{
    /// <inheritdoc/>
    public class FactRulesContext : WantActionContext, IFactRulesContext
    {
        /// <inheritdoc/>
        public IEnumerable<IFactRule> FactRules { get; set; }
    }
}
