using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GetcuReone.FactFactory.Entities
{
    /// <summary>
    /// Rule of fact calculation.
    /// </summary>
    public class FactRule : BaseFactRule
    {
        /// <inheritdoc/>
        public FactRule(Func<IEnumerable<IFact>, IFact> func, List<IFactType>? inputFactTypes, IFactType outputFactType, FactWorkOption option)
            : base(func, inputFactTypes, outputFactType, option)
        {
        }

        /// <inheritdoc/>
        public FactRule(Func<IEnumerable<IFact>, ValueTask<IFact>> funcAsync, List<IFactType>? inputFactTypes, IFactType outputFactType, FactWorkOption option)
            : base(funcAsync, inputFactTypes, outputFactType, option)
        {
        }
    }
}
