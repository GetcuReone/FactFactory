using GetcuReone.FactFactory.Interfaces;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

namespace FactFactoryTests.SingleEntityOperationsTests.Env
{
    internal class FactContainerGetOriginal : Container
    {
        public override IFactContainer Copy()
        {
            return this;
        }
    }
}
