using GetcuReone.FactFactory.Interfaces.Operations.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GetcuReone.FactFactory.Interfaces.Operations
{
    /// <summary>
    /// Engine for calculating facts
    /// </summary>
    public interface IFactEngine
    {
        /// <summary>
        /// Build a trees and calculate facts for <paramref name="requests"/>.
        /// </summary>
        /// <param name="requests">Requests.</param>
        void DeriveWantAction(List<DeriveWantActionRequest> requests);

        /// <summary>
        /// Build a trees and calculate facts for <paramref name="requests"/>.
        /// </summary>
        /// <param name="requests">Requests.</param>
        ValueTask DeriveWantActionAsync(List<DeriveWantActionRequest> requests);
    }
}
