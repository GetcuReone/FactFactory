using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GetcuReone.FactFactory.Entities
{
    /// <summary>
    /// Base class for rules.
    /// </summary>
    /// <typeparam name="TFact">The type of fact from which the facts in the container should be inherited</typeparam>
    /// <typeparam name="TFactContainer">The type of container that will be input to the rule.</typeparam>
    public abstract class FactRuleBase<TFact, TFactContainer> : IFactRule<TFact>
        where TFact : IFact
    {
        private readonly Func<IFactContainer<TFact>, TFact> _func;

        /// <summary>
        /// Information on input factacles rules.
        /// </summary>
        public IReadOnlyCollection<IFactType> InputFactTypes { get; }

        /// <summary>
        /// Information on output fact.
        /// </summary>
        public IFactType OutputFactType { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="func">Func for calculate.</param>
        /// <param name="inputFactTypes">Information on input factacles rules.</param>
        /// <param name="outputFactType">Information on output fact.</param>
        /// <exception cref="ArgumentNullException"><paramref name="func"/> or <paramref name="outputFactType"/> is null.</exception>
        /// <exception cref="ArgumentException">The fact is requested at the input, which the rule calculates.</exception>
        protected FactRuleBase(Func<IFactContainer<TFact>, TFact> func, List<IFactType> inputFactTypes, IFactType outputFactType)
        {
            _func = func ?? throw new ArgumentNullException(nameof(func));
            OutputFactType = outputFactType ?? throw new ArgumentNullException(nameof(outputFactType));

            if (inputFactTypes != null)
            {
                if (inputFactTypes.Any(factType => factType.Compare(outputFactType)))
                    throw new ArgumentException("Cannot request a fact calculated according to the rule");

                InputFactTypes = new ReadOnlyCollection<IFactType>(inputFactTypes);
            }
            else
                InputFactTypes = new ReadOnlyCollection<IFactType>(new List<IFactType>());
        }

        /// <summary>
        /// Fact type set comparison
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        protected virtual bool CompareFactTypes(IEnumerable<IFactType> first, IEnumerable<IFactType> second)
        {
            if (first.IsNullOrEmpty() && second.IsNullOrEmpty())
                return true;
            else if (first.IsNullOrEmpty() || second.IsNullOrEmpty())
                return false;
            else if (first.Count() != second.Count())
                return false;
            else
            {
                foreach (var fact in second)
                {
                    if (first.All(f => !f.Compare(fact)))
                        return false;
                }

                return true;
            }
        }

        /// <summary>
        /// Rule of fact calculate.
        /// </summary>
        /// <param name="container"></param>
        /// <typeparam name="TContainer"></typeparam>
        /// <exception cref="InvalidOperationException">The rule did not return a fact.</exception>
        /// <returns></returns>
        public TFact Calculate<TContainer>(TContainer container) where TContainer : IFactContainer<TFact>
        {
            TFact fact = _func(container);

            if (fact == null)
                throw new InvalidOperationException("Rule cannot return null");

            return fact;
        }

        /// <summary>
        /// is it possible to calculate the fact.
        /// </summary>
        /// <param name="container"></param>
        /// <typeparam name="TContainer"></typeparam>
        /// <returns></returns>
        public bool CanCalculate<TContainer>(TContainer container) where TContainer : IFactContainer<TFact>
        {
            return InputFactTypes.All(factInfo => factInfo.ContainsContainer<TFact, TContainer>(container));
        }

        /// <summary>
        /// Compare rules.
        /// </summary>
        /// <typeparam name="TFactRule"></typeparam>
        /// <param name="factRule"></param>
        /// <returns></returns>
        public bool Compare<TFactRule>(TFactRule factRule) where TFactRule : IFactRule<TFact>
        {
            if (!OutputFactType.Compare(factRule.OutputFactType))
                return false;

            return CompareFactTypes(factRule.InputFactTypes, InputFactTypes);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"({string.Join(", ", InputFactTypes.Select(f => f.FactName).ToList())}) => ({OutputFactType.FactName})";
        }
    }
}
