using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned.Helpers;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.Versioned.BaseEntities
{
    /// <summary>
    /// Base class for versioned fact container.
    /// </summary>
    /// <typeparam name="TFactBase"></typeparam>
    public abstract class VersionedFactContainerBase<TFactBase> : FactContainerBase<TFactBase>
        where TFactBase : IVersionedFact
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        protected VersionedFactContainerBase() : base(null)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="facts">An array of facts to add to the container.</param>
        protected VersionedFactContainerBase(IEnumerable<TFactBase> facts) : base(facts, false)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="facts">An array of facts to add to the container.</param>
        /// <param name="isReadOnly"></param>
        protected VersionedFactContainerBase(IEnumerable<TFactBase> facts, bool isReadOnly) : base(facts, isReadOnly)
        {
        }

        /// <summary>
        /// Add fact.
        /// </summary>
        /// <param name="fact">Fact.</param>
        /// <typeparam name="TAddFact">Type of fact to add.</typeparam>
        /// <exception cref="FactFactoryException">Attempt to add an existing fact.</exception>
        public override void Add<TAddFact>(TAddFact fact)
        {
            CheckReadOnly();

            IFactType factType = fact.GetFactType();

            if (fact.Version == null)
            {
                if (ContainerList.Any(f => f.GetFactType().Compare(factType) && f.Version == null))
                    throw FactFactoryHelper.CreateException(ErrorCode.InvalidData, $"The container already contains fact type {typeof(TAddFact).FullName} without version.");
            }
            else
            {
                if (ContainerList.Any(f => f.GetFactType().Compare(factType) && f.Version != null && f.Version.EqualVersion(fact.Version)))
                    throw FactFactoryHelper.CreateException(ErrorCode.InvalidData, $"The container already contains fact type {typeof(TAddFact).FullName} with version equal to version {fact.Version.GetType().FullName}.");
            }

            ContainerList.Add(fact);
        }

        /// <summary>
        /// We are trying to return a fact of type <typeparamref name="TGetFact"/> with a maximum version that is not higher than the requested <paramref name="version"/>.
        /// </summary>
        /// <typeparam name="TGetFact">Type of fact you need.</typeparam>
        /// <param name="fact">fact.</param>
        /// <param name="version">Version.</param>
        public virtual bool TryGetFactByVersion<TGetFact>(out TGetFact fact, IVersionFact version)
            where TGetFact : TFactBase
        {
            fact = default;
            TFactBase searchFact = this.GetFactOrDefaultByVersion(GetFactType<TGetFact>(), version);

            if (searchFact != null)
            {
                fact = (TGetFact)searchFact;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Try get fact with max version. 
        /// </summary>
        /// <typeparam name="TGetFact">Type of fact to return.</typeparam>
        /// <param name="fact"></param>
        /// <returns></returns>
        public override bool TryGetFact<TGetFact>(out TGetFact fact)
        {
            return TryGetFactByVersion(out fact, null);
        }
    }
}
