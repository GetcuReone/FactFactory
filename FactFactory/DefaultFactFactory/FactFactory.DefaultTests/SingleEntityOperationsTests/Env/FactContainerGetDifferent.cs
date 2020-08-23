using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

namespace FactFactory.DefaultTests.SingleEntityOperationsTests.Env
{
    internal class FactContainerGetDifferent : Container
    {
        public override IFactContainer Copy()
        {
            return new DifferentContainer();
        }

        private class DifferentContainer : FactContainerBase
        {
            public override IFactContainer Copy()
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
