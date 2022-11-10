using GetcuReone.FactFactory.Exceptions.Entities;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Result.
    /// </summary>
    /// <typeparam name="TFactRule">Rule type.</typeparam>
    public class BuildTreesForWantActionResult<TFactRule>
        where TFactRule : IFactRule
    {
        /// <summary>
        /// WantAction info.
        /// </summary>
        public WantActionInfo WantActionInfo { get; set; }

        /// <summary>
        /// Errors that occurred while building a tree.
        /// </summary>
        public DeriveErrorDetail DeriveErrorDetail { get; set; }

        /// <summary>
        /// Build trees.
        /// </summary>
        public List<TreeByFactRule<TFactRule>> TreesResult { get; set; }
    }
}
