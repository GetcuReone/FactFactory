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
        /// Work equality.
        /// </summary>
        /// <typeparam name="TFactWork"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="workFact">Work with which equality is determined.</param>
        /// <param name="wantAction">The action in the context of which this occurs</param>
        /// <param name="container"></param>
        /// <returns></returns>
        bool EqualsWork<TFactWork, TWantAction, TFactContainer>(TFactWork workFact, TWantAction wantAction, TFactContainer container)
            where TFactWork : IFactWork
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;

        /// <summary>
        /// Is the <paramref name="factRule"/> rule compatible with the current <see cref="IFactWork"/>.
        /// </summary>
        /// <typeparam name="TFactRule"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="factRule">Compatibility check rule.</param>
        /// <param name="wantAction">The action within which compatibility check.</param>
        /// <param name="container">Container.</param>
        /// <returns></returns>
        bool СompatibilityWithRule<TFactRule, TWantAction, TFactContainer>(TFactRule factRule, TWantAction wantAction, TFactContainer container)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;
    }
}
