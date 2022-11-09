using GetcuReone.FactFactory.Exceptions.Entities;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Result.
    /// </summary>
    /// <typeparam name="TFactRule">Rule type.</typeparam>
    /// <typeparam name="TWantAction">WantAction type.</typeparam>
    public class BuildTreesForWantActionResult<TFactRule, TWantAction>
        where TFactRule : IFactRule
        where TWantAction : IWantAction
    {
        /// <summary>
        /// WantAction info.
        /// </summary>
        public WantActionInfo<TWantAction> WantActionInfo { get; set; }

        /// <summary>
        /// Errors that occurred while building a tree.
        /// </summary>
        public DeriveErrorDetail DeriveErrorDetail { get; set; }

        /// <summary>
        /// Build trees.
        /// </summary>
        public List<TreeByFactRule<TFactRule, TWantAction>> TreesResult { get; set; }
    }
}
