using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Entities
{
    /// <summary>
    /// Rule of fact calculation
    /// </summary>
    public class FactRule : FactRuleBase<IFact, IFactContainer<IFact>>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="func">Func for calculate.</param>
        /// <param name="inputFactTypes">Information on input factacles rules.</param>
        /// <param name="outputFactType">Information on output fact.</param>
        /// <exception cref="ArgumentNullException"><paramref name="func"/> or <paramref name="outputFactType"/> is null.</exception>
        /// <exception cref="ArgumentException">The fact is requested at the input, which the rule calculates.</exception>
        public FactRule(Func<IFactContainer<IFact>, IFact> func, List<IFactType> inputFactTypes, IFactType outputFactType) 
            : base(func, inputFactTypes, outputFactType)
        {
        }
    }
}
