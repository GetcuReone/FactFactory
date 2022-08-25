using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <inheritdoc/>
    [Obsolete("Use BaseWantAction (deprecated in 4.0.2)")]
    public abstract class WantActionBase : BaseWantAction
    {
        /// <inheritdoc/>
        protected WantActionBase(Action<IEnumerable<IFact>> wantAction, List<IFactType> factTypes, FactWorkOption option)
            : base(wantAction, factTypes, option)
        {
        }

        /// <inheritdoc/>
        protected WantActionBase(Func<IEnumerable<IFact>, ValueTask> wantActionAsync, List<IFactType> factTypes, FactWorkOption option)
            : base(wantActionAsync, factTypes, option)
        {
        }
    }
}
