using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Operations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CommonHelper = GetcuReone.FactFactory.FactFactoryHelper;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <summary>
    /// Base class for fact container.
    /// </summary>
    public abstract class FactContainerBase : IFactContainer, IFactTypeCreation
    {
        /// <summary>
        /// List storing facts.
        /// </summary>
        protected List<IFact> ContainerList { get; private set; }

        /// <inheritdoc/>
        public bool IsReadOnly { get; set; }

        /// <inheritdoc/>
        /// <remarks>If the value is not specified, then <see cref="FactEqualityComparer.GetDefault"/> will be used.</remarks>
        public IEqualityComparer<IFact> EqualityComparer { get; set; }

        /// <inheritdoc/>
        /// <remarks>If the value is not specified, then <see cref="CommonHelper.CompareTo(IFact, IFact)"/> will be used.</remarks>
        public IComparer<IFact> Comparer { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        protected FactContainerBase() : this(null)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="facts">An array of facts to add to the container.</param>
        protected FactContainerBase(IEnumerable<IFact> facts) : this(facts, false) 
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="facts">An array of facts to add to the container.</param>
        /// <param name="isReadOnly"></param>
        protected FactContainerBase(IEnumerable<IFact> facts, bool isReadOnly)
        {
            ContainerList = new List<IFact>();

            if (!facts.IsNullOrEmpty())
            {
                IsReadOnly = false;
                AddRange(facts); 
            }

            IsReadOnly = isReadOnly;
        }

        private IEqualityComparer<IFact> GetEqualityComparer()
        {
            return EqualityComparer ?? FactEqualityComparer.GetDefault();
        }

        private void InnerAdd<TFact>(TFact fact, IEqualityComparer<IFact> comparer) where TFact : IFact
        {
            IFactType factType = fact.GetFactType();

            if (ContainerList.Contains(fact, comparer))
                throw CommonHelper.CreateException(ErrorCode.InvalidData, $"The fact container already contains '{factType.FactName}' fact.");

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
            InnerAdd(fact, GetEqualityComparer());
        }

        /// <inheritdoc/>
        /// <exception cref="FactFactoryException">Attempt to add an existing fact.</exception>
        public virtual void AddRange(IEnumerable<IFact> facts)
        {
            CheckReadOnly();

            var comparer = GetEqualityComparer();
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
            return ContainerList.Contains(fact, GetEqualityComparer());
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
        public virtual bool TryGetFact<TFact>(out TFact fact) where TFact : IFact
        {
            var destFactType = GetFactType<TFact>();
            IFact innerFact = ContainerList
                .Where(f => f.GetFactType().EqualsFactType(destFactType))
                .OrderByDescending(f => f, Comparer ?? Comparer<IFact>.Create((x, y) => x.CompareTo(y)))
                .FirstOrDefault();

            if (innerFact == null)
            {
                fact = default;
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
