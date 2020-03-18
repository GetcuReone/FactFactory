using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

namespace FactFactoryTests.FactFactoryT.Env
{
    internal class FactContainerGetNull : Container
    {
        public override FactContainerBase<FactBase> Copy()
        {
            return null;
        }
    }
}
