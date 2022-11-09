using GetcuReone.FactFactory.Interfaces.Context;
using System.Collections.Generic;
using GetcuReone.FactFactory.Exceptions.Entities;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Request for <see cref="ITreeBuildingOperations.TryBuildTreeForFactInfo{TFactRule, TWantAction}(BuildTreeForFactInfoRequest{TFactRule, TWantAction}, out TreeByFactRule{TFactRule, TWantAction}, out List{DeriveFactErrorDetail})"/>.
    /// </summary>
    /// <typeparam name="TFactRule">Rule type.</typeparam>
    /// <typeparam name="TWantAction">WantAction type.</typeparam>
    public class BuildTreeForFactInfoRequest<TFactRule, TWantAction>
        where TFactRule : IFactRule
        where TWantAction : IWantAction
    {
        /// <summary>
        /// The type of fact for which you want to build a tree.
        /// </summary>
        public IFactType WantFactType { get; set; }

        /// <summary>
        /// Context.
        /// </summary>
        public IFactRulesContext<TFactRule, TWantAction> Context { get; set; }
    }
}
