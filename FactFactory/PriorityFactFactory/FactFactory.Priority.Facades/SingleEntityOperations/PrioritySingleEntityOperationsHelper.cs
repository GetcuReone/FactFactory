using FactFactory.Priority.Interfaces;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using System.Linq;

namespace GetcuReone.FactFactory.Priority.Facades.SingleEntityOperations
{
    internal static class PrioritySingleEntityOperationsHelper
    {
        internal static IPriorityFact GetPriorityFact<TFactWork>(this TFactWork factWork, IWantActionContext context)
            where TFactWork : IFactWork
        {
            var priorityType = factWork.InputFactTypes?.FirstOrDefault(type => type.IsFactType<IPriorityFact>());
            return priorityType != null
                ? context.Container.FirstPriorityFactByFactType(priorityType, context.Cache)
                : null;
        }
    }
}
