namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Information about 'WantFacts'.
    /// </summary>
    /// <typeparam name="TWantAction">WantAction type.</typeparam>
    public class WantFactsInfo<TWantAction>
        where TWantAction : IWantAction
    {
        /// <summary>
        /// WantAction.
        /// </summary>
        public TWantAction WantAction { get; set; }

        /// <summary>
        /// Fact container.
        /// </summary>
        public IFactContainer Container { get; set; }
    }
}
