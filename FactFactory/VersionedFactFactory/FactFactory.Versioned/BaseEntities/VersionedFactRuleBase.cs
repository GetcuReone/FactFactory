using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned.Helpers;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System;
using System.Collections.Generic;

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

        /// <inheritdoc/>
        protected VersionedFactRuleBase(Func<IEnumerable<IFact>, IFact> func, List<IFactType> inputFactTypes, IFactType outputFactType) : base(func, inputFactTypes, outputFactType)
        {
            outputFactType.CannotIsType<IVersionFact>(nameof(outputFactType));

            VersionType = inputFactTypes?.SingleOrNullFactVersion();
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
