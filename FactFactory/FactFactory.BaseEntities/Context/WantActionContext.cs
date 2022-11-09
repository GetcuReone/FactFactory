using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;

namespace GetcuReone.FactFactory.BaseEntities.Context
{
    /// <inheritdoc/>
    public class WantActionContext<TWantAction> : FactFactoryContext, IWantActionContext<TWantAction>
        where TWantAction : IWantAction
    {
        /// <inheritdoc/>
        public TWantAction WantAction { get; set; }

        /// <inheritdoc/>
        public IFactContainer Container { get; set; }
    }
}
