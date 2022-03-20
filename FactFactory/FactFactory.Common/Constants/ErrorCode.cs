using GetcuReone.FactFactory.Interfaces.SpecialFacts;

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
        public const string InvalidData = "InvalidData";

        /// <summary>
        /// Fact cannot be derived.
        /// </summary>
        public const string FactCannotDerived = "FactCannotDerived";

        /// <summary>
        /// Collection of rules for calculating the fact is empty.
        /// </summary>
        public const string EmptyRuleCollection = "EmptyRuleCollection";

        /// <summary>
        /// Rule not found.
        /// </summary>
        public const string RuleNotFound = "RuleNotFound";

        /// <summary>
        /// The fact is of the invalid type.
        /// </summary>
        public const string InvalidFactType = "InvalidFactType";

        /// <summary>
        /// Invalid operation.
        /// </summary>
        public const string InvalidOperation = "InvalidOperation";

        /// <summary>
        /// Failed to meet <see cref="IRuntimeConditionFact.Condition{TFactWork, TFactRule, TWantAction, TFactContainer}(TFactWork, Interfaces.Context.IFactRulesContext{TFactRule, TWantAction, TFactContainer})"/>
        /// and find another solution
        /// </summary>
        public const string RuntimeCondition = "Buildcondition";
    }
}
