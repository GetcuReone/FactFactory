using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System.Collections.Generic;
using System.Linq;
using CommonHelper = GetcuReone.FactFactory.FactFactoryHelper;

namespace GetcuReone.FactFactory.Versioned.BaseEntities
{
    /// <summary>
    /// Base class for versioned fact container.
    /// </summary>
    public abstract class VersionedFactContainerBase : FactContainerBase
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
            IFactType factType = fact.GetFactType();

            if (fact is ISpecialFact)
            {
                if (ContainerList.Any(f => f.GetFactType().EqualsFactType(factType)))
                    throw CommonHelper.CreateException(ErrorCode.InvalidData, $"The fact container already contains {factType.FactName} type of fact.");
            }
            else
            {
                var factVersion = fact.GetVersionOrNull();
                foreach (var f in ContainerList)
                {
                    if (f.GetFactType().EqualsFactType(factType) && f.HasVersion(factVersion))
                    {
                        if (factVersion != null)
                            throw CommonHelper.CreateException(ErrorCode.InvalidData, $"The container already contains fact type {factType.FactName} with version equal to version {factVersion.GetFactType().FactName}.");
                        else
                            throw CommonHelper.CreateException(ErrorCode.InvalidData, $"The container already contains fact type {factType.FactName} withuot version.");
                    }
                }
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

                if (item.HasVersion(version))
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

        /// <inheritdoc/>
        public override bool Contains<TFact>()
        {
            return ContainsByVersion<TFact>(null);
        }

        /// <inheritdoc/>
        public override bool Contains<TFact>(TFact fact)
        {
            var factType = fact.GetFactType();
            var version = fact.GetVersionOrNull();

            return ContainerList.Exists(f => f.GetFactType().EqualsFactType(factType) && f.HasVersion(version));
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
