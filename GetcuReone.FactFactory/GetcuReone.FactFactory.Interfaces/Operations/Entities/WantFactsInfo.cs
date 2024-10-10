namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Information about 'WantFacts'.
    /// </summary>
    public class WantFactsInfo
    {
        /// <summary>
        /// WantAction.
        /// </summary>
        public IWantAction WantAction { get; set; }

        /// <summary>
        /// Fact container.
        /// </summary>
        public IFactContainer Container { get; set; }
    }
}
