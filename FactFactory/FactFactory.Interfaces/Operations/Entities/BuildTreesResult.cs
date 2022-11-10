using GetcuReone.FactFactory.Exceptions.Entities;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Result.
    /// </summary>
    /// <typeparam name="TFactRule">Rule type.</typeparam>
    public class BuildTreesResult<TFactRule>
        where TFactRule : IFactRule
    {
        /// <summary>
        /// Constructed trees by actions.
        /// </summary>
        public Dictionary<WantActionInfo, List<TreeByFactRule<TFactRule>>> TreesByActions { get; set; }

        /// <summary>
        /// Errors when constructing trees.
        /// </summary>
        public List<DeriveErrorDetail> DeriveErrorDetails { get; set; }
    }
}
