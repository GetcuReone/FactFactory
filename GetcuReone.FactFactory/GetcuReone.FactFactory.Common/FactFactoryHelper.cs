using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Exceptions.Entities;
using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory
{
    /// <summary>
    /// Common helper for FactFactory.
    /// </summary>
    public static class FactFactoryHelper
    {
        /// <summary>
        /// Create <see cref="FactFactoryException"/>
        /// </summary>
        /// <param name="code">error code</param>
        /// <param name="reason">error reason</param>
        /// <returns>Exception.</returns>
        public static FactFactoryException CreateException(string code, string reason)
        {
            return new FactFactoryException(
                new List<ErrorDetail>
                {
                    new ErrorDetail(code, reason)
                }.AsReadOnly());
        }

        /// <summary>
        /// Create <see cref="InvalidDeriveOperationException"/>.
        /// </summary>
        /// <param name="details">Error deteils.</param>
        /// <returns>Exception.</returns>
        public static InvalidDeriveOperationException CreateDeriveException(IReadOnlyCollection<DeriveErrorDetail> details)
        {
            return new InvalidDeriveOperationException(details);
        }

        /// <summary>
        /// Creates <see cref="InvalidDeriveOperationException"/>.
        /// </summary>
        /// <param name="code">Error code.</param>
        /// <param name="reason">Error reason.</param>
        /// <returns>Exception.</returns>
        public static InvalidDeriveOperationException CreateDeriveException(string code, string reason)
        {
            return CreateDeriveException(code, reason, null, null);
        }

        /// <summary>
        /// Creates <see cref="InvalidDeriveOperationException"/>.
        /// </summary>
        /// <param name="code">Error code.</param>
        /// <param name="reason">Error reason.</param>
        /// <param name="requiredAction">Action for which it was not possible to derive the facts.</param>
        /// <param name="container">Fact container.</param>
        /// <returns>Exception.</returns>
        public static InvalidDeriveOperationException CreateDeriveException(string code, string reason, IWantAction requiredAction, IFactContainer container)
        {
            return CreateDeriveException(code, reason, requiredAction , container, null);
        }

        /// <summary>
        /// Creates <see cref="InvalidDeriveOperationException"/>.
        /// </summary>
        /// <param name="code">Error code.</param>
        /// <param name="reason">Error reason.</param>
        /// <param name="requiredAction">Action for which it was not possible to derive the facts.</param>
        /// <param name="container">Fact container.</param>
        /// <param name="requiredFacts">The facts that tried to derive.</param>
        /// <returns>Exception.</returns>
        public static InvalidDeriveOperationException CreateDeriveException(string code, string reason, IWantAction requiredAction, IFactContainer container, IReadOnlyCollection<DeriveFactErrorDetail> requiredFacts)
        {
            return new InvalidDeriveOperationException(new List<DeriveErrorDetail>
            {
                new DeriveErrorDetail(code, reason, requiredAction, container, requiredFacts),
            }.AsReadOnly());
        }
    }
}
