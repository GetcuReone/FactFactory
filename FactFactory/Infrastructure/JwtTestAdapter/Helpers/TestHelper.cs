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
                obj => 
                {
                    if (obj == null)
                        return 0;
                    else if (obj.Equals(default))
                        return -1;

                    return 1;
                }));
        }
    }
}
