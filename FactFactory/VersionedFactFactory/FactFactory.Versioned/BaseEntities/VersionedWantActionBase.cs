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
    public abstract class VersionedWantActionBase : WantActionBase, IFactTypeVersionInfo
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="wantAction">Action taken after deriving a fact.</param>
        /// <param name="factTypes">Facts required to launch an action.</param>
        protected VersionedWantActionBase(Action<IFactContainer> wantAction, List<IFactType> factTypes) : base(wantAction, factTypes)
        {
            VersionType = factTypes.SingleOrNullFactVersion();
        }

        /// <inheritdoc/>
        protected VersionedWantActionBase(Action<IEnumerable<IFact>> wantAction, List<IFactType> factTypes) : base(wantAction, factTypes)
        {
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

            if ((factRule is VersionedFactRuleBase factRuleBase) && (wantAction is VersionedWantActionBase wantActionBase) && (container is VersionedFactContainerBase containerBase))
                return this.СompatibilityWithRuleByVersion<VersionedWantActionBase, VersionedFactRuleBase, VersionedWantActionBase, VersionedFactContainerBase>(factRuleBase, wantActionBase, containerBase);

            return false;
        }
    }
}
