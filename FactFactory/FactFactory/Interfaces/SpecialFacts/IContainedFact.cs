namespace GetcuReone.FactFactory.Interfaces.SpecialFacts
{
    /// <summary>
    /// Information about a fact that is contained in the container at the time of the function call <see cref="IFactFactory{TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction}.Derive"/>
    /// </summary>
    public interface IContainedFact : ISpecialFact
    {
    }
}
