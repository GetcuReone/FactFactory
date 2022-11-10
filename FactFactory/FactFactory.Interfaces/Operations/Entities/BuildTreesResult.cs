using GetcuReone.FactFactory.Exceptions.Entities;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Result.
    /// </summary>
    public class BuildTreesResult
    {
        /// <summary>
        /// Constructed trees by actions.
        /// </summary>
        public Dictionary<WantActionInfo, List<TreeByFactRule>> TreesByActions { get; set; }

        /// <summary>
        /// Errors when constructing trees.
        /// </summary>
        public List<DeriveErrorDetail> DeriveErrorDetails { get; set; }
    }
}
