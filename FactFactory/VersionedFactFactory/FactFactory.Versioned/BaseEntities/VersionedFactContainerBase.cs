using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System.Collections.Generic;
using System.Linq;
using CommonHelper = GetcuReone.FactFactory.FactFactoryCommonHelper;

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
        protected VersionedFactContainerBase(IEnumerable<IFact> facts) : base(facts, false)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="facts">An array of facts to add to the container.</param>
        /// <param name="isReadOnly"></param>
        protected VersionedFactContainerBase(IEnumerable<IFact> facts, bool isReadOnly) : base(facts, isReadOnly)
        {
        }

        private void InnerAdd<TFact>(TFact fact) where TFact : IFact
        {
            fact.ValidateTypeOfFact<TFactBase>();
            IFactType factType = fact.GetFactType();

            if (fact is TFactBase factBase)
            {
                if (factBase.Version == null)
                {
                    if (ContainerList.Any(f => f.GetFactType().EqualsFactType(factType) && ((TFactBase)f).Version == null))
                        throw CommonHelper.CreateException(ErrorCode.InvalidData, $"The container already contains fact type {typeof(TFact).FullName} without version.");
                }
                else
                {
                    if (ContainerList.Any(f => f.GetFactType().EqualsFactType(factType) && (f is TFactBase factBase1) && factBase1.Version != null && factBase1.Version.EqualVersion(factBase.Version)))
                        throw CommonHelper.CreateException(ErrorCode.InvalidData, $"The container already contains fact type {typeof(TFact).FullName} with version equal to version {factBase.Version.GetType().FullName}.");
                } 
            }
            else
            {
                if (ContainerList.Any(f => f.GetFactType().EqualsFactType(factType)))
                    throw CommonHelper.CreateException(ErrorCode.InvalidFactType, $"The fact container already contains {factType.FactName} type of fact.");
            }

            ContainerList.Add(fact);
        }

        /// <inheritdoc/>
        public override void Add<TFact>(TFact fact)
        {
            CheckReadOnly();
            InnerAdd(fact);
        }

        /// <inheritdoc/>
        public override void AddRange(IEnumerable<IFact> facts)
        {
            CheckReadOnly();

            foreach (IFact fact in facts)
                InnerAdd(fact);
        }

        /// <summary>
        /// Try to return a fact of <typeparamref name="TFact"/> type with version equal to <paramref name="version"/>.
        /// </summary>
        /// <typeparam name="TFact">Type of fact you need.</typeparam>
        /// <param name="fact">fact.</param>
        /// <param name="version">Version.</param>
        public virtual bool TryGetFactByVersion<TFact>(out TFact fact, IVersionFact version)
            where TFact : IFact
        {
            IFactType type = GetFactType<TFact>();

            if (type.IsFactType<ISpecialFact>())
                return base.TryGetFact(out fact);

            foreach(IFact item in ContainerList)
            {
                if (item is ISpecialFact)
                    continue;

                IFactType itemType = item.GetFactType();
                if (!itemType.EqualsFactType(type))
                    continue;

                var factBase = (TFactBase)item;

                if (version != null && factBase.Version != null && factBase.Version.EqualVersion(version))
                {
                    fact = (TFact)item;
                    return true;
                }
                else if (version == null && factBase.Version == null)
                {
                    fact = (TFact)item;
                    return true;
                }
            }

            fact = default;
            return false;
        }

        /// <inheritdoc/>
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
            where TFact : IFact
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
            where TFact : IFact
        {
            if (TryGetFactByVersion(out TFact fact, version))
                return fact;

            string reason = version != null
                ? $"Fact with type {GetFactType<TFact>().FactName} and version {version.GetFactType().FactName} not found."
                : $"Fact with type {GetFactType<TFact>().FactName} and without version.";

            throw CommonHelper.CreateException(ErrorCode.InvalidData, reason);
        }

        /// <inheritdoc/>
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
            where TFact : IFact
        {
            if (TryGetFactByVersion(out TFact fact, version))
                Remove(fact);
        }

        /// <inheritdoc/>
        public override void Remove<TFact>()
        {
            RemoveByVersion<TFact>(null);
        }
    }
}
