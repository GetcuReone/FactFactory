using FactFactory.Interfaces;

namespace FactFactory.Entities
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
    }
}
