using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System;
using System.Collections.Generic;
using CommonHelper = GetcuReone.FactFactory.FactFactoryHelper;

namespace GetcuReone.FactFactory.Versioned.BaseEntities
{
    /// <summary>
    /// Base class for versioned fact container.
    /// </summary>
    [Obsolete("Use FactContainerBase. FactContainerBase class has become universal")]
    public abstract class VersionedFactContainerBase : FactContainerBase
    {
        /// <inheritdoc/>
        protected VersionedFactContainerBase() : base(null)
        {
        }

        /// <inheritdoc/>
        protected VersionedFactContainerBase(IEnumerable<IFact> facts) : base(facts, false)
        {
        }

        /// <inheritdoc/>
        protected VersionedFactContainerBase(IEnumerable<IFact> facts, bool isReadOnly) : base(facts, isReadOnly)
        {
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

                if (item.HasVersionParameter(version))
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
