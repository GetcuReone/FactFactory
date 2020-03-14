using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <summary>
    /// Base class for rules.
    /// </summary>
    /// <typeparam name="TFact">The type of fact from which the facts in the container should be inherited</typeparam>
    public abstract class FactRuleBase<TFact> : IFactRule<TFact>
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
            if (outputFactType == null)
                throw new ArgumentNullException(nameof(outputFactType));

            OutputFactType = outputFactType.CannotIsType<ISpecialFact>(nameof(outputFactType));

            new List<IFactType> { OutputFactType }.CheckArgumentFacts<TFact>();

            if (inputFactTypes != null)
            {
                inputFactTypes.CheckArgumentFacts<TFact>();

                foreach (IFactType type in inputFactTypes)
                    type.CheckSpecialFactType();

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
        /// <returns></returns>
        public virtual TFact Calculate<TContainer>(TContainer container) where TContainer : IFactContainer<TFact>
        {
            return _func(container);
        }

        /// <summary>
        /// is it possible to calculate the fact.
        /// </summary>
        /// <param name="container"></param>
        /// <typeparam name="TContainer"></typeparam>
        /// <returns></returns>
        public virtual bool CanCalculate<TContainer>(TContainer container) where TContainer : IFactContainer<TFact>
        {
            return InputFactTypes.All(factInfo => factInfo.ContainsContainer(container));
        }

        /// <summary>
        /// Compare rules.
        /// </summary>
        /// <typeparam name="TFactRule"></typeparam>
        /// <param name="factRule"></param>
        /// <returns></returns>
        public virtual bool Compare<TFactRule>(TFactRule factRule) where TFactRule : IFactRule<TFact>
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
