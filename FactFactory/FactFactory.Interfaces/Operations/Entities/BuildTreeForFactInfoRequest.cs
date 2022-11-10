using GetcuReone.FactFactory.Interfaces.Context;
using System.Collections.Generic;
using GetcuReone.FactFactory.Exceptions.Entities;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Request for <see cref="ITreeBuildingOperations.TryBuildTreeForFactInfo{TFactRule}(BuildTreeForFactInfoRequest{TFactRule}, out TreeByFactRule{TFactRule}, out List{DeriveFactErrorDetail})"/>.
    /// </summary>
    /// <typeparam name="TFactRule">Rule type.</typeparam>
    public class BuildTreeForFactInfoRequest<TFactRule>
        where TFactRule : IFactRule
    {
        /// <summary>
        /// The type of fact for which you want to build a tree.
        /// </summary>
        public IFactType WantFactType { get; set; }

        /// <summary>
        /// Context.
        /// </summary>
        public IFactRulesContext<TFactRule> Context { get; set; }
    }
}
