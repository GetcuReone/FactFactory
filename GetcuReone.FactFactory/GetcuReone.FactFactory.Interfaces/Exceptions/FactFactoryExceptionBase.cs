using System;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.Exceptions
{
    /// <summary>
    /// Base error for FactFactory.
    /// </summary>
    public abstract class FactFactoryExceptionBase<TDetail> : Exception
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="details"></param>
        protected FactFactoryExceptionBase(IReadOnlyCollection<TDetail>? details) : base(details?.FirstOrDefault()?.ToString() ?? string.Empty)
        {
            Details = details;
        }

        /// <summary>
        /// More info exception.
        /// </summary>
        public IReadOnlyCollection<TDetail>? Details { get; }
    }
}
