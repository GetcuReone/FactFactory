using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Versioned.Interfaces;
using GetcuReone.FactFactory.Versioned.SpecialFacts;
using System;
using CommonHelper = GetcuReone.FactFactory.FactFactoryCommonHelper;

namespace GetcuReone.FactFactory.Versioned.Versions
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
                    return ValueVersion.CompareTo(version);
                case VersionedFactBase<DateTime> version:
                    return ValueVersion.CompareTo(version);
                case FactBase<DateTime> version:
                    return ValueVersion.CompareTo(version);

                default:
                    throw CreateIncompatibilityVersionException(other);
            }
        }
    }
}
