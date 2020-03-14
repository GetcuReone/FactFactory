using System;

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

        /// <summary>
        /// True - the version of the current fact is equal <paramref name="versionFact"/>.
        /// </summary>
        /// <typeparam name="TVersionFact"></typeparam>
        /// <param name="versionFact"></param>
        /// <returns></returns>
        public override bool EqualVersion<TVersionFact>(TVersionFact versionFact)
        {
            if (versionFact is VersionedFactBase<DateTime> factDateTime)
                return Value == factDateTime.Value;

            return false;
        }

        /// <summary>
        /// True - the version of the current fact is less than <paramref name="versionFact"/>.
        /// </summary>
        /// <typeparam name="TVersionFact"></typeparam>
        /// <param name="versionFact"></param>
        /// <returns></returns>
        public override bool IsLessThan<TVersionFact>(TVersionFact versionFact)
        {
            if (versionFact is VersionedFactBase<DateTime> factDateTime)
                return Value < factDateTime.Value;

            return false;
        }

        /// <summary>
        /// True - the version of the current fact is more than <paramref name="versionFact"/>.
        /// </summary>
        /// <typeparam name="TVersionFact"></typeparam>
        /// <param name="versionFact"></param>
        /// <returns></returns>
        public override bool IsMoreThan<TVersionFact>(TVersionFact versionFact)
        {
            if (versionFact is VersionedFactBase<DateTime> factDateTime)
                return Value > factDateTime.Value;

            return false;
        }
    }
}
