using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory;
using Container = GetcuReone.FactFactory.Entities.FactContainer;
using GetcuReone.FactFactory.Interfaces;

namespace FactFactoryTests.FactFactoryT.Env
{
    internal class FactContainerGetNull : Container
    {
        public override IFactContainer<FactBase> Copy()
        {
            return null;
        }
    }
}
