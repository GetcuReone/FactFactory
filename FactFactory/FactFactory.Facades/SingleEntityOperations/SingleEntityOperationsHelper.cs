﻿using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.Facades.SingleEntityOperations
{
    /// <summary>
    /// Helper.
    /// </summary>
    public static class SingleEntityOperationsHelper
    {
        /// <summary>
        /// Set a parameter indicating that the fact was calculated using the rule.
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <param name="fact"></param>
        public static TFact SetCalculateByRule<TFact>(this TFact fact)
            where TFact : IFact
        {
            fact.AddParameter(new FactParameter(FactParametersCodes.CalculateByRule, true));
            return fact;
        }

        /// <summary>
        /// Get <see cref="FactContainerWriter"/> writer.
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        public static FactContainerWriter GetWriter(this IFactContainer container)
        {
            return new FactContainerWriter(container);
        }
    }
}
