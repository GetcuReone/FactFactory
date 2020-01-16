using FactFactory.Helpers;
using FactFactory.Interfaces;

namespace FactFactory.Facts
{
    /// <summary>
    /// Class for facts that cannot be calculated
    /// </summary>
    public sealed class No<TFact> : NoBase
        where TFact : IFact
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public No() : base(FactFactoryHelper.GetFactInfo<TFact>())
        {
        }
    }
}
