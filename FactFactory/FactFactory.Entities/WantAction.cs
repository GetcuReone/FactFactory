using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GetcuReone.FactFactory.Entities
{
    /// <summary>
    /// Desired action information.
    /// </summary>
    public class WantAction : WantActionBase
    {
        /// <inheritdoc/>
        public WantAction(Action<IEnumerable<IFact>> wantAction, List<IFactType> factTypes, FactWorkOption option) : base(wantAction, factTypes, option)
        {
        }

        /// <inheritdoc/>
        public WantAction(Func<IEnumerable<IFact>, ValueTask> wantActionAsync, List<IFactType> factTypes, FactWorkOption option) : base(wantActionAsync, factTypes, option)
        {
        }
    }
}
