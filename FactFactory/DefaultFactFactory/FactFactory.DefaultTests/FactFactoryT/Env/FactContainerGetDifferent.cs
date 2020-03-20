using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory;
using Container = GetcuReone.FactFactory.Entities.FactContainer;
using GetcuReone.FactFactory.Interfaces;

namespace FactFactoryTests.FactFactoryT.Env
{
    internal class FactContainerGetDifferent : Container
    {
        public override FactContainerBase<FactBase> Copy()
        {
            return new DifferentContainer();
        }

        private class DifferentContainer : FactContainerBase<FactBase>
        {
            public override FactContainerBase<FactBase> Copy()
            {
                throw new System.NotImplementedException();
            }

            protected override IFactType GetFactType<TGetFact>()
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
