using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <summary>
    /// Base class for rules.
    /// </summary>
    public abstract class FactRuleBase : BaseFactRule
    {
        /// <inheritdoc/>
        protected FactRuleBase(Func<IEnumerable<IFact>, IFact> func, List<IFactType> inputFactTypes, IFactType outputFactType, FactWorkOption option)
            : base(func, inputFactTypes, outputFactType, option)
        {
        }

        /// <inheritdoc/>
        protected FactRuleBase(Func<IEnumerable<IFact>, ValueTask<IFact>> funcAsync, List<IFactType> inputFactTypes, IFactType outputFactType, FactWorkOption option)
            : base(funcAsync, inputFactTypes, outputFactType, option)
        {
        }
    }
}
