using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.Facts
{
    /// <summary>
    /// Base class for facts that cannot be calculated
    /// </summary>
    public abstract class NoDerivedBase : FactBase<IFactType>, INoDerivedFact
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fact"></param>
        protected NoDerivedBase(IFactType fact) : base(fact)
        {
        }
    }
}
