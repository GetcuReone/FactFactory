using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        public static TFactResult DeriveFact<TFactResult>(this IFactFactory factory, IFactContainer container = null)
            where TFactResult : IFact
        {
            TFactResult result = default;

            factory.WantFacts((TFactResult fact) =>
            {
                result = fact;
            }, container);

            factory.Derive();

            return result;
        }

        /// <summary>
        /// Derive <typeparamref name="TFactResult"/>.
        /// </summary>
        /// <typeparam name="TFactResult">The type of fact to get.</typeparam>
        /// <param name="factory">Fact factory.</param>
        /// <param name="container">Fact container.</param>
        /// <returns>Requested fact.</returns>
        public static async ValueTask<TFactResult> DeriveFactAsync<TFactResult>(this IFactFactory factory, IFactContainer container = null)
            where TFactResult : IFact
        {
            TFactResult result = default;

            factory.WantFacts((TFactResult fact) =>
            {
                result = fact;
            }, container);

            await factory.DeriveAsync();

            return result;
        }
    }
}
