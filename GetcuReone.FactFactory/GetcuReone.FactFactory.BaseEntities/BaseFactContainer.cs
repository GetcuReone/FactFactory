using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Extensions;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Operations;
using CommonHelper = GetcuReone.FactFactory.FactFactoryHelper;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <summary>
    /// Base class for fact container.
    /// </summary>
    public abstract class BaseFactContainer : IFactContainer, IFactTypeCreation
    {
        /// <summary>
        /// List storing facts.
        /// </summary>
        protected List<IFact> ContainerList { get; private set; }

        /// <inheritdoc/>
        public bool IsReadOnly { get; set; }

        /// <inheritdoc/>
        /// <remarks>If the value is not specified, then <see cref="FactEqualityComparer.GetDefault"/> will be used.</remarks>
        [AllowNull]
        public IEqualityComparer<IFact> EqualityComparer
        {
            get => _equalityComparer ??= FactEqualityComparer.GetDefault();
            set => _equalityComparer = value;
        }
        private IEqualityComparer<IFact>? _equalityComparer;

        /// <inheritdoc/>
        /// <remarks>
        /// If the value is not specified, then <see cref="FactExtensions.CompareTo(IFact, IFact)"/> will be used.
        /// </remarks>
        [AllowNull]
        public IComparer<IFact> Comparer
        {
            get => _comparer ??= Comparer<IFact>.Create((x, y) => x.CompareTo(y));
            set => _comparer = value;
        }
        private IComparer<IFact>? _comparer;

        /// <summary>
        /// Constructor.
        /// </summary>
        protected BaseFactContainer() : this(null)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="facts">An array of facts to add to the container.</param>
        protected BaseFactContainer(IEnumerable<IFact>? facts) : this(facts, false) 
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="facts">An array of facts to add to the container.</param>
        /// <param name="isReadOnly"></param>
        protected BaseFactContainer(IEnumerable<IFact>? facts, bool isReadOnly)
        {
            ContainerList = new List<IFact>();

#pragma warning disable CS8604 // Possible null reference argument.
            if (!facts.IsNullOrEmpty())
#pragma warning restore CS8604 // Possible null reference argument.
            {
                IsReadOnly = false;
                AddRange(facts!); 
            }

            IsReadOnly = isReadOnly;
        }

        private void InnerAdd<TFact>(TFact fact, IEqualityComparer<IFact> comparer) where TFact : IFact
        {
            if (ContainerList.Contains(fact, comparer))
                throw CommonHelper.CreateException(
                    ErrorCode.InvalidData,
                    $"The fact container already contains '{fact.GetFactType().FactName}' fact.");

            ContainerList.Add(fact);
        }

        /// <summary>
        /// If <see cref="IsReadOnly"/> is true then throw <see cref="FactFactoryException"/>.
        /// </summary>
        /// <exception cref="FactFactoryException">If <see cref="IsReadOnly"/> is true.</exception>
        protected virtual void CheckReadOnly()
        {
            if (IsReadOnly)
                throw CommonHelper.CreateException(ErrorCode.InvalidOperation, $"Fact container is read-only.");
        }

        /// <inheritdoc/>
        public virtual IFactType GetFactType<TFact>() where TFact : IFact
        {
            return new FactType<TFact>();
        }

        /// <inheritdoc/>
        /// <exception cref="FactFactoryException">Attempt to add an existing fact.</exception>
        public virtual void Add<TFact>(TFact fact) where TFact : IFact
        {
            CheckReadOnly();
            InnerAdd(fact, EqualityComparer);
        }

        /// <inheritdoc/>
        /// <exception cref="FactFactoryException">Attempt to add an existing fact.</exception>
        public virtual void AddRange(IEnumerable<IFact> facts)
        {
            CheckReadOnly();

            var comparer = EqualityComparer;
            foreach (IFact fact in facts)
                InnerAdd(fact, comparer);
        }

        /// <inheritdoc/>
        public virtual bool Contains<TFact>() where TFact : IFact
        {
            return TryGetFact(out TFact _);
        }

        /// <inheritdoc/>
        public virtual bool Contains<TFact>(TFact fact) where TFact : IFact
        {
            IFactType factType = fact.GetFactType();
            return ContainerList.Contains(fact, EqualityComparer);
        }

        /// <inheritdoc/>
        public virtual IEnumerator<IFact> GetEnumerator()
        {
            return ContainerList.GetEnumerator();
        }

        /// <inheritdoc/>
        /// <exception cref="FactFactoryException">Did not find fact type <typeparamref name="TFact"/>.</exception>
        /// <returns></returns>
        public virtual TFact GetFact<TFact>() where TFact : IFact
        {
            if (TryGetFact<TFact>(out var fact))
            {
                return fact;
            }

            throw CommonHelper.CreateException(ErrorCode.InvalidData, $"Not found type fact with type {GetFactType<TFact>().FactName}.");
        }

        /// <inheritdoc/>
        public virtual void Remove<TFact>() where TFact : IFact
        {
            if (TryGetFact<TFact>(out var fact))
                Remove(fact);
        }

        /// <inheritdoc/>
        public virtual void Remove<TFact>(TFact fact) where TFact : IFact
        {
            CheckReadOnly();

            ContainerList.Remove(fact);
        }

        /// <inheritdoc/>
        public virtual bool TryGetFact<TFact>([NotNullWhen(true)] out TFact fact)
            where TFact : IFact
        {
            var destFactType = GetFactType<TFact>();
            IFact? innerFact = ContainerList
                .Where(f => f.GetFactType().EqualsFactType(destFactType))
                .OrderByDescending(f => f, Comparer)
                .FirstOrDefault();

            if (innerFact == null)
            {
#pragma warning disable CS8601 // Possible null reference assignment.
                fact = default;
#pragma warning restore CS8601 // Possible null reference assignment.
                return false;
            }
            else
            {
                fact = (TFact)innerFact;
                return true;
            }
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ContainerList.GetEnumerator();
        }

        /// <inheritdoc/>
        public virtual void Clear()
        {
            ContainerList.Clear();
        }
    }
}
