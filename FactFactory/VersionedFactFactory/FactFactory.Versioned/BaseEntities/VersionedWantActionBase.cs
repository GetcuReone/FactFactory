using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned.Helpers;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Versioned.BaseEntities
{
    /// <summary>
    /// Base class containing information about the desired action with the version.
    /// </summary>
    /// <typeparam name="TFactBase"></typeparam>
    public abstract class VersionedWantActionBase<TFactBase> : WantActionBase<TFactBase>, IFactTypeVersionInfo
        where TFactBase : IVersionedFact
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="wantAction">action taken after deriving a fact.</param>
        /// <param name="factTypes">facts required to launch an action.</param>
        protected VersionedWantActionBase(Action<IFactContainer<TFactBase>> wantAction, IReadOnlyCollection<IFactType> factTypes) : base(wantAction, factTypes)
        {
            VersionType = factTypes.SingleOrNullFactVersion();
        }

        /// <summary>
        /// Type fact version.
        /// </summary>
        public IFactType VersionType { get; }

        /// <summary>
        /// True, the current object is more priority than <paramref name="workFact"/>.
        /// </summary>
        /// <typeparam name="TWorkFact"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="workFact"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        public override bool IsMorePriorityThan<TWorkFact, TFactContainer>(TWorkFact workFact, TFactContainer container)
        {
            return VersionedFactFactoryHelper.IsMorePriorityThan(this, workFact, container);
        }

        /// <summary>
        /// True, the current object is less priority than <paramref name="workFact"/>.
        /// </summary>
        /// <typeparam name="TWorkFact"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="workFact"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        public override bool IsLessPriorityThan<TWorkFact, TFactContainer>(TWorkFact workFact, TFactContainer container)
        {
            return VersionedFactFactoryHelper.IsLessPriorityThan(this, workFact, container);
        }
    }
}
