using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System;

namespace GetcuReone.FactFactory.Extensions
{
    /// <summary>
    /// Extensions for <see cref="IFactType"/>
    /// </summary>
    public static class FactTypeExtensions
    {
        /// <summary>
        /// Checks if a <paramref name="type"/> is fact <see cref="IBuildConditionFact"/> or <see cref="IRuntimeConditionFact"/>.
        /// </summary>
        /// <param name="type">Fact type.</param>
        /// <returns>True - <paramref name="type"/> is <see cref="IBuildConditionFact"/> or <see cref="IRuntimeConditionFact"/>.</returns>
        public static bool IsBuildOrRuntimeFact(this IFactType type)
        {
            return type.IsFactType<IBuildConditionFact>() || type.IsFactType<IRuntimeConditionFact>();
        }

        /// <summary>
        /// Cannot is <typeparamref name="TFact"/>.
        /// </summary>
        /// <typeparam name="TFact">Type fact.</typeparam>
        /// <param name="type">Type fact info.</param>
        /// <param name="paramName">Parameter name.</param>
        /// <returns><paramref name="type"/>.</returns>
        public static IFactType CannotIsType<TFact>(this IFactType type, string paramName)
            where TFact : IFact
        {
            if (type.IsFactType<TFact>())
                throw new ArgumentException($"Parameter {paramName} should not be converted into {typeof(TFact).FullName}");

            return type;
        }
    }
}
