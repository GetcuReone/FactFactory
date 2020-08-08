using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Interfaces;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

namespace FactFactory.DefaultTests.SingleEntityOperationsTests.Env
{
    internal class FactContainerGetNull : Container
    {
        public override IFactContainer<FactBase> Copy()
        {
            return null;
        }
    }
}
