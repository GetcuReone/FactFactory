using GetcuReone.FactFactory.Exceptions.Entities;
using GetcuReone.FactFactory.Interfaces.Context;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Result.
    /// </summary>
    /// <typeparam name="TFactRule">Rule type.</typeparam>
    /// <typeparam name="TWantAction">WantAction type.</typeparam>
    /// <typeparam name="TFactContainer">Fact container type.</typeparam>
    public class BuildTreesResult<TFactRule, TWantAction, TFactContainer>
        where TFactRule : IFactRule
        where TWantAction : IWantAction
        where TFactContainer : IFactContainer
    {
        /// <summary>
        /// Constructed trees by actions.
        /// </summary>
        public Dictionary<WantActionInfo<TWantAction, TFactContainer>, List<TreeByFactRule<TFactRule, TWantAction, TFactContainer>>> TreesByActions { get; set; }

        /// <summary>
        /// Errors when constructing trees.
        /// </summary>
        public List<DeriveErrorDetail> DeriveErrorDetails { get; set; }
    }
}
