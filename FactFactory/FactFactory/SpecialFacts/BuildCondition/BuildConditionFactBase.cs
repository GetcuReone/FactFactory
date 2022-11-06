using System;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.SpecialFacts.BuildCondition
{
    /// <inheritdoc/>
    [Obsolete("Use BuildConditionFactBase (deprecated in 4.0.2)")]
    public abstract class BuildConditionFactBase : BaseBuildConditionFact { }

    /// <inheritdoc/>
    [Obsolete("Use BuildConditionFactBase (deprecated in 4.0.2)")]
    public abstract class BuildConditionFactBase<TFact> : BaseBuildConditionFact<TFact>
        where TFact : IFact { }
}
