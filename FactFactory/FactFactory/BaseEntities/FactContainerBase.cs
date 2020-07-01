using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <summary>
    /// Base class for fact container.
    /// </summary>
    public abstract class FactContainerBase<TFactBase> : IFactContainer<TFactBase>, ICopy<FactContainerBase<TFactBase>>
        where TFactBase : IFact
    {
        /// <summary>
        /// List storing facts.
        /// </summary>
        protected List<TFactBase> ContainerList { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the <see cref="IFactContainer{TFact}"/> is read-only.
        /// </summary>
        public bool IsReadOnly { get; internal set; }

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
        protected FactContainerBase(IEnumerable<TFactBase> facts) : this(facts, false) 
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="facts">An array of facts to add to the container.</param>
        /// <param name="isReadOnly"></param>
        protected FactContainerBase(IEnumerable<TFactBase> facts, bool isReadOnly)
        {
            if (facts.IsNullOrEmpty())
                ContainerList = new List<TFactBase>();
            else
                ContainerList = new List<TFactBase>(facts);

            IsReadOnly = isReadOnly;
        }

        /// <summary>
        /// If <see cref="IsReadOnly"/> is true then throw <see cref="FactFactoryException"/>.
        /// </summary>
        /// <exception cref="FactFactoryException">If <see cref="IsReadOnly"/> is true.</exception>
        protected void CheckReadOnly()
        {
            if (IsReadOnly)
                throw FactFactoryHelper.CreateException(ErrorCode.InvalidOperation, $"Fact container is read-only.");
        }

        /// <summary>
        /// Return fact type information.
        /// </summary>
        /// <typeparam name="TGetFact">The type of fact to return information about.</typeparam>
        /// <returns></returns>
        protected abstract IFactType GetFactType<TGetFact>() where TGetFact : TFactBase;

        /// <summary>
        /// Add fact.
        /// </summary>
        /// <param name="fact">Fact.</param>
        /// <typeparam name="TFact">Type of fact to add.</typeparam>
        /// <exception cref="FactFactoryException">Attempt to add an existing fact.</exception>
        public virtual void Add<TFact>(TFact fact) where TFact : TFactBase
        {
            CheckReadOnly();

            IFactType factType = fact.GetFactType();

            if (ContainerList.Any(f => f.GetFactType().EqualsFactType(factType)))
                throw FactFactoryHelper.CreateException(ErrorCode.InvalidFactType, $"The fact container already contains {factType.FactName} type of fact.");

            ContainerList.Add(fact);
        }

        /// <summary>
        /// Is this type of fact contained.
        /// </summary>
        /// <typeparam name="TFact">type of fact to check for.</typeparam>
        /// <returns></returns>
        public virtual bool Contains<TFact>() where TFact : TFactBase
        {
            return TryGetFact(out TFact _);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="FactContainerBase{TFact}"/>.
        /// </summary>
        /// <returns>A <see cref="IEnumerator"/> for the <see cref="FactContainerBase{TFact}"/></returns>
        public virtual IEnumerator<TFactBase> GetEnumerator()
        {
            return ContainerList.GetEnumerator();
        }

        /// <summary>
        /// Get fact.
        /// </summary>
        /// <typeparam name="TFact">Type of fact to return.</typeparam>
        /// <exception cref="FactFactoryException">Did not find fact type <typeparamref name="TFact"/></exception>
        /// <returns></returns>
        public virtual TFact GetFact<TFact>() where TFact : TFactBase
        {
            if (TryGetFact<TFact>(out var fact))
            {
                return fact;
            }

            throw FactFactoryHelper.CreateException(ErrorCode.InvalidData, $"Not found type fact with type {GetFactType<TFact>().FactName}.");
        }

        /// <summary>
        /// Remove fact.
        /// </summary>
        /// <typeparam name="TFact">Type of fact to delete.</typeparam>
        public virtual void Remove<TFact>() where TFact : TFactBase
        {
            if (TryGetFact<TFact>(out var fact))
                Remove(fact);
        }

        /// <summary>
        /// Remove fact.
        /// </summary>
        /// <param name="fact"></param>
        /// <typeparam name="TFact">Type of fact to delete.</typeparam>
        public virtual void Remove<TFact>(TFact fact) where TFact : TFactBase
        {
            CheckReadOnly();

            ContainerList.Remove(fact);
        }

        /// <summary>
        /// Try get fact.
        /// </summary>
        /// <typeparam name="TFact">Type of fact to return.</typeparam>
        /// <param name="fact"></param>
        /// <returns></returns>
        public virtual bool TryGetFact<TFact>(out TFact fact) where TFact : TFactBase
        {
            TFactBase innerFact = ContainerList.SingleOrDefault(item => item is TFact);

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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ContainerList.GetEnumerator();
        }

        /// <summary>
        /// Get copy container.
        /// </summary>
        /// <returns></returns>
        public abstract FactContainerBase<TFactBase> Copy();

        /// <summary>
        /// Clear this container.
        /// </summary>
        public virtual void Clear()
        {
            ContainerList.Clear();
        }
    }
}
