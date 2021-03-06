﻿using GetcuReone.FactFactory.Exceptions.Entities;
using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Exceptions
{
    /// <summary>
    /// <see cref="FactFactoryException"/> for method <see cref="IFactFactory{TFactRule, TFactRuleCollection, TWantAction, TFactContainer}"/>.
    /// </summary>
    public class InvalidDeriveOperationException : FactFactoryExceptionBase<DeriveErrorDetail>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="details"></param>
        public InvalidDeriveOperationException(IReadOnlyCollection<DeriveErrorDetail> details) : base(details)
        {
        }
    }
}
