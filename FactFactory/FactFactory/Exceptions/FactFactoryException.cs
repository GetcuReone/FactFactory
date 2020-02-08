using GetcuReone.FactFactory.Entities;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Exceptions
{
    /// <summary>
    /// Base error for FactFactory
    /// </summary>
    public class FactFactoryException : FactFactoryExceptionBase<ErrorDetail>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="details"></param>
        public FactFactoryException(List<ErrorDetail> details) : base(details)
        {
        }
    }
}
