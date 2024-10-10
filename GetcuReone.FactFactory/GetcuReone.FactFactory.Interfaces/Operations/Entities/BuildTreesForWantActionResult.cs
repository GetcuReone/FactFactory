using GetcuReone.FactFactory.Exceptions.Entities;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Result.
    /// </summary>
    public class BuildTreesForWantActionResult
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
        public List<TreeByFactRule> TreesResult { get; set; }
    }
}
