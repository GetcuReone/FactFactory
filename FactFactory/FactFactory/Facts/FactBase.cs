using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using System;

namespace GetcuReone.FactFactory.Facts
{
    /// <summary>
    /// Base class for fact
    /// </summary>
    /// <typeparam name="TFactValue">type fact</typeparam>
    public abstract class FactBase<TFactValue> : IFact
    {
        /// <summary>
        /// Value fact
        /// </summary>
        public virtual TFactValue Value { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fact"></param>
        protected FactBase(TFactValue fact)
        {
            Value = fact;
        }

        /// <summary>
        /// Get fact type
        /// </summary>
        /// <returns>fact type</returns>
        public virtual IFactType GetFactType()
        {
            Type genericType = typeof(FactInfo<>).MakeGenericType(GetType());
            return (IFactType)Activator.CreateInstance(genericType);
        }
    }
}
