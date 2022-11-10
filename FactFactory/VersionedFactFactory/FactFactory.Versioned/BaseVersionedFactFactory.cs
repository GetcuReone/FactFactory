using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Interfaces.Operations.Entities;
using GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GetcuReone.FactFactory.Versioned
{
    /// <summary>
    /// Base class for versioned fact factory.
    /// </summary>
    /// <inheritdoc/>
    public abstract class BaseVersionedFactFactory<TFactRuleCollection> : BaseFactFactory<TFactRuleCollection>
        where TFactRuleCollection : BaseFactRuleCollection
    {
        /// <summary>
        /// Returns the <see cref="VersionedSingleEntityOperationsFacade"/>.
        /// </summary>
        /// <returns>Instance <see cref="VersionedSingleEntityOperationsFacade"/>.</returns>
        protected override ISingleEntityOperations GetSingleEntityOperations()
        {
            return GetFacade<VersionedSingleEntityOperationsFacade>();
        }

        /// <summary>
        /// Derive <typeparamref name="TFactResult"/> with version.
        /// </summary>
        /// <typeparam name="TFactResult">Type of desired fact.</typeparam>
        /// <typeparam name="TVersion">Type of version fact.</typeparam>
        /// <returns>Derived fact.</returns>
        public virtual TFactResult DeriveFact<TFactResult, TVersion>(IFactContainer container = null)
            where TFactResult : IFact
            where TVersion : IVersionFact
        {
            TFactResult fact = default;

            var singleOperations = GetSingleEntityOperationsOnce();
            var previousWantFacts = new List<WantFactsInfo>(WantFactsInfos);
            var inputFacts = new List<IFactType> 
            { 
                singleOperations.GetFactType<TFactResult>(),
                singleOperations.GetFactType<TVersion>()
            };
            
            WantFactsInfos.Clear();

            WantFacts(
                singleOperations.CreateWantAction(
                    facts => fact = facts.GetFact<TFactResult>(),
                    inputFacts,
                    FactWorkOption.CanExecuteSync),
                container);

            Derive();

            WantFactsInfos.AddRange(previousWantFacts);

            return fact;
        }

        /// <summary>
        /// Derive <typeparamref name="TFactResult"/> with version.
        /// </summary>
        /// <typeparam name="TFactResult">Type of desired fact.</typeparam>
        /// <typeparam name="TVersion">Type of version fact.</typeparam>
        /// <returns></returns>
        public virtual async ValueTask<TFactResult> DeriveFactAsync<TFactResult, TVersion>(IFactContainer container = null)
            where TFactResult : IFact
            where TVersion : IVersionFact
        {
            TFactResult fact = default;

            var singleOperations = GetSingleEntityOperationsOnce();
            var previousWantFacts = new List<WantFactsInfo>(WantFactsInfos);
            var inputFacts = new List<IFactType> 
            { 
                singleOperations.GetFactType<TFactResult>(), 
                singleOperations.GetFactType<TVersion>()
            };
            
            WantFactsInfos.Clear();

            WantFacts(
                singleOperations.CreateWantAction(
                    facts => fact = facts.GetFact<TFactResult>(),
                    inputFacts,
                    FactWorkOption.CanExecuteSync),
                container);

            await DeriveAsync().ConfigureAwait(false);

            WantFactsInfos.AddRange(previousWantFacts);

            return fact;
        }
    }
}
