using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Versioned.BaseEntities;
using GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.Versioned
{
    /// <summary>
    /// Base class for versioned fact factory.
    /// </summary>
    public abstract class VersionedFactFactoryBase<TFactRule, TFactRuleCollection, TWantAction, TFactContainer> : FactFactoryBase<TFactRule, TFactRuleCollection, TWantAction, TFactContainer>, IVersionedFactFactory<TFactRule, TFactRuleCollection, TWantAction, TFactContainer>
        where TFactContainer : VersionedFactContainerBase
        where TFactRule : FactRuleBase
        where TFactRuleCollection : VersionedFactRuleCollectionBase<TFactRule>
        where TWantAction : VersionedWantActionBase
    {
        /// <summary>
        /// Returns instances of all used versions.
        /// </summary>
        /// <returns></returns>
        protected abstract IEnumerable<IVersionFact> GetAllVersions();

        /// <inheritdoc/>
        protected override IEnumerable<IFact> GetDefaultFacts(TFactContainer container)
        {
            IEnumerable<IFact> allVersionFacts = GetAllVersions() ?? Enumerable.Empty<IFact>();

            List<IVersionFact> defaultVersions = container.Where(version => version is IVersionFact).Select(version => (IVersionFact)version).ToList();
            List<IFactType> defaultVersionTypes = defaultVersions.ConvertAll(version => version.GetFactType());

            foreach(var version in allVersionFacts)
            {
                if (defaultVersionTypes.All(defaultVersion => !defaultVersion.EqualsFactType(version.GetFactType())))
                    defaultVersions.Add((IVersionFact)version);
            }

            return defaultVersions;
        }

        /// <inheritdoc/>
        public override ISingleEntityOperations GetSingleEntityOperations()
        {
            return GetFacade<VersionedSingleEntityOperationsFacade>();
        }

        /// <summary>
        /// Derive <typeparamref name="TFact"/> with version.
        /// </summary>
        /// <typeparam name="TFact">Type of desired fact.</typeparam>
        /// <typeparam name="TVersion">Type of version fact.</typeparam>
        /// <returns></returns>
        public virtual TFact DeriveFact<TFact, TVersion>()
            where TFact : IFact
            where TVersion : IVersionFact
        {
            TFact fact = default;

            var wantActions = new List<TWantAction>(WantActions);
            WantActions.Clear();

            var inputFacts = new List<IFactType> { GetFactType<TFact>(), GetFactType<TVersion>() };

            WantFact(CreateWantAction(
                facts => fact = facts.GetFact<TFact>(),
                inputFacts));

            Derive();

            WantActions.AddRange(wantActions);

            return fact;
        }
    }
}
