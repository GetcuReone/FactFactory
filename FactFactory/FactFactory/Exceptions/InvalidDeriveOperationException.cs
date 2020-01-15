using FactFactory.Entities;
using FactFactory.Interfaces;
using System.Collections.Generic;

namespace FactFactory.Exceptions
{
    /// <summary>
    /// <see cref="FactFactoryException"/> for method <see cref="IFactFactory{TFactContainer, TFactRule, TFactRuleCollection, TWantAction}.Derive"/>
    /// </summary>
    public class InvalidDeriveOperationException : FactFactoryExceptionBase<DeriveErrorDetail>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="details"></param>
        public InvalidDeriveOperationException(List<DeriveErrorDetail> details) : base(details)
        {
        }
    }
}
