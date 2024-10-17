using System.Threading;
using System.Threading.Tasks;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.Extensions
{
    /// <summary>
    /// Extensions methods for <see cref="IFactFactory"/>.
    /// </summary>
    public static class FactFactoryExtensions
    {
        /// <summary>
        /// Derive <typeparamref name="TFactResult"/>.
        /// </summary>
        /// <typeparam name="TFactResult">The type of fact to get.</typeparam>
        /// <param name="factory">Fact factory.</param>
        /// <param name="container">Fact container.</param>
        /// <returns>Requested fact.</returns>
        public static TFactResult DeriveFact<TFactResult>(this IFactFactory factory, IFactContainer? container = null)
            where TFactResult : IFact
        {
            TFactResult result = default;

            factory.WantFacts((TFactResult fact) =>
            {
                result = fact;
            }, container);

            factory.Derive();

            return result!;
        }

        /// <summary>
        /// Derive <typeparamref name="TFactResult"/>.
        /// </summary>
        /// <typeparam name="TFactResult">The type of fact to get.</typeparam>
        /// <param name="factory">Fact factory.</param>
        /// <param name="container">Fact container.</param>
        /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
        /// <returns>Requested fact.</returns>
        public static async ValueTask<TFactResult> DeriveFactAsync<TFactResult>(
            this IFactFactory factory,
            IFactContainer? container = null,
            CancellationToken cancellationToken = default)
            where TFactResult : IFact
        {
            TFactResult result = default;

            factory.WantFacts((TFactResult fact) =>
            {
                result = fact;
            }, container);

            await factory.DeriveAsync(cancellationToken);

            return result!;
        }
    }
}
