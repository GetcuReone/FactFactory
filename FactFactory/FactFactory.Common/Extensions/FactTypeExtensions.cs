using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;

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
    }
}
