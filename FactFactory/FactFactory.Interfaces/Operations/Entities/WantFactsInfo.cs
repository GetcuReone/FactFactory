namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Information about 'WantFacts'.
    /// </summary>
    /// <typeparam name="TWantAction">WantAction type.</typeparam>
    /// <typeparam name="TFactContainer">Fact container type.</typeparam>
    public class WantFactsInfo<TWantAction, TFactContainer>
        where TWantAction : IWantAction
        where TFactContainer : IFactContainer
    {
        /// <summary>
        /// WantAction.
        /// </summary>
        public TWantAction WantAction { get; set; }

        /// <summary>
        /// Fact container.
        /// </summary>
        public TFactContainer Container { get; set; }
    }
}
