namespace GetcuReone.FactFactory.Versioned.Constants
{
    /// <summary>
    /// Codes for errors in work <see cref="Interfaces.IVersionedFactFactory{TFactRule, TFactRuleCollection, TWantAction, TFactContainer}"/>.
    /// </summary>
    public static class VersionedErrorCode
    {
        /// <summary>
        /// 'VersionNotFound'. No fact was found in the container with information about the required version.
        /// </summary>
        public const string VersionNotFound = "VersionNotFound";
    }
}
