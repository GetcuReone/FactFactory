using System;
using System.Text.RegularExpressions;

namespace GetcuReone.FactFactory.Versioned.SpecialFacts
{
    /// <inheritdoc/>
    [Obsolete("Use BaseMajorMinorPatchVersion (deprecated in 4.0.2)")]
    public abstract class MajorMinorPatchVersionBase : BaseMajorMinorPatchVersion
    {
        private readonly Version _version;

        /// <inheritdoc/>
        protected MajorMinorPatchVersionBase(string version) : base(version)
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
    }
}
