using System.Collections.Generic;

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
        /// <returns></returns>
        bool IsFactType<TFact>() where TFact : IFact;

        /// <summary>
        /// Create an fact of this type. Method created for special facts.
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <returns></returns>
        TFact CreateSpecialFact<TFact>() where TFact : IFact;

        /// <summary>
        /// Try to get a fact from the container.
        /// </summary>
        /// <typeparam name="TFact">Type base class for facts.</typeparam>
        /// <param name="facts">Set fact.</param>
        /// <param name="fact">Fact.</param>
        /// <returns>True - it turned out to return the fact</returns>
        bool TryGetFact<TFact>(IEnumerable<TFact> facts, out TFact fact) where TFact : IFact;
    }
}
