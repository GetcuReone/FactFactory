using GetcuReone.FactFactory.Exceptions.Entities;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Result.
    /// </summary>
    /// <typeparam name="TFactRule">Rule type.</typeparam>
    /// <typeparam name="TWantAction">WantAction type.</typeparam>
    public class BuildTreesResult<TFactRule, TWantAction>
        where TFactRule : IFactRule
        where TWantAction : IWantAction
    {
        /// <summary>
        /// Constructed trees by actions.
        /// </summary>
        public Dictionary<WantActionInfo<TWantAction>, List<TreeByFactRule<TFactRule, TWantAction>>> TreesByActions { get; set; }

        /// <summary>
        /// Errors when constructing trees.
        /// </summary>
        public List<DeriveErrorDetail> DeriveErrorDetails { get; set; }
    }
}
