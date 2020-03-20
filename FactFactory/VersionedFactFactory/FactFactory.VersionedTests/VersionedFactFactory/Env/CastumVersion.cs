using GetcuReone.FactFactory.Versioned.SpecialFacts;

namespace FactFactory.VersionedTests.VersionedFactFactory.Env
{
    public sealed class CastumVersion : VersionBase<int>
    {
        private bool less;
        private bool more;
        private bool equals;

        public CastumVersion(bool less, bool more, bool equals) : base(default)
        {
            this.less = less;
            this.more = more;
            this.equals = equals;
        }

        public override bool EqualVersion<TVersionFact>(TVersionFact versionFact)
        {
            return equals;
        }

        public override bool IsLessThan<TVersionFact>(TVersionFact versionFact)
        {
            return less;
        }

        public override bool IsMoreThan<TVersionFact>(TVersionFact versionFact)
        {
            return more;
        }
    }
}
