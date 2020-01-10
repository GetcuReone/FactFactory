﻿using FactFactory.Interfaces;

namespace FactFactory.Entities
{
    /// <inheritdoc />
    public class FactInfo<TFact> : IFactInfo
        where TFact: IFact
    {
        /// <inheritdoc />
        public string FactName => typeof(TFact).Name;

        /// <inheritdoc />
        public bool Compare<TFactInfo>(TFactInfo factInfo) where TFactInfo : IFactInfo
        {
            return factInfo is FactInfo<TFact>;
        }

        /// <inheritdoc />
        public bool ContainsContainer<TFactContainer>(TFactContainer container)
            where TFactContainer : IFactContainer
        {
            return container.Contains<TFact>();
        }
    }
}