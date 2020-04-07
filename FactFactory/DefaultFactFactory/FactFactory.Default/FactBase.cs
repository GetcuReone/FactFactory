using GetcuReone.FactFactory.Interfaces;
using System;

namespace GetcuReone.FactFactory
{
    /// <summary>
    /// Base class for fact.
    /// </summary>
    public abstract class FactBase : IFact
    {
        /// <summary>
        /// It was calculated using the rule.
        /// </summary>
        public virtual bool CalculatedByRule { get; set; }

        /// <summary>
        /// Get fact type.
        /// </summary>
        /// <returns>fact type</returns>
        public virtual IFactType GetFactType()
        {
            Type genericType = typeof(FactType<>).MakeGenericType(GetType());
            return (IFactType)Activator.CreateInstance(genericType);
        }
    }

    /// <summary>
    /// Base class for typed facts.
    /// </summary>
    /// <typeparam name="TFactValue">Type fact value.</typeparam>
    public abstract class FactBase<TFactValue> : FactBase
    {
        /// <summary>
        /// Value fact.
        /// </summary>
        public virtual TFactValue Value { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="value">Fact value.</param>
        protected FactBase(TFactValue value)
        {
            Value = value;
        }
    }
}
