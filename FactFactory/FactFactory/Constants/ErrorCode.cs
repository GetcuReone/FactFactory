namespace GetcuReone.FactFactory.Constants
{
    /// <summary>
    /// Error codes.
    /// </summary>
    public static class ErrorCode
    {
        /// <summary>
        /// Invalid data.
        /// </summary>
        public static string InvalidData => "InvalidData";

        /// <summary>
        /// Fact cannot be derived.
        /// </summary>
        public static string FactCannotDerived => "FactCannotDerived";

        /// <summary>
        /// Collection of rules for calculating the fact is empty.
        /// </summary>
        public static string EmptyRuleCollection => "EmptyRuleCollection";

        /// <summary>
        /// Rule not found.
        /// </summary>
        public static string RuleNotFound => "RuleNotFound";

        /// <summary>
        /// The fact is of the invalid type.
        /// </summary>
        public static string InvalidFactType => "InvalidFactType";

        /// <summary>
        /// Invalid operation.
        /// </summary>
        public static string InvalidOperation => "InvalidOperation";
    }
}
