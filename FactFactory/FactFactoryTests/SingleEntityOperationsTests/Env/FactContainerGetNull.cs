using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Interfaces;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

namespace FactFactoryTests.SingleEntityOperationsTests.Env
{
    internal class FactContainerGetNull : Container
    {
        public override IFactContainer Copy()
        {
            return null;
        }
    }
}
