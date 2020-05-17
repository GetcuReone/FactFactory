using GetcuReone.FactFactory.Versioned.Interfaces;

namespace GetcuReone.FactFactory.Versioned
{
    /// <summary>
    /// Base class for versioned facts.
    /// </summary>
    public abstract class VersionedFactBase : FactBase, IVersionedFact
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        protected VersionedFactBase()
            : this(null)
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="version"></param>
        protected VersionedFactBase(IVersionFact version) 
            : this(version, false)
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="version"></param>
        /// <param name="calculatedByRule"></param>
        protected VersionedFactBase(IVersionFact version, bool calculatedByRule)
        {
            Version = version;
            CalculatedByRule = calculatedByRule;
        }

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
        protected VersionedFactBase(TFactValue value) : this(value, null)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="version"></param>
        protected VersionedFactBase(TFactValue value, IVersionFact version)
            : this(value, version, false)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="version"></param>
        /// <param name="calculatedByRule"></param>
        protected VersionedFactBase(TFactValue value, IVersionFact version, bool calculatedByRule)
            : base(version, calculatedByRule)
        {
            Value = value;
        }
    }
}
