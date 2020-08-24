using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Operations;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <summary>
    /// Fact type cache.
    /// </summary>
    public class FactTypeCache : IFactTypeCache
    {
        //private readonly Dictionary<IFact, IFactType> _cache = new Dictionary<IFact, IFactType>();

        /// <inheritdoc/>
        public IFactType GetFactType<TFact>(TFact fact) where TFact : IFact
        {
            //if (_cache.ContainsKey(fact))
            //    return _cache[fact];

            //IFactType factType = fact.GetFactType();
            //_cache.Add(fact, factType);
            //return factType;

            return fact.GetFactType();
        }
    }
}
