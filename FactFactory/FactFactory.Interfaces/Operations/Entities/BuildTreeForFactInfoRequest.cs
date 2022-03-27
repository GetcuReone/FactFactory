using GetcuReone.FactFactory.Interfaces.Context;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Request for <see cref="ITreeBuildingOperations.TryBuildTreeForFactInfo{TFactRule, TWantAction, TFactContainer}(BuildTreeForFactInfoRequest{TFactRule, TWantAction, TFactContainer}, out TreeByFactRule{TFactRule, TWantAction, TFactContainer}, out List{Exceptions.Entities.DeriveFactErrorDetail})"/>.
    /// </summary>
    /// <typeparam name="TFactRule">Rule type.</typeparam>
    /// <typeparam name="TWantAction">WantAction type.</typeparam>
    /// <typeparam name="TFactContainer">Fact container type.</typeparam>
    public class BuildTreeForFactInfoRequest<TFactRule, TWantAction, TFactContainer>
        where TFactRule : IFactRule
        where TWantAction : IWantAction
        where TFactContainer : IFactContainer
    {
        /// <summary>
        /// The type of fact for which you want to build a tree.
        /// </summary>
        public IFactType WantFactType { get; set; }

        /// <summary>
        /// Context.
        /// </summary>
        public IFactRulesContext<TFactRule, TWantAction, TFactContainer> Context { get; set; }
    }
}
