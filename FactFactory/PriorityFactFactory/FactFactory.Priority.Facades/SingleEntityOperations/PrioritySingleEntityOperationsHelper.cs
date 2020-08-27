using FactFactory.Priority.Interfaces;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using System.Linq;

namespace GetcuReone.FactFactory.Priority.Facades.SingleEntityOperations
{
    internal static class PrioritySingleEntityOperationsHelper
    {
        internal static IPriorityFact GetPriorityFact<TFactWork, TWantAction, TFactContainer>(this TFactWork factWork, IWantActionContext<TWantAction, TFactContainer> context)
            where TFactWork : IFactWork
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            var priorityType = factWork.InputFactTypes?.FirstOrDefault(type => type.IsFactType<IPriorityFact>());
            return priorityType != null
                ? context.Container.FirstPriorityByFactType(priorityType, context.Cache)
                : null;
        }
    }
}
