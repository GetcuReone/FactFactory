using GetcuReone.FactFactory.Default;
using GetcuReone.FactFactory.Entities;
using Container = GetcuReone.FactFactory.Default.Entities.FactContainer;

namespace FactFactoryTests.FactFactoryT.Env
{
    internal class FactContainerGetOriginal : Container
    {
        public override FactContainerBase<FactBase> Copy()
        {
            return this;
        }
    }
}
