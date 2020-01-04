using FactFactory.Interfaces;

namespace FactFactoryTests.FactContainer
{
    public static class FactContainerHelper
    {
        public static FactFactory.Entities.FactContainer AddAndReturn<TFact>(this FactFactory.Entities.FactContainer container, TFact fact)
            where TFact: IFact
        {
            container.Add(fact);
            return container;
        }
    }
}
