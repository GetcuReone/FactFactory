﻿using GetcuReone.FactFactory.Entities;
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
    public class VersionedFactFactory : VersionedFactFactoryBase<FactRule, VersionedFactRuleCollection, VersionedWantAction, VersionedFactContainer>
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
        /// Returns instances of all used versions.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<IVersionFact> GetAllVersions()
        {
            return _getAllVersionFactsFunc();
        }

        /// <inheritdoc/>
        protected override VersionedWantAction CreateWantAction(Action<IEnumerable<IFact>> wantAction, List<IFactType> factTypes)
        {
            return new VersionedWantAction(wantAction, factTypes);
        }
    }
}
