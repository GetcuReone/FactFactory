using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned.Entities;
using GetcuReone.FactFactory.Versioned.Facts;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.Versioned
{
    /// <summary>
    /// Default implementation of versioned fact factory <see cref="VersionedFactFactoryBase{TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction}"/>
    /// </summary>
    public class VersionedFactFactory : VersionedFactFactoryBase<VersionedFactBase, VersionedFactContainer, VersionedFactRule, VersionedFactRuleCollection, VersionedWantAction>
    {
        private readonly Func<List<IVersionFact>> _getAllVersionFactsFunc;

        /// <summary>
        /// Fact container
        /// </summary>
        public override VersionedFactContainer Container { get; }

        /// <summary>
        /// Rule collection
        /// </summary>
        public override VersionedFactRuleCollection Rules { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="getAllVersionFactsFunc">function that returns all versioned facts used in the rules</param>
        public VersionedFactFactory(Func<List<IVersionFact>> getAllVersionFactsFunc)
        {
            _getAllVersionFactsFunc = getAllVersionFactsFunc;
            Container = new VersionedFactContainer();
            Rules = new VersionedFactRuleCollection();
        }

        /// <summary>
        /// creation method <see cref="IWantAction{TFact}"/>
        /// </summary>
        /// <param name="wantAction">action taken after deriving a fact</param>
        /// <param name="factTypes">facts required to launch an action</param>
        /// <returns></returns>
        protected override VersionedWantAction CreateWantAction(Action<IFactContainer<VersionedFactBase>> wantAction, IList<IFactType> factTypes)
        {
            return new VersionedWantAction(wantAction, factTypes);
        }

        /// <summary>
        /// Returns a copy of the container filled with version facts
        /// </summary>
        /// <returns>copy of the container filled with version facts</returns>
        protected override VersionedFactContainer GetContainerForDerive()
        {
            return new VersionedFactContainer(Container); ;
        }

        /// <summary>
        /// Get fact type
        /// </summary>
        /// <typeparam name="TGetFact"></typeparam>
        /// <returns></returns>
        protected override IFactType GetFactType<TGetFact>()
        {
            return new FactType<TGetFact>();
        }

        /// <summary>
        /// Returns instances of all used versions
        /// </summary>
        /// <returns></returns>
        protected override List<IVersionFact> GetAllVersions()
        {
            return _getAllVersionFactsFunc();
        }
    }
}
