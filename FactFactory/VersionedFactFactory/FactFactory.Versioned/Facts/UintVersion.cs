using GetcuReone.FactFactory.Versioned.Interfaces;

namespace GetcuReone.FactFactory.Versioned.Facts
{
    /// <summary>
    /// base class for factors determining version by number <see cref="uint"/>
    /// </summary>
    public abstract class UintVersion : VersionedFactBase<uint>, IVersionFact
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="version"></param>
        protected UintVersion(uint version) : base(version)
        {
        }

        /// <summary>
        /// True - the version of the current fact is less than <paramref name="versionFact"/>
        /// </summary>
        /// <typeparam name="TVersionFact"></typeparam>
        /// <param name="versionFact"></param>
        /// <returns></returns>
        public virtual bool IsLessThan<TVersionFact>(TVersionFact versionFact) where TVersionFact : IVersionFact
        {
            if (versionFact is UintVersion uintVersion)
                return Value < uintVersion.Value;

            return false;
        }

        /// <summary>
        /// True - the version of the current fact is more than <paramref name="versionFact"/>
        /// </summary>
        /// <typeparam name="TVersionFact"></typeparam>
        /// <param name="versionFact"></param>
        /// <returns></returns>
        public virtual bool IsMoreThan<TVersionFact>(TVersionFact versionFact) where TVersionFact : IVersionFact
        {
            if (versionFact is UintVersion uintVersion)
                return Value > uintVersion.Value;

            return false;
        }
    }
}
