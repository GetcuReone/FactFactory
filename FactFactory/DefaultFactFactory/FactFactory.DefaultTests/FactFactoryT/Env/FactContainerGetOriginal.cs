using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Default;
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
