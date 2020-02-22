using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GetcuReone.FactFactory.Entities
{
    /// <summary>
    /// Rule of fact calculation
    /// </summary>
    public class FactRule : IFactRule
    {
        private readonly Func<IFactContainer, IFact> _func;

        /// <summary>
        /// Information on input factacles rules
        /// </summary>
        public IReadOnlyCollection<IFactType> InputFactTypes { get; }

        /// <summary>
        /// Information on output fact
        /// </summary>
        public IFactType OutputFactType { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="func">func for calculate</param>
        /// <param name="inputFactTypes">information on input factacles rules</param>
        /// <param name="outputFactType">information on output fact</param>
        public FactRule(Func<IFactContainer, IFact> func, List<IFactType> inputFactTypes, IFactType outputFactType)
        {
            _func = func ?? throw new ArgumentNullException(nameof(func));
            InputFactTypes = inputFactTypes != null 
                ? new ReadOnlyCollection<IFactType>(inputFactTypes)
                : new ReadOnlyCollection<IFactType>(new List<IFactType>());
            OutputFactType = outputFactType ?? throw new ArgumentNullException(nameof(outputFactType));
        }

        /// <summary>
        /// Rule of fact calculate
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        public virtual IFact Calculate<TFactContainer>(TFactContainer container) 
            where TFactContainer : IFactContainer
        {
            IFact fact = _func(container);

            if (fact == null)
                throw new InvalidOperationException("Rule cannot return null");

            return fact;
        }

        /// <summary>
        /// is it possible to calculate the fact
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        public virtual bool CanCalculate<TFactContainer>(TFactContainer container) 
            where TFactContainer : IFactContainer
        {
            return InputFactTypes.All(factInfo => factInfo.ContainsContainer(container));
        }

        /// <summary>
        /// Compare rules
        /// </summary>
        /// <typeparam name="TFactRule"></typeparam>
        /// <param name="factRule"></param>
        /// <returns></returns>
        public bool Compare<TFactRule>(TFactRule factRule) where TFactRule : IFactRule
        {
            if (!OutputFactType.Compare(factRule.OutputFactType))
                return false;
            else if (factRule.InputFactTypes.IsNullOrEmpty() && InputFactTypes.IsNullOrEmpty())
                return true;
            else if (InputFactTypes.IsNullOrEmpty() || factRule.InputFactTypes.IsNullOrEmpty())
                return false;
            else if (factRule.InputFactTypes.Count != InputFactTypes.Count)
                return false;
            else
            {
                foreach (var fact in factRule.InputFactTypes)
                {
                    if (InputFactTypes.All(f => !f.Compare(fact)))
                        return false;
                }

                return true;
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"({string.Join(", ", InputFactTypes.Select(f => f.FactName).ToList())}) => ({OutputFactType.FactName})";
        }
    }
}
