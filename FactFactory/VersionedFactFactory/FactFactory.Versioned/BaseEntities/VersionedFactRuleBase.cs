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
    /// Version rule for calculating a fact.
    /// </summary>
    public abstract class VersionedFactRuleBase : FactRuleBase, IVersionedFactRule
    {
        /// <summary>
        /// Type of fact with rule version.
        /// </summary>
        public IFactType VersionType { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="inputFactTypes"></param>
        /// <param name="outputFactType"></param>
        protected VersionedFactRuleBase(Func<IFactContainer, IWantAction, IFact> func, List<IFactType> inputFactTypes, IFactType outputFactType) : base(func, inputFactTypes, outputFactType)
        {
            outputFactType.CannotIsType<IVersionFact>(nameof(outputFactType));

            VersionType = inputFactTypes?.SingleOrNullFactVersion();
        }

        /// <inheritdoc/>
        public override IFact Calculate<TContainer, TWantAction>(TContainer container, TWantAction wantAction)
        {
            IFact versionedFact = base.Calculate(container, wantAction);

            if (versionedFact != null && (versionedFact is VersionedFactBase versionedFactBase))
            {
                if (VersionType != null)
                    versionedFactBase.Version = (IVersionFact)container.GetRightFactByVersion(VersionType, null);
            }

            return versionedFact;
        }

        /// <inheritdoc/>
        public override bool CanCalculate<TContainer, TWantAction>(TContainer container, TWantAction wantAction)
        {
            IFactType versionType = wantAction is IFactTypeVersionInfo versionInfo
                ? versionInfo.VersionType
                : null;

            IVersionFact version = versionType != null
                ? container.GetVersionFact(versionType)
                : null;

            foreach(var type in InputFactTypes)
            {
                if (container.GetRightFactByVersion(type, version) == null)
                    return false;
            }

            return true;
        }

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
