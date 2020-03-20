using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
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
        /// <typeparam name="TFact">Type of fact to add.</typeparam>
        /// <exception cref="FactFactoryException">Attempt to add an existing fact.</exception>
        public override void Add<TFact>(TFact fact)
        {
            CheckReadOnly();

            IFactType factType = fact.GetFactType();

            if (fact.Version == null)
            {
                if (ContainerList.Any(f => f.GetFactType().Compare(factType) && f.Version == null))
                    throw FactFactoryHelper.CreateException(ErrorCode.InvalidData, $"The container already contains fact type {typeof(TFact).FullName} without version.");
            }
            else
            {
                if (ContainerList.Any(f => f.GetFactType().Compare(factType) && f.Version != null && f.Version.EqualVersion(fact.Version)))
                    throw FactFactoryHelper.CreateException(ErrorCode.InvalidData, $"The container already contains fact type {typeof(TFact).FullName} with version equal to version {fact.Version.GetType().FullName}.");
            }

            ContainerList.Add(fact);
        }

        /// <summary>
        /// Try to return a fact of <typeparamref name="TFact"/> type with version equal to <paramref name="version"/>.
        /// </summary>
        /// <typeparam name="TFact">Type of fact you need.</typeparam>
        /// <param name="fact">fact.</param>
        /// <param name="version">Version.</param>
        public virtual bool TryGetFactByVersion<TFact>(out TFact fact, IVersionFact version)
            where TFact : TFactBase
        {
            IFactType type = GetFactType<TFact>();
            TFactBase factBase = version != null
                ? ContainerList.FirstOrDefault(f => f.GetFactType().Compare(type) && f.Version != null && f.Version.EqualVersion(version))
                : ContainerList.FirstOrDefault(f => f.GetFactType().Compare(type) && f.Version == null);

            if (factBase != null)
            {
                fact = (TFact)factBase;
                return true;
            }
            else
            {
                fact = default;
                return false;
            }
        }

        /// <summary>
        /// Try get fact without version. 
        /// </summary>
        /// <typeparam name="TFact">Type of fact to return.</typeparam>
        /// <param name="fact"></param>
        /// <returns></returns>
        public override bool TryGetFact<TFact>(out TFact fact)
        {
            return TryGetFactByVersion(out fact, null);
        }

        /// <summary>
        /// Does an <typeparamref name="TFact"/> type fact with version <paramref name="version"/>.
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <param name="version"></param>
        /// <returns></returns>
        public virtual bool ContainsByVersion<TFact>(IVersionFact version)
            where TFact : TFactBase
        {
            return TryGetFactByVersion(out TFact _, version);
        }

        /// <summary>
        /// Does an <typeparamref name="TFact"/> type fact without version.
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <returns></returns>
        public override bool Contains<TFact>()
        {
            return ContainsByVersion<TFact>(null);
        }

        /// <summary>
        /// Return a fact of <typeparamref name="TFact"/> type with version equal to <paramref name="version"/>.
        /// </summary>
        /// <typeparam name="TFact">Type of fact you need.</typeparam>
        /// <param name="version">Version.</param>
        public virtual TFact GetFactByVersion<TFact>(IVersionFact version)
            where TFact : TFactBase
        {
            if (TryGetFactByVersion(out TFact fact, version))
                return fact;

            string reason = version != null
                ? $"Fact with type {GetFactType<TFact>().FactName} and version {version.GetFactType().FactName} not found."
                : $"Fact with type {GetFactType<TFact>().FactName} and without version.";

            throw FactFactoryHelper.CreateException(ErrorCode.InvalidData, reason);
        }

        /// <summary>
        /// Return a fact of <typeparamref name="TFact"/> type without version.
        /// </summary>
        /// <typeparam name="TFact">Type of fact you need.</typeparam>
        public override TFact GetFact<TFact>()
        {
            return GetFactByVersion<TFact>(null);
        }

        /// <summary>
        /// Remove a fact of <typeparamref name="TFact"/> type with version equal to <paramref name="version"/>.
        /// </summary>
        /// <typeparam name="TFact">Type of fact you need.</typeparam>
        /// <param name="version">Version.</param>
        public virtual void RemoveByVersion<TFact>(IVersionFact version)
            where TFact : TFactBase
        {
            if (TryGetFactByVersion(out TFact fact, version))
                Remove(fact);
        }

        /// <summary>
        /// Remove a fact of <typeparamref name="TFact"/> type without version.
        /// </summary>
        /// <typeparam name="TFact">Type of fact you need.</typeparam>
        public override void Remove<TFact>()
        {
            RemoveByVersion<TFact>(null);
        }
    }
}
