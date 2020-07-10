using GetcuReone.FactFactory.Exceptions.Entities;
using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Exceptions
{
    /// <summary>
    /// <see cref="FactFactoryException"/> for method <see cref="IFactFactory{TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction}.Derive"/>.
    /// </summary>
    public class InvalidDeriveOperationException<TFact> : FactFactoryExceptionBase<DeriveErrorDetail<TFact>>
        where TFact : IFact
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="details"></param>
        public InvalidDeriveOperationException(IReadOnlyCollection<DeriveErrorDetail<TFact>> details) : base(details)
        {
        }
    }
}
