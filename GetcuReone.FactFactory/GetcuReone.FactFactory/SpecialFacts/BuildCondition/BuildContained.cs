using System;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.SpecialFacts.BuildCondition
{
    /// <inheritdoc/>
    [Obsolete("Use FbContained")]
    public class BuildContained<TFact> : FbContained<TFact> where TFact: IFact { }
}
