using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Versioned.Extensions;
using GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System;
using System.Threading.Tasks;

namespace GetcuReone.FactFactory.Versioned
{
    /// <summary>
    /// Base class for versioned fact factory.
    /// </summary>
    /// <inheritdoc/>
    public abstract class BaseVersionedFactFactory : BaseFactFactory
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
        [Obsolete("[5.0.2] Use FactFactoryExtensions.DeriveFact")]
        public virtual TFactResult DeriveFact<TFactResult, TVersion>(IFactContainer container = null)
            where TFactResult : IFact
            where TVersion : IVersionFact
        {
            return FactFactoryExtensions.DeriveFact<TFactResult, TVersion>(this, container); ;
        }

        /// <summary>
        /// Derive <typeparamref name="TFactResult"/> with version.
        /// </summary>
        /// <typeparam name="TFactResult">Type of desired fact.</typeparam>
        /// <typeparam name="TVersion">Type of version fact.</typeparam>
        /// <returns></returns>
        [Obsolete("[5.0.2] Use FactFactoryExtensions.DeriveFactAsync")]
        public virtual ValueTask<TFactResult> DeriveFactAsync<TFactResult, TVersion>(IFactContainer container = null)
            where TFactResult : IFact
            where TVersion : IVersionFact
        {
            return FactFactoryExtensions.DeriveFactAsync<TFactResult, TVersion>(this, container);
        }
    }
}
