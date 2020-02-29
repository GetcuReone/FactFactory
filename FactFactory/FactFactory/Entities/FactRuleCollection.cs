using GetcuReone.FactFactory.Facts;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Entities
{
    /// <summary>
    /// Collection for <see cref="FactRule"/>
    /// </summary>
    public class FactRuleCollection : FactRuleCollectionBase<FactBase, FactRule>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FactRuleCollection()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="factRules"></param>
        public FactRuleCollection(IEnumerable<FactRule> factRules) : base(factRules)
        {
        }

        /// <summary>
        /// <see cref="FactRuleCollectionBase{TFact, TFactRule}"/> copy method.
        /// </summary>
        /// <returns>Copied <see cref="FactRuleCollection"/>.</returns>
        public override FactRuleCollectionBase<FactBase, FactRule> Copy()
        {
            return new FactRuleCollection(this);
        }

        /// <summary>
        /// Creation method <see cref="FactRule"/>
        /// </summary>
        /// <param name="func">func for calculate</param>
        /// <param name="inputFactTypes">information on input factacles rules</param>
        /// <param name="outputFactType">information on output fact</param>
        /// <returns>fact rule</returns>
        protected sealed override FactRule CreateFactRule(Func<IFactContainer<FactBase>, FactBase> func, List<IFactType> inputFactTypes, IFactType outputFactType)
        {
            return new FactRule(func, inputFactTypes, outputFactType);
        }
    }
}
