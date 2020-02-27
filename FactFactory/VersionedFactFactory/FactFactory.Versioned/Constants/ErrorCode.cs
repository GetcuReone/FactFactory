namespace GetcuReone.FactFactory.Versioned.Constants
{
    /// <summary>
    /// Codes for errors in work <see cref="VersionedFactFactoryBase{TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction}"/>
    /// </summary>
    public static class ErrorCode
    {
        /// <summary>
        /// 'VersionNotFound'. No fact was found in the container with information about the required version
        /// </summary>
        public static string VersionNotFound => "VersionNotFound";

        /// <summary>
        /// Version conflict
        /// </summary>
        public static string VersionConflict => "VersionConflict";

        /// <summary>
        /// There should be only one version fact
        /// </summary>
        public static string OnlyOneVersionFact => "OnlyOneVersionFact";
    }
}
