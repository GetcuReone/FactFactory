using GetcuReone.FactFactory.Interfaces.Context;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Request.
    /// </summary>
    /// <typeparam name="TFactRule">Type of rules used.</typeparam>
    /// <typeparam name="TFactRuleCollection">Rule collection type.</typeparam>
    /// <typeparam name="TWantAction">Type wantAction</typeparam>
    public class DeriveWantActionRequest<TFactRule, TFactRuleCollection, TWantAction>
        where TFactRule : IFactRule
        where TFactRuleCollection : IFactRuleCollection<TFactRule>
        where TWantAction : IWantAction
    {
        /// <summary>
        /// The context in which the calculations will be made.
        /// </summary>
        public IWantActionContext<TWantAction> Context { get; set; }

        /// <summary>
        /// Collection of rules used for calculations.
        /// </summary>
        public TFactRuleCollection Rules { get; set; }
    }
}
