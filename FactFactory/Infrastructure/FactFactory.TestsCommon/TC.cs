﻿namespace FactFactory.TestsCommon
{
    /// <summary>
    /// Test categories.
    /// </summary>
    public static class TC
    {
        /// <summary>
        /// Test categories for projects.
        /// </summary>
        public static class Projects
        {
            /// <summary>
            /// Refers to the FactFactory.Versioned project.
            /// </summary>
            public const string Versioned = "versioned_test";

            /// <summary>
            /// Refers to the FactFactory.Priority project.
            /// </summary>
            public const string Priority = "priority_test";
        }

        /// <summary>
        /// Categories of objects for testing.
        /// </summary>
        public static class Objects
        {
            /// <summary>
            /// Fact rule <see cref="GetcuReone.FactFactory.Interfaces.IFactRule{TFact}"/>.
            /// </summary>
            public const string Rule = "rule_test";

            /// <summary>
            /// Fact container <see cref="GetcuReone.FactFactory.Interfaces.IFactContainer{TFact}"/>.
            /// </summary>
            public const string Container = "container_test";

            /// <summary>
            /// Desired action <see cref="GetcuReone.FactFactory.Interfaces.IWantAction{TFact}"/>.
            /// </summary>
            public const string WantAction = "want_action_test";

            /// <summary>
            /// Fact factory <see cref="GetcuReone.FactFactory.Interfaces.IFactFactory{TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction}"/>.
            /// </summary>
            public const string Factory = "factory_test";

            /// <summary>
            /// Fact rule collection
            /// </summary>
            public const string RuleCollection = "rule_collection_test";

            /// <summary>
            /// <see cref="GetcuReone.FactFactory.SpecialFacts.BuildContained{TFact}"/>.
            /// </summary>
            public const string BuildContained = "build_contained_test";

            /// <summary>
            /// <see cref="GetcuReone.FactFactory.SpecialFacts.BuildNotContained{TFact}"/>.
            /// </summary>
            public const string BuildNotContained = "build_not_contained_test";

            /// <summary>
            /// <see cref="GetcuReone.FactFactory.SpecialFacts.BuildCannotDerived{TFact}"/>.
            /// </summary>
            public const string BuildCannotDerived = "build_cannot_derived_test";

            /// <summary>
            /// <see cref="GetcuReone.FactFactory.SpecialFacts.CanDerived{TFact}"/>.
            /// </summary>
            public const string BuildCanDerived = "build_can_derived_test";

            /// <summary>
            /// <see cref="GetcuReone.FactFactory.Interfaces.IFact"/>.
            /// </summary>
            public const string Fact = "fact_test";

            /// <summary>
            /// <see cref="GetcuReone.FactFactory.Interfaces.IFactType"/>.
            /// </summary>
            public const string FactType = "fact_type_test";
        }
    }
}
