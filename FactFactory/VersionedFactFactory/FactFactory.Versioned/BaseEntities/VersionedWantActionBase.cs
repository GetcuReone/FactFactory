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
    public abstract class VersionedWantActionBase : WantActionBase, IFactTypeVersionInfo
    {
        /// <inheritdoc/>
        protected VersionedWantActionBase(Action<IEnumerable<IFact>> wantAction, List<IFactType> factTypes) : base(wantAction, factTypes)
        {
            VersionType = factTypes.SingleOrNullFactVersion();
        }

        /// <inheritdoc/>
        public IFactType VersionType { get; }

        /// <inheritdoc/>
        public override bool СompatibilityWithRule<TFactRule, TWantAction, TFactContainer>(TFactRule factRule, TWantAction wantAction, TFactContainer container)
        {
            if (!base.СompatibilityWithRule(factRule, wantAction, container))
                return false;

            if ((factRule is VersionedFactRuleBase factRuleBase) && (wantAction is VersionedWantActionBase wantActionBase) && (container is VersionedFactContainerBase containerBase))
                return this.СompatibilityWithRuleByVersion(factRuleBase, wantActionBase, containerBase);

            return false;
        }
    }
}
