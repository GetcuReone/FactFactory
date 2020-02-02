using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.Helpers
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

        internal static InvalidDeriveOperationException CreateDeriveException(Dictionary<IWantAction, Dictionary<IFactType, List<List<IFactType>>>> notFoundFacts)
        {
            List<DeriveErrorDetail> details = new List<DeriveErrorDetail>();

            foreach(var keyAction in notFoundFacts.Keys)
            {
                details.Add(new DeriveErrorDetail(
                    ErrorCode.FactCannotCalculated,
                    $"facts {string.Join(", ", notFoundFacts[keyAction].Keys.Select(k => k.FactName))} cannot be calculated for action {keyAction.ToString()}",
                    keyAction,
                    notFoundFacts[keyAction]));
            }

            return new InvalidDeriveOperationException(details);
        }

        internal static IFactType GeTFactType<TFact>() where TFact : IFact
        {
            return new FactInfo<TFact>();
        }
    }
}
