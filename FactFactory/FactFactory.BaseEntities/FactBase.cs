using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetcuReone.FactFactory
{
    /// <summary>
    /// Base class for fact.
    /// </summary>
    public abstract class FactBase : IFact
    {
        /// <inheritdoc/>
        public virtual bool CalculatedByRule { get; set; }

        /// <inheritdoc/>
        public virtual IFactType GetFactType()
        {
            Type genericType = typeof(FactType<>).MakeGenericType(GetType());
            return (IFactType)Activator.CreateInstance(genericType);
        }
    }

    /// /// <inheritdoc/>
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

        /// <summary>
        /// Extract <see cref="FactBase{TFactValue}.Value"/>.
        /// </summary>
        /// <param name="fact"></param>
        public static implicit operator TFactValue(FactBase<TFactValue> fact)
        {
            return fact.Value;
        }
    }
}
