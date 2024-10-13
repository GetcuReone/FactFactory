using GetcuReone.FactFactory.Interfaces.Context;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Request
    /// </summary>
    public class DeriveWantActionRequest
    {
        /// <summary>
        /// The context in which the calculations will be made
        /// </summary>
        public IWantActionContext Context { get; }

        /// <summary>
        /// Collection of rules used for calculations
        /// </summary>
        public IFactRuleCollection Rules { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">The context in which the calculations will be made</param>
        /// <param name="rules">Collection of rules used for calculations</param>
        public DeriveWantActionRequest(IWantActionContext context, IFactRuleCollection rules)
        {
            Context = context;
            Rules = rules;
        }
    }
}
