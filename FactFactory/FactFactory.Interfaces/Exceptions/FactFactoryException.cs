using GetcuReone.FactFactory.Exceptions.Entities;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Exceptions
{
    /// <summary>
    /// Base error for FactFactory
    /// </summary>
    public class FactFactoryException : FactFactoryExceptionBase<ErrorDetail>
    {
        /// <inheritdoc/>
        public FactFactoryException(IReadOnlyCollection<ErrorDetail> details) : base(details)
        {
        }
    }
}
