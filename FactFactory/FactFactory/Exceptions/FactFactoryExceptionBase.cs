using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GetcuReone.FactFactory.Exceptions
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
        protected FactFactoryExceptionBase(List<TDetail> details) : base(details[0].ToString())
        {
            if (details != null)
                Details = new ReadOnlyCollection<TDetail>(details);
        }

        /// <summary>
        /// More info exception
        /// </summary>
        public ReadOnlyCollection<TDetail> Details { get; }
    }
}
