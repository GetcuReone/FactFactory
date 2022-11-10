using GetcuReone.FactFactory.Exceptions.Entities;
using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Exceptions
{
    /// <summary>
    /// <see cref="FactFactoryException"/> for method <see cref="IFactFactory{TFactRule, TFactRuleCollection}"/>.
    /// </summary>
    public class InvalidDeriveOperationException : FactFactoryExceptionBase<DeriveErrorDetail>
    {
        /// <inheritdoc/>
        public InvalidDeriveOperationException(IReadOnlyCollection<DeriveErrorDetail> details) : base(details)
        {
        }
    }
}
