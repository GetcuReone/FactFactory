using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <summary>
    /// Basic interface for objects that work directly with facts.
    /// </summary>
    public abstract class BaseFactWork : IFactWork
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
        protected BaseFactWork(List<IFactType>? factTypes, FactWorkOption option)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            InputFactTypes = !factTypes.IsNullOrEmpty()
#pragma warning restore CS8604 // Possible null reference argument.
                ? factTypes!.AsReadOnly()
                : new ReadOnlyCollection<IFactType>(Array.Empty<IFactType>());

            Option = option;
        }

        /// <summary>
        /// Determining the equality of a set of fact types.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        protected virtual bool EqualsFactTypes(IEnumerable<IFactType>? first, IEnumerable<IFactType>? second)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            if (first.IsNullOrEmpty())
                return second.IsNullOrEmpty();
            else if (second.IsNullOrEmpty())
                return false;
#pragma warning restore CS8604 // Possible null reference argument.
            else if (first!.Count() != second!.Count())
                return false;
            else
            {
                foreach (IFactType fact in second!)
                {
                    if (first!.All(f => !f.EqualsFactType(fact)))
                        return false;
                }

                return true;
            }
        }

        /// <inheritdoc/>
        public virtual bool EqualsWork(IFactWork workFact, IWantAction wantAction, IFactContainer? container)
        {
            return EqualsFactTypes(InputFactTypes, workFact?.InputFactTypes);
        }
    }
}
