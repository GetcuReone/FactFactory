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
    public abstract class FactContainerBase<TFact> : IFactContainer<TFact>, ICopy<FactContainerBase<TFact>>
        where TFact : IFact
    {
        /// <summary>
        /// List storing facts.
        /// </summary>
        protected List<TFact> ContainerList { get; private set; }

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
        protected FactContainerBase(IEnumerable<TFact> facts) : this(facts, false) 
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="facts">An array of facts to add to the container.</param>
        /// <param name="isReadOnly"></param>
        protected FactContainerBase(IEnumerable<TFact> facts, bool isReadOnly)
        {
            if (facts.IsNullOrEmpty())
                ContainerList = new List<TFact>();
            else
                ContainerList = new List<TFact>(facts);

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
        protected abstract IFactType GetFactType<TGetFact>() where TGetFact : TFact;

        /// <summary>
        /// Add fact.
        /// </summary>
        /// <param name="fact">Fact.</param>
        /// <typeparam name="TAddFact">Type of fact to add.</typeparam>
        /// <exception cref="FactFactoryException">Attempt to add an existing fact.</exception>
        public virtual void Add<TAddFact>(TAddFact fact) where TAddFact : TFact
        {
            CheckReadOnly();

            IFactType factType = fact.GetFactType();

            if (ContainerList.Any(f => f.GetFactType().Compare(factType)))
                throw FactFactoryHelper.CreateException(ErrorCode.InvalidFactType, $"The fact container already contains {typeof(TAddFact).FullName} type of fact.");

            ContainerList.Add(fact);
        }

        /// <summary>
        /// Is this type of fact contained.
        /// </summary>
        /// <typeparam name="TContainsFact">type of fact to check for.</typeparam>
        /// <returns></returns>
        public virtual bool Contains<TContainsFact>() where TContainsFact : TFact
        {
            return TryGetFact(out TContainsFact _);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="FactContainerBase{TFact}"/>.
        /// </summary>
        /// <returns>A <see cref="IEnumerator"/> for the <see cref="FactContainerBase{TFact}"/></returns>
        public virtual IEnumerator<TFact> GetEnumerator()
        {
            return ContainerList.GetEnumerator();
        }

        /// <summary>
        /// Get fact.
        /// </summary>
        /// <typeparam name="TGetFact">Type of fact to return.</typeparam>
        /// <exception cref="FactFactoryException">Did not find fact type <typeparamref name="TGetFact"/></exception>
        /// <returns></returns>
        public virtual TGetFact GetFact<TGetFact>() where TGetFact : TFact
        {
            if (TryGetFact<TGetFact>(out var fact))
            {
                return fact;
            }

            throw FactFactoryHelper.CreateException(ErrorCode.InvalidData, $"Not found type fact with type {GetFactType<TGetFact>().FactName}.");
        }

        /// <summary>
        /// Remove fact.
        /// </summary>
        /// <typeparam name="TRemoveFact">Type of fact to delete.</typeparam>
        public virtual void Remove<TRemoveFact>() where TRemoveFact : TFact
        {
            if (TryGetFact<TRemoveFact>(out var fact))
                ContainerList.Remove(fact);
        }

        /// <summary>
        /// Remove fact.
        /// </summary>
        /// <param name="fact"></param>
        /// <typeparam name="TRemoveFact">Type of fact to delete.</typeparam>
        public virtual void Remove<TRemoveFact>(TRemoveFact fact) where TRemoveFact : TFact
        {
            CheckReadOnly();

            ContainerList.Remove(fact);
        }

        /// <summary>
        /// Try get fact.
        /// </summary>
        /// <typeparam name="TGetFact">Type of fact to return.</typeparam>
        /// <param name="fact"></param>
        /// <returns></returns>
        public virtual bool TryGetFact<TGetFact>(out TGetFact fact) where TGetFact : TFact
        {
            TFact innerFact = ContainerList.SingleOrDefault(item => item is TGetFact);

            if (innerFact == null)
            {
                fact = default;
                return false;
            }
            else
            {
                fact = (TGetFact)innerFact;
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
        public abstract FactContainerBase<TFact> Copy();

        /// <summary>
        /// Clear this container.
        /// </summary>
        public virtual void Clear()
        {
            ContainerList.Clear();
        }
    }
}
