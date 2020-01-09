using FactFactory.Entities;
using FactFactory.Interfaces;
using System;
using System.Reflection;

namespace FactFactory.Facts
{
    /// <summary>
    /// Base class for fact
    /// </summary>
    /// <typeparam name="TFactValue">type fact</typeparam>
    public abstract class FactBase<TFactValue> : IFact<TFactValue>
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

        private IFactInfo CreateFactInfo<TFact>()
            where TFact: FactBase<TFactValue>
        {
            return new FactInfo<TFact>();
        }

        /// <summary>
        /// Must return FactInfo{type of your fact}();
        /// </summary>
        /// <returns></returns>
        public virtual IFactInfo GetFactInfo()
        {
            MethodInfo method = typeof(FactBase<TFactValue>).GetMethod("CreateFactInfo", BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo generic = method.MakeGenericMethod(GetType());

            return (IFactInfo)generic.Invoke(this, null);
        }

    }
}
