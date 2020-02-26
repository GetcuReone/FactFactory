using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Exceptions
{
    /// <summary>
    /// <see cref="FactFactoryException"/> for method <see cref="FactFactoryBase{TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction}.Derive"/>
    /// </summary>
    public class InvalidDeriveOperationException<TFact, TWantAction> : FactFactoryExceptionBase<DeriveErrorDetail<TFact, TWantAction>>
        where TFact : IFact
        where TWantAction : IWantAction<TFact>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="details"></param>
        public InvalidDeriveOperationException(List<DeriveErrorDetail<TFact, TWantAction>> details) : base(details)
        {
        }
    }
}
