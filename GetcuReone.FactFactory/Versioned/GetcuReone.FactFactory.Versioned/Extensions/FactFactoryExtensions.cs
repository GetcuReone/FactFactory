using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System.Threading.Tasks;

namespace GetcuReone.FactFactory.Versioned.Extensions
{
    /// <summary>
    /// Extensions methods for <see cref="IFactFactory"/>
    /// </summary>
    public static class FactFactoryExtensions
    {
        /// <summary>
        /// Derive <typeparamref name="TFactResult"/> with version.
        /// </summary>
        /// <typeparam name="TFactResult">The type of fact to get.</typeparam>
        /// <typeparam name="TVersion">The type of fact version to get.</typeparam>
        /// <param name="factory">Fact factory.</param>
        /// <param name="container">Fact container.</param>
        /// <returns>Requested fact.</returns>
        public static TFactResult DeriveFact<TFactResult, TVersion>(this IFactFactory factory, IFactContainer? container = null)
            where TFactResult : IFact
            where TVersion : IVersionFact
        {
            TFactResult result = default;

            factory.WantFacts((TVersion v, TFactResult fact) =>
            {
                result = fact;
            }, container);

            factory.Derive();

            return result!;
        }

        /// <summary>
        /// Derive <typeparamref name="TFactResult"/> with version.
        /// </summary>
        /// <typeparam name="TFactResult">The type of fact to get.</typeparam>
        /// <typeparam name="TVersionFact">The type of fact version to get.</typeparam>
        /// <param name="factory">Fact factory.</param>
        /// <param name="container">Fact container.</param>
        /// <returns>Requested fact.</returns>
        public static async ValueTask<TFactResult> DeriveFactAsync<TFactResult, TVersionFact>(this IFactFactory factory, IFactContainer? container = null)
            where TFactResult : IFact
            where TVersionFact : IVersionFact
        {
            TFactResult result = default;

            factory.WantFacts((TVersionFact v, TFactResult fact) =>
            {
                result = fact;
            }, container);

            await factory.DeriveAsync();

            return result!;
        }
    }
}
