using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CommonHelper = GetcuReone.FactFactory.FactFactoryCommonHelper;

[assembly: InternalsVisibleToAttribute("FactFactory")]

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <summary>
    /// Base class for fact container.
    /// </summary>
    public abstract class FactContainerBase<TFactBase> : IFactContainer<TFactBase>, ICopy<FactContainerBase<TFactBase>>, IFactTypeCreation
        where TFactBase : IFact
    {
        /// <summary>
        /// List storing facts.
        /// </summary>
        protected List<IFact> ContainerList { get; private set; }

        /// <inheritdoc/>
        public bool IsReadOnly { get; set; }

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

        private void InnerAdd<TFact>(TFact fact) where TFact : IFact
        {
            fact.ValidateTypeOfFact<TFactBase>();

            IFactType factType = fact.GetFactType();

            if (ContainerList.Any(f => f.GetFactType().EqualsFactType(factType)))
                throw CommonHelper.CreateException(ErrorCode.InvalidFactType, $"The fact container already contains {factType.FactName} type of fact.");

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
            InnerAdd(fact);
        }

        /// <inheritdoc/>
        /// <exception cref="FactFactoryException">Attempt to add an existing fact.</exception>
        public virtual void AddRange(IEnumerable<IFact> facts)
        {
            CheckReadOnly();

            foreach (IFact fact in facts)
                InnerAdd(fact);
        }

        /// <inheritdoc/>
        public virtual bool Contains<TFact>() where TFact : IFact
        {
            return TryGetFact(out TFact _);
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
            IFact innerFact = ContainerList.SingleOrDefault(item => item is TFact);

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
        public abstract FactContainerBase<TFactBase> Copy();

        /// <inheritdoc/>
        public virtual void Clear()
        {
            ContainerList.Clear();
        }
    }
}
