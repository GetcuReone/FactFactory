using GetcuReone.FactFactory.Exceptions.Entities;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Result
    /// </summary>
    public class BuildTreesForWantActionResult
    {
        /// <summary>
        /// WantAction info
        /// </summary>
        public WantActionInfo WantActionInfo { get; }

        /// <summary>
        /// Errors that occurred while building a tree
        /// </summary>
        public DeriveErrorDetail? DeriveErrorDetail { get; set; }

        /// <summary>
        /// Build trees
        /// </summary>
        public List<TreeByFactRule> TreesResult { get; set; } = new List<TreeByFactRule>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="wantActionInfo">WantAction info</param>
        public BuildTreesForWantActionResult(WantActionInfo wantActionInfo)
        {
            WantActionInfo = wantActionInfo;
        }
    }
}
