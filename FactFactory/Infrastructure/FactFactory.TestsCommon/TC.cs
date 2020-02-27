namespace FactFactory.TestsCommon
{
    /// <summary>
    /// Test categories.
    /// </summary>
    public static class TC
    {
        /// <summary>
        /// Negative test
        /// </summary>
        public const string Negative = "negative";

        /// <summary>
        /// Test categories for projects.
        /// </summary>
        public static class Projects
        {
            /// <summary>
            /// Refers to the FactFactory.Versioned project
            /// </summary>
            public const string Versioned = "versioned";
        }

        /// <summary>
        /// Categories of objects for testing.
        /// </summary>
        public static class Objects
        {
            /// <summary>
            /// Fact rule <see cref="GetcuReone.FactFactory.Interfaces.IFactRule{TFact}"/>
            /// </summary>
            public const string Rule = "rule";

            /// <summary>
            /// Fact container <see cref="GetcuReone.FactFactory.Interfaces.IFactContainer{TFact}"/>
            /// </summary>
            public const string Container = "container";

            /// <summary>
            /// Desired action <see cref="GetcuReone.FactFactory.Interfaces.IWantAction{TFact}"/>
            /// </summary>
            public const string WantAction = "want_action";

            /// <summary>
            /// Fact factory <see cref="GetcuReone.FactFactory.Interfaces.IFactFactory{TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction}"/>
            /// </summary>
            public const string Factory = "factory";

            /// <summary>
            /// Fact rule collection
            /// </summary>
            public const string RuleCollection = "rule_collection";

            /// <summary>
            /// <see cref="GetcuReone.FactFactory.Interfaces.INotContainedFact"/>
            /// </summary>
            public const string NotContained = "not_contained";

            /// <summary>
            /// <see cref="GetcuReone.FactFactory.Interfaces.INoDerivedFact"/>
            /// </summary>
            public const string NoDerived = "no_derived";
        }
    }
}
