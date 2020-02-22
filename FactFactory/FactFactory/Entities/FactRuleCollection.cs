using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Entities
{
    /// <summary>
    /// Collection for <see cref="FactRule"/>
    /// </summary>
    public sealed class FactRuleCollection : FactRuleCollectionBase<FactRule>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FactRuleCollection()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factRules"></param>
        public FactRuleCollection(IEnumerable<FactRule> factRules) : base(factRules)
        {
        }

        /// <summary>
        /// Creation method <see cref="FactRule"/>
        /// </summary>
        /// <param name="func">func for calculate</param>
        /// <param name="inputFactTypes">information on input factacles rules</param>
        /// <param name="outputFactType">information on output fact</param>
        /// <returns>fact rule</returns>
        protected override FactRule CreateFactRule(Func<IFactContainer, IFact> func, List<IFactType> inputFactTypes, IFactType outputFactType)
        {
            return new FactRule(func, inputFactTypes, outputFactType);
        }
    }
}
