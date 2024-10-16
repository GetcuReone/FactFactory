﻿using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Priority.Common.Extensions;
using GetcuReone.FactFactory.Priority.Interfaces;
using System.Linq;

namespace GetcuReone.FactFactory.Priority.Facades.SingleEntityOperations
{
    internal static class PrioritySingleEntityOperationsHelper
    {
        internal static IPriorityFact? FindPriorityFact(this IFactWork factWork, IWantActionContext context)
        {
            var priorityType = factWork.InputFactTypes?.FirstOrDefault(type => type.IsFactType<IPriorityFact>());

            return priorityType != null
                ? context.Container.FirstPriorityFactByFactType(priorityType, context.Cache)
                : null;
        }
    }
}
