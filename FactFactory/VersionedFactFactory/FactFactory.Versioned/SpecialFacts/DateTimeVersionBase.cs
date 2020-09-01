using GetcuReone.FactFactory.Versioned.Interfaces;
using System;

namespace GetcuReone.FactFactory.Versioned.SpecialFacts
{
    /// <summary>
    /// Base class for <see cref="DateTime"/> based version facts.
    /// </summary>
    public abstract class DateTimeVersionBase : VersionBase<DateTime>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="version">version</param>
        protected DateTimeVersionBase(DateTime version) : base(version)
        {
        }

        /// <inheritdoc/>
        public override int CompareTo(IVersionFact other)
        {
            switch (other)
            {
                case VersionBase<DateTime> version:
                    return VersionValue.CompareTo(version.VersionValue);
                case FactBase<DateTime> version:
                    return VersionValue.CompareTo(version.Value);

                default:
                    throw CreateIncompatibilityVersionException(other);
            }
        }
    }
}
