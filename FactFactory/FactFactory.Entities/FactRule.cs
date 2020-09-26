﻿using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GetcuReone.FactFactory.Entities
{
    /// <summary>
    /// Rule of fact calculation.
    /// </summary>
    public class FactRule : FactRuleBase
    {
        /// <inheritdoc/>
        public FactRule(Func<IEnumerable<IFact>, IFact> func, List<IFactType> inputFactTypes, IFactType outputFactType)
            : base(func, inputFactTypes, outputFactType)
        {
        }

        /// <inheritdoc/>
        public FactRule(Func<IEnumerable<IFact>, ValueTask<IFact>> funcAsync, List<IFactType> inputFactTypes, IFactType outputFactType)
            : base(funcAsync, inputFactTypes, outputFactType)
        {
        }
    }
}
