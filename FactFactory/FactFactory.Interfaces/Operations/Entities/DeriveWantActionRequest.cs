using GetcuReone.FactFactory.Interfaces.Context;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Request.
    /// </summary>
    public class DeriveWantActionRequest
    {
        /// <summary>
        /// The context in which the calculations will be made.
        /// </summary>
        public IWantActionContext Context { get; set; }

        /// <summary>
        /// Collection of rules used for calculations.
        /// </summary>
        public IFactRuleCollection Rules { get; set; }
    }
}
