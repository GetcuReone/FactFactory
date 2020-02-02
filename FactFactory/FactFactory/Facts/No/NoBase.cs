using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.Facts
{
    /// <summary>
    /// Base class for facts that cannot be calculated
    /// </summary>
    public abstract class NoBase : FactBase<IFactInfo>, INoFact
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fact"></param>
        protected NoBase(IFactInfo fact) : base(fact)
        {
        }
    }
}
