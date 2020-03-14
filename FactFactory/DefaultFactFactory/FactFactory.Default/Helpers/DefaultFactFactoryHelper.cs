using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.Helpers
{
    internal static class DefaultFactFactoryHelper
    {
        internal static IFactType GetFactType<TFact>() where TFact : IFact
        {
            return new FactType<TFact>();
        }
    }
}
