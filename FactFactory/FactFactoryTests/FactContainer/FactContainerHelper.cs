using FactFactory.Interfaces;

namespace FactFactoryTests.FactContainer
{
    public static class FactContainerHelper
    {
        public static IFactContainer AddAndReturn<TFact>(this IFactContainer container, TFact fact)
            where TFact: IFact
        {
            container.Add(fact);
            return container;
        }

        public static IFactContainer RemoveAndReturn<TFact>(this IFactContainer container)
            where TFact : IFact
        {
            container.Remove<TFact>();
            return container;
        }
    }
}
