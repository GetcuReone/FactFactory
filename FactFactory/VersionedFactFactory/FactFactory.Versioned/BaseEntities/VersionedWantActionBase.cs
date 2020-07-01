using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned.Helpers;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.Versioned.BaseEntities
{
    /// <summary>
    /// Base class containing information about the desired action with the version.
    /// </summary>
    /// <typeparam name="TFactBase"></typeparam>
    public abstract class VersionedWantActionBase<TFactBase> : WantActionBase<TFactBase>, IFactTypeVersionInfo
        where TFactBase : class, IVersionedFact
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="wantAction">Action taken after deriving a fact.</param>
        /// <param name="factTypes">Facts required to launch an action.</param>
        protected VersionedWantActionBase(Action<IFactContainer<TFactBase>> wantAction, List<IFactType> factTypes) : base(wantAction, factTypes)
        {
            VersionType = factTypes.SingleOrNullFactVersion();
        }

        /// <summary>
        /// Type fact version.
        /// </summary>
        public IFactType VersionType { get; }

        /// <summary>
        /// Get the necessary fact types.
        /// </summary>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        public override List<IFactType> GetNecessaryFactTypes<TFactContainer>(TFactContainer container)
        {
            return InputFactTypes.Where(type => container.GetRightFactByVersionType(type, VersionType) == null).ToList();
        }
    }
}
