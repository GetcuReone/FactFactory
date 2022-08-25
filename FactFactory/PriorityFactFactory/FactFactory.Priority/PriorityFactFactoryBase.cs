﻿using System;
using GetcuReone.FactFactory.BaseEntities;

namespace GetcuReone.FactFactory.Priority
{
    /// <inheritdoc/>
    [Obsolete("Use BasePriorityFactFactory (deprecated in 4.0.2)")]
    public abstract class PriorityFactFactoryBase<TFactRule, TFactRuleCollection, TWantAction, TFactContainer> : BasePriorityFactFactory<TFactRule, TFactRuleCollection, TWantAction, TFactContainer>
        where TFactRule : FactRuleBase
        where TFactRuleCollection : FactRuleCollectionBase<TFactRule>
        where TWantAction : WantActionBase
        where TFactContainer : FactContainerBase
    {
    }
}
