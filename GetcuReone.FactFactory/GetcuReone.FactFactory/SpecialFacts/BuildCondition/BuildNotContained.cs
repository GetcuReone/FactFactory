using System;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.SpecialFacts.BuildCondition
{
    /// <inheritdoc/>
    [Obsolete("Use FbNotContained")]
    public class BuildNotContained<TFact> : FbNotContained<TFact> where TFact: IFact { }
}
