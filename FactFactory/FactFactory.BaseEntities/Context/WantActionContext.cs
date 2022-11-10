using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;

namespace GetcuReone.FactFactory.BaseEntities.Context
{
    /// <inheritdoc/>
    public class WantActionContext : FactFactoryContext, IWantActionContext
    {
        /// <inheritdoc/>
        public IWantAction WantAction { get; set; }

        /// <inheritdoc/>
        public IFactContainer Container { get; set; }
    }
}
