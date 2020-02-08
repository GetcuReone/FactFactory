using System;
using System.Collections.Generic;

namespace JwtTestAdapter.Entities
{
    internal sealed class EqualityComparer<TObj> : IEqualityComparer<TObj>
    {
        private readonly Func<TObj, TObj, bool> _equalsFunc;
        private readonly Func<TObj, int> _getHashCodeFunc;

        internal EqualityComparer(Func<TObj, TObj, bool> equalsFunc, Func<TObj, int> getHashCodeFunc)
        {
            _equalsFunc = equalsFunc;
            _getHashCodeFunc = getHashCodeFunc;
        }

        public bool Equals(TObj x, TObj y)
        {
            return _equalsFunc(x, y);
        }

        public int GetHashCode(TObj obj)
        {
            return _getHashCodeFunc(obj);
        }
    }
}
