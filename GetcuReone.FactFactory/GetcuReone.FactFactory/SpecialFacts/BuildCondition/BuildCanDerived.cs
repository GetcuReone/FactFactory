using System;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.SpecialFacts.BuildCondition
{
    /// <inheritdoc/>
    [Obsolete("Use FbCanDerived")]
    public class BuildCanDerived<TFact> : FbCanDerived<TFact> where TFact: IFact { }
}
