﻿using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Container interface with facts for deriving other facts.
    /// </summary>
    public interface IFactContainer : IEnumerable<IFact>
    {
        /// <summary>
        /// Gets a value indicating whether the <see cref="IFactContainer"/> is read-only.
        /// </summary>
        bool IsReadOnly { get; set; }

        /// <summary>
        /// <see cref="IEqualityComparer{T}"/> for <see cref="IFact"/>.
        /// </summary>
        IEqualityComparer<IFact> EqualityComparer { get; set; }

        /// <summary>
        /// <see cref="IComparer{T}"/> for <see cref="IFact"/>.
        /// </summary>
        IComparer<IFact> Comparer { get; set; }

        /// <summary>
        /// Add fact.
        /// </summary>
        /// <param name="fact">Fact.</param>
        /// <typeparam name="TFact">Type of fact to add.</typeparam>
        void Add<TFact>(TFact fact) where TFact : IFact;

        /// <summary>
        /// Add facts.
        /// </summary>
        /// <param name="facts">Fact set.</param>
        void AddRange(IEnumerable<IFact> facts);

        /// <summary>
        /// Remove fact.
        /// </summary>
        /// <typeparam name="TFact">Type of fact to delete.</typeparam>
        void Remove<TFact>() where TFact : IFact;

        /// <summary>
        /// Remove fact.
        /// </summary>
        /// <param name="fact"></param>
        /// <typeparam name="TFact">Type of fact to delete.</typeparam>
        void Remove<TFact>(TFact fact) where TFact : IFact;

        /// <summary>
        /// Try get fact.
        /// </summary>
        /// <typeparam name="TFact">Type of fact to return.</typeparam>
        /// <param name="fact"></param>
        /// <returns></returns>
        bool TryGetFact<TFact>(out TFact fact) where TFact : IFact;

        /// <summary>
        /// Get fact.
        /// </summary>
        /// <typeparam name="TFact">Type of fact to return.</typeparam>
        /// <returns>Fact.</returns>
        TFact GetFact<TFact>() where TFact : IFact;

        /// <summary>
        /// Is this type of fact contained.
        /// </summary>
        /// <typeparam name="TFact">type of fact to check for.</typeparam>
        /// <returns>Did you manage to get the fact?</returns>
        bool Contains<TFact>() where TFact : IFact;

        /// <summary>
        /// Is this type of fact contained.
        /// </summary>
        /// <typeparam name="TFact">type of fact to check for.</typeparam>
        /// <param name="fact">Fact.</param>
        /// <returns>Is the fact contained?</returns>
        bool Contains<TFact>(TFact fact) where TFact : IFact;

        /// <summary>
        /// Clear this container.
        /// </summary>
        void Clear();
    }
}
