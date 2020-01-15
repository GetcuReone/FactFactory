using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FactFactory.Exceptions
{
    /// <summary>
    /// Base error for FactFactory
    /// </summary>
    public abstract class FactFactoryExceptionBase<TDetail> : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="details"></param>
        protected FactFactoryExceptionBase(List<TDetail> details)
        {
            Details = new ReadOnlyCollection<TDetail>(details);
        }

        /// <summary>
        /// More info exception
        /// </summary>
        public ReadOnlyCollection<TDetail> Details { get; }
    }
}
