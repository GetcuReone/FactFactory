using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Interfaces.Operations.Entities;
using GetcuReone.FactFactory.Versioned.BaseEntities;
using GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Versioned
{
    /// <summary>
    /// Base class for versioned fact factory.
    /// </summary>
    public abstract class VersionedFactFactoryBase<TFactRule, TFactRuleCollection, TWantAction, TFactContainer> : FactFactoryBase<TFactRule, TFactRuleCollection, TWantAction, TFactContainer>
        where TFactContainer : VersionedFactContainerBase
        where TFactRule : FactRuleBase
        where TFactRuleCollection : FactRuleCollectionBase<TFactRule>
        where TWantAction : WantActionBase
    {
        /// <inheritdoc/>
        public override ISingleEntityOperations GetSingleEntityOperations()
        {
            return GetFacade<VersionedSingleEntityOperationsFacade>();
        }

        /// <summary>
        /// Derive <typeparamref name="TFactResult"/> with version.
        /// </summary>
        /// <typeparam name="TFactResult">Type of desired fact.</typeparam>
        /// <typeparam name="TVersion">Type of version fact.</typeparam>
        /// <returns></returns>
        public virtual TFactResult DeriveFact<TFactResult, TVersion>(TFactContainer container = null)
            where TFactResult : IFact
            where TVersion : IVersionFact
        {
            TFactResult fact = default;

            var previousWantFacts = new List<WantFactsInfo<TWantAction, TFactContainer>>(WantFactsInfos);
            WantFactsInfos.Clear();

            var inputFacts = new List<IFactType> { GetFactType<TFactResult>(), GetFactType<TVersion>() };

            WantFacts(
                CreateWantAction(
                    facts => fact = facts.GetFact<TFactResult>(),
                    inputFacts),
                container);

            Derive();

            WantFactsInfos.AddRange(previousWantFacts);

            return fact;
        }
    }
}
