using FactFactory.Entities;
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
        public No() : base(GetNoFactInfo<TFact>())
        {
        }

        private static IFactInfo GetNoFactInfo<TFact1>()
            where TFact1 : IFact
        {
            return new FactInfo<TFact1>();
        }
    }
}
