using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Exceptions.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GetcuReone.FactFactory.Helpers
{
    /// <summary>
    /// Helper for <see cref="FactFactoryBase{TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction}"/>
    /// </summary>
    public static class FactFactoryHelper
    {
        internal static void VerifyRecursive<TRuntimeSpecialFact, TFactBase, TFactRule>(this TRuntimeSpecialFact runtimeSpecialFact, TFactRule factRule)
            where TRuntimeSpecialFact : IRuntimeSpecialFact
            where TFactBase : IFact
            where TFactRule : IFactRule<TFactBase>
        {
            if (runtimeSpecialFact.FactType.EqualsFactType(factRule.OutputFactType))
                throw FactFactoryCommonHelper.CreateDeriveException<TFactBase>(ErrorCode.FactCannotDerived, $"Rule of fact is recursive. Rule: <{factRule}>.");
        }

        internal static InvalidDeriveOperationException<TFact> CreateDeriveException<TFact>(List<KeyValuePair<string, string>> codeReasonPairs, IWantAction<TFact> requiredAction)
            where TFact : IFact
        {
            return new InvalidDeriveOperationException<TFact>(codeReasonPairs
                .Select(
                    pair => new DeriveErrorDetail<TFact>(pair.Key, pair.Value, requiredAction, null))
                .ToList().ToReadOnlyCollection());
        }

        internal static IFactType GetFactType<TFact>() where TFact : IFact
        {
            return new FactType<TFact>();
        }

        internal static TFact ConvertFact<TFact>(this IFact fact)
            where TFact : IFact
        {
            if (fact is TFact fact1)
                return fact1;

            throw FactFactoryCommonHelper.CreateDeriveException<TFact>(ErrorCode.InvalidFactType, $"Type {fact.GetFactType().FactName} cannot be converted {typeof(TFact).Name}");
        }

        internal static IgnoreReadOnlySpace<TFact> CreateIgnoreReadOnlySpace<TFact>(this FactContainerBase<TFact> container)
            where TFact : IFact
        {
            return new IgnoreReadOnlySpace<TFact>(container);
        }

        internal static void CheckSpecialFactType(this IFactType type)
        {
            if (type.IsFactType<ISpecialFact>())
            {
                var specialResult = new bool[]
                {
                    type.IsFactType<INotContainedFact>(),
                    type.IsFactType<IContainedFact>(),
                    type.IsFactType<ICannotDerivedFact>(),
                    type.IsFactType<ICanDerivedFact>(),
                };

                if (specialResult.Count(result => result == true) > 1)
                {
                    throw FactFactoryCommonHelper.CreateException(ErrorCode.InvalidFactType, $"{type.FactName} implements more than one runtime special fact interface.");
                }
            }
        }

        internal static IFactType GetDefaultFactType<TFact>() where TFact : IFact
        {
            return new FactType<TFact>();
        }
    }
}
