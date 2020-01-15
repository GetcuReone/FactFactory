using FactFactory.Consts;
using FactFactory.Entities;
using FactFactory.Exceptions;
using FactFactory.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FactFactory.Helpers
{
    /// <summary>
    /// Helper for <see cref="FactFactoryBase{TFactContainer, TFactRule, TFactRuleCollection, TWantAction}"/>
    /// </summary>
    internal static class FactFactoryHelper
    {
        internal static bool IsNullOrEmpty<TItem>(this IEnumerable<TItem> items)
        {
            return items == null || !items.Any();
        }

        /// <summary>
        /// Create <see cref="FactFactoryException"/>
        /// </summary>
        /// <param name="code">error code</param>
        /// <param name="reason">error reason</param>
        /// <returns></returns>
        internal static FactFactoryException CreateException(string code, string reason)
        {
            return new FactFactoryException(
                new List<ErrorDetail>
                {
                    new ErrorDetail(code, reason)
                });
        }

        /// <summary>
        /// Create <see cref="InvalidDeriveOperationException"/>
        /// </summary>
        /// <param name="code"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        internal static InvalidDeriveOperationException CreateDeriveException(string code, string reason)
        {
            return new InvalidDeriveOperationException(
                new List<DeriveErrorDetail>
                {
                    new DeriveErrorDetail(code, reason, null, null)
                });
        }

        internal static InvalidDeriveOperationException CreateDeriveException(Dictionary<IWantAction, Dictionary<IFactInfo, List<List<IFactInfo>>>> notFoundFacts)
        {
            List<DeriveErrorDetail> details = new List<DeriveErrorDetail>();

            foreach(var keyAction in notFoundFacts.Keys)
            {
                details.Add(new DeriveErrorDetail(
                    ErrorCodes.FactCannotCalculated,
                    $"facts {string.Join(", ", notFoundFacts[keyAction].Keys.Select(k => k.FactName))} cannot be calculated for action {keyAction.ToString()}",
                    keyAction,
                    notFoundFacts[keyAction]));
            }

            return new InvalidDeriveOperationException(details);
        }
    }
}
