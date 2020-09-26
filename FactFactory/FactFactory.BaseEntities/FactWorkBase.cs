using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <summary>
    /// Basic interface for objects that work directly with facts.
    /// </summary>
    public abstract class FactWorkBase : IFactWork
    {
        /// <inheritdoc/>
        public IReadOnlyCollection<IFactType> InputFactTypes { get; }

        /// <inheritdoc/>
        public FactWorkOption Option { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="factTypes">Fact types.</param>
        /// <param name="option">FactWork option.</param>
        protected FactWorkBase(List<IFactType> factTypes, FactWorkOption option)
        {
            InputFactTypes = !factTypes.IsNullOrEmpty()
                ? factTypes.AsReadOnly()
                : new List<IFactType>(0).AsReadOnly();

            Option = option;
        }

        /// <summary>
        /// Determining the equality of a set of fact types.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        protected virtual bool EqualsFactTypes(IEnumerable<IFactType> first, IEnumerable<IFactType> second)
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
                    if (first.All(f => !f.EqualsFactType(fact)))
                        return false;
                }

                return true;
            }
        }

        /// <inheritdoc/>
        public virtual bool EqualsWork<TFactWork, TWantAction, TFactContainer>(TFactWork workFact, TWantAction wantAction, TFactContainer container)
            where TFactWork : IFactWork
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            return EqualsFactTypes(InputFactTypes, workFact?.InputFactTypes);
        }
    }
}
