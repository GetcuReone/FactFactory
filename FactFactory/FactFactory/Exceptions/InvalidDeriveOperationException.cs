using FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FactFactory.Exceptions
{
    /// <summary>
    /// <see cref="InvalidOperationException"/> for method <see cref="IFactFactory{TFactRule, TFactRuleCollection}.Derive"/>
    /// </summary>
    public class InvalidDeriveOperationException : InvalidOperationException
    {
        /// <summary>
        /// A set of fact sets for which no rules were found
        /// </summary>
        public ReadOnlyCollection<ReadOnlyCollection<IFactInfo>> NotFoundRuleForFactsSet { get; }

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="message"></param>
        /// <param name="notFoundRuleForFactsSet">a set of fact sets for which no rules were found</param>
        public InvalidDeriveOperationException(string message, List<List<IFactInfo>> notFoundRuleForFactsSet) : base(message)
        {
            NotFoundRuleForFactsSet = new ReadOnlyCollection<ReadOnlyCollection<IFactInfo>>(
                notFoundRuleForFactsSet.ConvertAll(notFoundRuleForFacts => new ReadOnlyCollection<IFactInfo>(notFoundRuleForFacts)));
        }
    }
}
