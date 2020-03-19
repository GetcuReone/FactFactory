using GetcuReone.FactFactory.Versioned.SpecialFacts;
using System;

namespace GetcuReone.FactFactory.Versioned.Versions
{
    /// <summary>
    /// Base class for <see cref="long"/> based version facts.
    /// </summary>
    public abstract class LongVersionBase : VersionBase<long>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="version">version</param>
        protected LongVersionBase(long version) : base(version)
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
            switch (versionFact)
            {
                case VersionedFactBase<int> version:
                    return Value == version.Value;
                case VersionedFactBase<long> version:
                    return Value == version.Value;
                case VersionedFactBase<uint> version:
                    return Value == version.Value;
                case VersionedFactBase<ulong> version:
                    if (Value < 0)
                        return false;
                    return Convert.ToUInt64(Value) == version.Value;
                default:
                    return false;
            }
        }

        /// <summary>
        /// True - the version of the current fact is less than <paramref name="versionFact"/>.
        /// </summary>
        /// <typeparam name="TVersionFact"></typeparam>
        /// <param name="versionFact"></param>
        /// <returns></returns>
        public override bool IsLessThan<TVersionFact>(TVersionFact versionFact)
        {
            switch (versionFact)
            {
                case VersionedFactBase<int> version:
                    return Value < version.Value;
                case VersionedFactBase<long> version:
                    return Value < version.Value;
                case VersionedFactBase<uint> version:
                    return Value < version.Value;
                case VersionedFactBase<ulong> version:
                    if (Value < 0)
                        return true;
                    return Convert.ToUInt64(Value) < version.Value;
                default:
                    return false;
            }
        }

        /// <summary>
        /// True - the version of the current fact is more than <paramref name="versionFact"/>.
        /// </summary>
        /// <typeparam name="TVersionFact"></typeparam>
        /// <param name="versionFact"></param>
        /// <returns></returns>
        public override bool IsMoreThan<TVersionFact>(TVersionFact versionFact)
        {
            switch (versionFact)
            {
                case VersionedFactBase<int> version:
                    return Value > version.Value;
                case VersionedFactBase<long> version:
                    return Value > version.Value;
                case VersionedFactBase<uint> version:
                    return Value > version.Value;
                case VersionedFactBase<ulong> version:
                    if (Value < 0)
                        return false;
                    return Convert.ToUInt64(Value) > version.Value;
                default:
                    return false;
            }
        }
    }
}
