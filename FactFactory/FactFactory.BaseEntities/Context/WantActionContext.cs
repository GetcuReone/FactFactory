using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;

namespace GetcuReone.FactFactory.BaseEntities.Context
{
    /// <inheritdoc/>
    public class WantActionContext<TWantAction, TFactContainer> : FactFactoryContext, IWantActionContext<TWantAction, TFactContainer>
        where TWantAction : IWantAction
        where TFactContainer : IFactContainer
    {
        /// <inheritdoc/>
        public TWantAction WantAction { get; set; }

        /// <inheritdoc/>
        public TFactContainer Container { get; set; }
    }
}
