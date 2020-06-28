using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <summary>
    /// Base class for rules.
    /// </summary>
    /// <typeparam name="TFactBase">The type of fact from which the facts in the container should be inherited</typeparam>
    public abstract class FactRuleBase<TFactBase> : IFactRule<TFactBase>
        where TFactBase : IFact
    {
        private readonly Func<IFactContainer<TFactBase>, IWantAction<TFactBase>, TFactBase> _func;

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
        protected FactRuleBase(Func<IFactContainer<TFactBase>, IWantAction<TFactBase>, TFactBase> func, List<IFactType> inputFactTypes, IFactType outputFactType)
        {
            _func = func ?? throw new ArgumentNullException(nameof(func));
            if (outputFactType == null)
                throw new ArgumentNullException(nameof(outputFactType));

            OutputFactType = outputFactType.CannotIsType<ISpecialFact>(nameof(outputFactType));

            new List<IFactType> { OutputFactType }.CheckArgumentFacts<TFactBase>();

            if (inputFactTypes != null)
            {
                inputFactTypes.CheckArgumentFacts<TFactBase>();

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
        /// <param name="wantAction"></param>
        /// <typeparam name="TContainer"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <returns></returns>
        public virtual TFactBase Calculate<TContainer, TWantAction>(TContainer container, TWantAction wantAction)
            where TContainer : IFactContainer<TFactBase>
            where TWantAction : IWantAction<TFactBase>
        {
            TFactBase fact = _func(container, wantAction);

            if (fact != null)
                fact.CalculatedByRule = true;

            return fact;
        }

        /// <summary>
        /// Is it possible to calculate the fact.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="wantAction"></param>
        /// <typeparam name="TContainer"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <returns></returns>
        public virtual bool CanCalculate<TContainer, TWantAction>(TContainer container, TWantAction wantAction)
            where TContainer : IFactContainer<TFactBase>
            where TWantAction : IWantAction<TFactBase>
        {
            return InputFactTypes.All(factInfo => factInfo.ContainsContainer(container));
        }

        /// <summary>
        /// Compare rules.
        /// </summary>
        /// <typeparam name="TFactRule"></typeparam>
        /// <param name="factRule"></param>
        /// <returns></returns>
        public virtual bool Compare<TFactRule>(TFactRule factRule) where TFactRule : IFactRule<TFactBase>
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

        /// <summary>
        /// True, the current object is more priority than <paramref name="workFact"/>.
        /// </summary>
        /// <typeparam name="TWorkFact"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="workFact"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        public virtual bool IsMorePriorityThan<TWorkFact, TFactContainer>(TWorkFact workFact, TFactContainer container)
            where TWorkFact : IWorkFact<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>
        {
            return false;
        }

        /// <summary>
        /// True, the current object is less priority than <paramref name="workFact"/>.
        /// </summary>
        /// <typeparam name="TWorkFact"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="workFact"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        public virtual bool IsLessPriorityThan<TWorkFact, TFactContainer>(TWorkFact workFact, TFactContainer container)
            where TWorkFact : IWorkFact<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>
        {
            return false;
        }

        /// <summary>
        /// Get the necessary fact types.
        /// </summary>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="wantAction"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        public virtual List<IFactType> GetNecessaryFactTypes<TWantAction, TFactContainer>(TWantAction wantAction, TFactContainer container)
            where TWantAction : IWantAction<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>
        {
            List<IFactType> result = InputFactTypes.ToList();

            foreach(var fact in container)
            {
                IFactType type = fact.GetFactType();
                IFactType notNeedFact = InputFactTypes.FirstOrDefault(t => t.Compare(type));

                if (notNeedFact != null)
                    result.Remove(notNeedFact);
            }

            return result;
        }
    }
}
