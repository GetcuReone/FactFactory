﻿using GetcuReone.FactFactory.Versioned.SpecialFacts;
using System;

namespace GetcuReone.FactFactory.Versioned.Versions
{
    /// <summary>
    /// Base class for <see cref="int"/> based version facts.
    /// </summary>
    public abstract class IntVersionBase : VersionBase<int>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="version">version</param>
        protected IntVersionBase(int version) : base(version)
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
                    return Value == version;
                case VersionedFactBase<long> version:
                    return Value == version;
                case VersionedFactBase<uint> version:
                    return Value == version;
                case VersionedFactBase<ulong> version:
                    if (Value < 0)
                        return false;
                    return Convert.ToUInt64(Value) == version;

                case FactBase<int> version:
                    return Value == version;
                case FactBase<long> version:
                    return Value == version;
                case FactBase<uint> version:
                    return Value == version;
                case FactBase<ulong> version:
                    if (Value < 0)
                        return false;
                    return Convert.ToUInt64(Value) == version;

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
                    return Value < version;
                case VersionedFactBase<long> version:
                    return Value < version;
                case VersionedFactBase<uint> version:
                    return Value < version;
                case VersionedFactBase<ulong> version:
                    if (Value < 0)
                        return true;
                    return Convert.ToUInt64(Value) < version;

                case FactBase<int> version:
                    return Value < version;
                case FactBase<long> version:
                    return Value < version;
                case FactBase<uint> version:
                    return Value < version;
                case FactBase<ulong> version:
                    if (Value < 0)
                        return true;
                    return Convert.ToUInt64(Value) < version;

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
                    return Value > version;
                case VersionedFactBase<long> version:
                    return Value > version;
                case VersionedFactBase<uint> version:
                    return Value > version;
                case VersionedFactBase<ulong> version:
                    if (Value < 0)
                        return false;
                    return Convert.ToUInt64(Value) > version;

                case FactBase<int> version:
                    return Value > version;
                case FactBase<long> version:
                    return Value > version;
                case FactBase<uint> version:
                    return Value > version;
                case FactBase<ulong> version:
                    if (Value < 0)
                        return false;
                    return Convert.ToUInt64(Value) > version;

                default:
                    return false;
            }
        }
    }
}
