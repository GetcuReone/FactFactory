using GetcuReone.FactFactory.Facts;
using GetcuReone.FactFactory.Interfaces;

namespace FactFactoryTests.FactContainer
{
    public static class FactContainerHelper
    {
        public static IFactContainer<FactBase> AddAndReturn<TFact>(this IFactContainer<FactBase> container, TFact fact)
            where TFact: FactBase
        {
            container.Add(fact);
            return container;
        }

        public static IFactContainer<FactBase> RemoveAndReturn<TFact>(this IFactContainer<FactBase> container)
            where TFact : FactBase
        {
            container.Remove<TFact>();
            return container;
        }
    }
}
