﻿using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Operations;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <summary>
    /// Fact type cache.
    /// </summary>
    public class FactTypeCache : IFactTypeCache
    {
        private readonly Dictionary<IFact, IFactType> _cache = new Dictionary<IFact, IFactType>();

        /// <inheritdoc/>
        public virtual IFactType GetFactType(IFact fact)
        {
            if (_cache.ContainsKey(fact))
                return _cache[fact];

            if (_cache.Count > 64)
                lock(_cache)
                    if (_cache.Count > 64)
                        _cache.Remove(_cache.Keys.First());

            lock(fact)
            {
                if (_cache.ContainsKey(fact))
                    return _cache[fact];

                IFactType factType = fact.GetFactType();
                _cache.Add(fact, factType);
                return factType;
            }
        }
    }
}
