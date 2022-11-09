using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Basic interface for objects that work directly with facts.
    /// </summary>
    public interface IFactWork
    {
        /// <summary>
        /// Information on input factacles rules.
        /// </summary>
        IReadOnlyCollection<IFactType> InputFactTypes { get; }

        /// <summary>
        /// FactWork option.
        /// </summary>
        FactWorkOption Option { get; }

        /// <summary>
        /// Work equality.
        /// </summary>
        /// <typeparam name="TFactWork"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <param name="workFact">Work with which equality is determined.</param>
        /// <param name="wantAction">The action in the context of which this occurs</param>
        /// <param name="container"></param>
        /// <returns><paramref name="workFact"/> equal <paramref name="wantAction"/>?</returns>
        bool EqualsWork<TFactWork, TWantAction>(TFactWork workFact, TWantAction wantAction, IFactContainer container)
            where TFactWork : IFactWork
            where TWantAction : IWantAction;
    }
}
