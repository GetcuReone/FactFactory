using GetcuReone.FactFactory.Versioned.Facts;
using GetcuReone.FactFactory.Versioned.Interfaces;

namespace FactFactory.VersionedTests.UintVersion.Env
{
    /// <summary>
    /// base class for factors determining version by number <see cref="uint"/>
    /// </summary>
    public class IntVersion : VersionedFactBase<int>, IVersionFact
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="version"></param>
        public IntVersion(int version) : base(version)
        {
        }

        public bool EqualVersion<TVersionFact>(TVersionFact versionFact) where TVersionFact : IVersionFact
        {
            if (versionFact is IntVersion uintVersion)
                return Value == uintVersion.Value;

            return false;
        }

        /// <summary>
        /// True - the version of the current fact is less than <paramref name="versionFact"/>
        /// </summary>
        /// <typeparam name="TVersionFact"></typeparam>
        /// <param name="versionFact"></param>
        /// <returns></returns>
        public virtual bool IsLessThan<TVersionFact>(TVersionFact versionFact) where TVersionFact : IVersionFact
        {
            if (versionFact is IntVersion uintVersion)
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
            if (versionFact is IntVersion uintVersion)
                return Value > uintVersion.Value;

            return false;
        }
    }
}
