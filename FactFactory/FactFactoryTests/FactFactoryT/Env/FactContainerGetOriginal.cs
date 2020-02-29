using GetcuReone.FactFactory.Facts;
using GetcuReone.FactFactory.Interfaces;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

namespace FactFactoryTests.FactFactoryT.Env
{
    internal class FactContainerGetOriginal : Container
    {
        public override IFactContainer<FactBase> Copy()
        {
            return this;
        }
    }
}
