using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.Default.Helpers
{
    internal static class DefaultFactFactoryHelper
    {
        internal static IFactType GetFactType<TFact>() where TFact : IFact
        {
            return new FactType<TFact>();
        }
    }
}
