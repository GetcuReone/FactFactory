using GetcuReone.FactFactory;
using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

namespace FactFactory.DefaultTests.SingleEntityOperationsTests.Env
{
    internal class FactContainerGetDifferent : Container
    {
        public override IFactContainer<FactBase> Copy()
        {
            return new DifferentContainer();
        }

        private class DifferentContainer : FactContainerBase<FactBase>
        {
            public override IFactContainer<FactBase> Copy()
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
