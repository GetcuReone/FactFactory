using GetcuReone.FactFactory.Default;
using GetcuReone.FactFactory.Versioned.Interfaces;

namespace GetcuReone.FactFactory.Versioned
{
    /// <summary>
    /// Base class for versioned facts
    /// </summary>
    public abstract class VersionedFactBase : FactBase, IVersionedFact
    {
        /// <summary>
        /// Version of the rule that calculated the fact.
        /// </summary>
        public virtual IVersionFact Version { get; set; }
    }

    /// <summary>
    /// Base class for versioned typed facts.
    /// </summary>
    /// <typeparam name="TFactValue">Type fact value.</typeparam>
    public abstract class VersionedFactBase<TFactValue> : VersionedFactBase
    {
        /// <summary>
        /// Value fact.
        /// </summary>
        public virtual TFactValue Value { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="value">Fact value.</param>
        protected VersionedFactBase(TFactValue value)
        {
            Value = value;
        }
    }
}
