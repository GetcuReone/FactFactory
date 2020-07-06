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

        /// <inheritdoc/>
        public IFactType VersionType { get; }

        /// <inheritdoc/>
        public override List<IFactType> GetNecessaryFactTypes<TFactContainer>(TFactContainer container)
        {
            return InputFactTypes.Where(type => container.GetRightFactByVersionType(type, VersionType) == null).ToList();
        }

        /// <inheritdoc/>
        public override bool СompatibilityWithRule<TFactRule, TWantAction, TFactContainer>(TFactRule factRule, TWantAction wantAction, TFactContainer container)
        {
            if (!base.СompatibilityWithRule(factRule, wantAction, container))
                return false;

            if ((factRule is VersionedFactRuleBase<TFactBase> factRuleBase) && (wantAction is VersionedWantActionBase<TFactBase> wantActionBase) && (container is VersionedFactContainerBase<TFactBase> containerBase))
                return this.СompatibilityWithRuleByVersion<TFactBase, VersionedWantActionBase<TFactBase>, VersionedFactRuleBase<TFactBase>, VersionedWantActionBase<TFactBase>, VersionedFactContainerBase<TFactBase>>(factRuleBase, wantActionBase, containerBase);

            return false;
        }
    }
}
