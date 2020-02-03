using System;
using System.Collections.Generic;
using System.Linq;

namespace JwtTestAdapter.Helpers
{
    public static class TestHelper
    {
        public static IEnumerable<TObj> DistinctByFunc<TObj>(this IEnumerable<TObj> collection, Func<TObj, TObj, bool> equalsFunc)
        {
            if (equalsFunc == null)
                throw new ArgumentNullException(nameof(equalsFunc));

            return collection.Distinct(new Entities.EqualityComparer<TObj>(
                equalsFunc,
                obj => obj == default 
                    ? 0
                    : 1));
        }
    }
}
