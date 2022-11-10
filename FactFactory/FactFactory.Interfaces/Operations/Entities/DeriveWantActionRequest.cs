using GetcuReone.FactFactory.Interfaces.Context;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Request.
    /// </summary>
    /// <typeparam name="TFactRuleCollection">Rule collection type.</typeparam>
    public class DeriveWantActionRequest<TFactRuleCollection>
        where TFactRuleCollection : IFactRuleCollection
    {
        /// <summary>
        /// The context in which the calculations will be made.
        /// </summary>
        public IWantActionContext Context { get; set; }

        /// <summary>
        /// Collection of rules used for calculations.
        /// </summary>
        public TFactRuleCollection Rules { get; set; }
    }
}
