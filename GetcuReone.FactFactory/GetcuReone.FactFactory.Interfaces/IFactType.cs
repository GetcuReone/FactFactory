using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System;

namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Fact type.
    /// </summary>
    public interface IFactType
    {
        /// <summary>
        /// <see cref="IFactType"/> equality.
        /// </summary>
        /// <param name="factInfo"></param>
        bool EqualsFactType<TFactType>(TFactType factInfo) where TFactType : IFactType;

        /// <summary>
        /// Fact name.
        /// </summary>
        string FactName { get; }

        /// <summary>
        /// Is it possible to convert a fact type to a <typeparamref name="TFact"/>.
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <returns>Can a fact be converted to a <typeparamref name="TFact"/> type.</returns>
        bool IsFactType<TFact>() where TFact : IFact;
        
        /// <summary>
        /// Create an fact of this type. Method created for <see cref="IBuildConditionFact"/>.
        /// </summary>
        /// <typeparam name="TFact">Type fact.</typeparam>
        /// <returns>Instans fact.</returns>
        TFact CreateBuildConditionFact<TFact>() where TFact : IBuildConditionFact;

        /// <summary>
        /// Create an fact of this type. Method created for <see cref="IRuntimeConditionFact"/>.
        /// </summary>
        /// <typeparam name="TFact">Type fact.</typeparam>
        /// <returns>Instans fact.</returns>
        TFact CreateRuntimeConditionFact<TFact>() where TFact : IRuntimeConditionFact;
    }
}
