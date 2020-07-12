using GetcuReone.FactFactory.Versioned.SpecialFacts;
using System;

namespace GetcuReone.FactFactory.Versioned.Versions
{
    /// <summary>
    /// Base class for <see cref="ulong"/> based version facts.
    /// </summary>
    public abstract class UlongVersionBase : VersionBase<ulong>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="version">version</param>
        protected UlongVersionBase(ulong version) : base(version)
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
                    if (version < 0)
                        return false;
                    return Value == Convert.ToUInt64(version);
                case VersionedFactBase<long> version:
                    if (version < 0)
                        return false;
                    return Value == Convert.ToUInt64(version);
                case VersionedFactBase<uint> version:
                    return Value == version;
                case VersionedFactBase<ulong> version:
                    return Value == version;

                case FactBase<int> version:
                    if (version < 0)
                        return false;
                    return Value == Convert.ToUInt64(version);
                case FactBase<long> version:
                    if (version < 0)
                        return false;
                    return Value == Convert.ToUInt64(version);
                case FactBase<uint> version:
                    return Value == version;
                case FactBase<ulong> version:
                    return Value == version;

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
                    if (version < 0)
                        return false;
                    return Value < Convert.ToUInt64(version);
                case VersionedFactBase<long> version:
                    if (version < 0)
                        return false;
                    return Value < Convert.ToUInt64(version);
                case VersionedFactBase<uint> version:
                    return Value < version;
                case VersionedFactBase<ulong> version:
                    return Value < version;

                case FactBase<int> version:
                    if (version < 0)
                        return false;
                    return Value < Convert.ToUInt64(version);
                case FactBase<long> version:
                    if (version < 0)
                        return false;
                    return Value < Convert.ToUInt64(version);
                case FactBase<uint> version:
                    return Value < version;
                case FactBase<ulong> version:
                    return Value < version;

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
                    if (version < 0)
                        return true;
                    return Value > Convert.ToUInt64(version);
                case VersionedFactBase<long> version:
                    if (version < 0)
                        return true;
                    return Value > Convert.ToUInt64(version);
                case VersionedFactBase<uint> version:
                    return Value > version;
                case VersionedFactBase<ulong> version:
                    return Value > version;

                case FactBase<int> version:
                    if (version < 0)
                        return true;
                    return Value > Convert.ToUInt64(version);
                case FactBase<long> version:
                    if (version < 0)
                        return true;
                    return Value > Convert.ToUInt64(version);
                case FactBase<uint> version:
                    return Value > version;
                case FactBase<ulong> version:
                    return Value > version;

                default:
                    return false;
            }
        }
    }
}
