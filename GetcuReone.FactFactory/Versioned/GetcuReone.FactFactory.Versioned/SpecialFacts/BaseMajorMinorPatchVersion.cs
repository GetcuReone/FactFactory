using GetcuReone.FactFactory.Versioned.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace GetcuReone.FactFactory.Versioned.SpecialFacts
{
    /// <summary>
    /// Base class for {major.minor.patch} versions.
    /// </summary>
    public abstract class BaseMajorMinorPatchVersion : BaseVersion<string>
    {
        private readonly Version _version;

        /// <inheritdoc/>
        protected BaseMajorMinorPatchVersion(string version) : base(version)
        {
            if (version == null)
                throw new ArgumentNullException(nameof(version));
            if (string.IsNullOrEmpty(version))
                throw new ArgumentException("version is empty.");

            string pattern = @"^(\*|\d+(\.\d+){0,2}(\.\*)?)$";
            if (!Regex.IsMatch(version, pattern))
                throw new ArgumentException($"{version} version doesn't match regular expression <{pattern}>.");

            _version = new Version(version);
        }

        /// <inheritdoc/>
        public override int CompareTo([AllowNull] IVersionFact other)
        {
            switch (other)
            {
                case BaseMajorMinorPatchVersion version:
                    return _version.CompareTo(version._version);
                case BaseFact<string> version:
                    const string pattern = @"^(\*|\d+(\.\d+){0,2}(\.\*)?)$";

                    if (!Regex.IsMatch(version.Value, pattern))
                        throw new ArgumentException($"{version} version doesn't match regular expression <{pattern}>.");

                    return _version.CompareTo(new Version(version.Value));

                default:
                    throw CreateIncompatibilityVersionException(other);
            }
        }
    }
}
