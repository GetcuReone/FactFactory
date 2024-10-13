using System;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.SpecialFacts.BuildCondition
{
    /// <inheritdoc/>
    [Obsolete("Use FbCannotDerived")]
    public class BuildCannotDerived<TFact> : FbCannotDerived<TFact> where TFact: IFact { }
}
