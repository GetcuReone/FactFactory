using System;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.SpecialFacts.RuntimeCondition
{
    /// <inheritdoc/>
    [Obsolete("Use BaseRuntimeConditionFact (deprecated in 4.0.2)")]
    public abstract class RuntimeConditionFactBase : BaseRuntimeConditionFact
    {
    }

    /// <inheritdoc/>
    [Obsolete("Use BaseRuntimeConditionFact (deprecated in 4.0.2)")]
    public abstract class RuntimeConditionFactBase<TFact> : BaseRuntimeConditionFact<TFact>
        where TFact : IFact
    {
    }
}
