using GetcuReone.FactFactory.Interfaces;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

namespace FactFactory.DefaultTests.SingleEntityOperationsTests.Env
{
    internal class FactContainerGetOriginal : Container
    {
        public override IFactContainer Copy()
        {
            return this;
        }
    }
}
