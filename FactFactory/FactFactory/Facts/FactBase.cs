using FactFactory.Entities;
using FactFactory.Interfaces;

namespace FactFactory.Facts
{
    /// <summary>
    /// Base class for fact
    /// </summary>
    /// <typeparam name="TFact">type fact</typeparam>
    public abstract class FactBase<TFact> : IFact<TFact>
    {
        /// <summary>
        /// Value fact
        /// </summary>
        public virtual TFact Value { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fact"></param>
        protected FactBase(TFact fact)
        {
            Value = fact;
        }

        /// <summary>
        /// Need to insert return new FactInfo{type of your fact}();
        /// </summary>
        /// <returns></returns>
        public abstract IFactInfo GetFactInfo();
    }
}
