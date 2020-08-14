using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned.Entities;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Versioned
{
    /// <summary>
    /// Default implementation of versioned fact factory <see cref="VersionedFactFactoryBase{TFactContainer, TFactRule, TFactRuleCollection, TWantAction}"/>.
    /// </summary>
    public class VersionedFactFactory : VersionedFactFactoryBase<VersionedFactRule, VersionedFactRuleCollection, VersionedWantAction, VersionedFactContainer>
    {
        private readonly Func<List<IVersionFact>> _getAllVersionFactsFunc;

        /// <summary>
        /// Fact container.
        /// </summary>
        public override VersionedFactContainer Container { get; }

        /// <summary>
        /// Rule collection.
        /// </summary>
        public override VersionedFactRuleCollection Rules { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="getAllVersionFactsFunc">Function that returns all versioned facts used in the rules.</param>
        public VersionedFactFactory(Func<List<IVersionFact>> getAllVersionFactsFunc)
        {
            _getAllVersionFactsFunc = getAllVersionFactsFunc;
            Container = new VersionedFactContainer();
            Rules = new VersionedFactRuleCollection();
        }

        /// <summary>
        /// Creation method <see cref="IWantAction"/>.
        /// </summary>
        /// <param name="wantAction">action taken after deriving a fact.</param>
        /// <param name="factTypes">facts required to launch an action.</param>
        /// <returns></returns>
        protected override VersionedWantAction CreateWantAction(Action<IFactContainer> wantAction, List<IFactType> factTypes)
        {
            return new VersionedWantAction(wantAction, factTypes);
        }

        /// <summary>
        /// Returns instances of all used versions.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<IVersionFact> GetAllVersions()
        {
            return _getAllVersionFactsFunc();
        }
    }
}
