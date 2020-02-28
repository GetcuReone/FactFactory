using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Fact type
    /// </summary>
    public interface IFactType
    {
        /// <summary>
        /// Compare <see cref="IFactType"/>
        /// </summary>
        /// <param name="factInfo"></param>
        bool Compare<TFactType>(TFactType factInfo) where TFactType : IFactType;

        /// <summary>
        /// Fact name
        /// </summary>
        string FactName { get; }

        /// <summary>
        /// Is it possible to convert a fact type to a <typeparamref name="TFact"/>
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <returns></returns>
        bool IsFactType<TFact>() where TFact : IFact;

        /// <summary>
        /// Return fact. The current fact is not contained in the container.
        /// </summary>
        /// <returns></returns>
        INotContainedFact CreateNotContained();

        /// <summary>
        /// Return an instance of a type <see cref="INoDerivedFact"/> fact in for the current fact type
        /// </summary>
        /// <returns></returns>
        INoDerivedFact CreateNoDerived();

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
