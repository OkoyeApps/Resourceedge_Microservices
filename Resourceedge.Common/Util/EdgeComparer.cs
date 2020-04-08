using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Common.Util
{
    public class EdgeComparer
    {
        public static EdgeComparer<U> Get<U>(Func<U, U, bool> func) { return new EdgeComparer<U>(func); }
    }
    public class EdgeComparer<T> : EdgeComparer, IEqualityComparer<T>
    {
        private Func<T, T, bool> comparisonFunction;
        public EdgeComparer(Func<T, T, bool> func) { comparisonFunction = func; }
        public bool Equals(T x, T y) { return comparisonFunction(x, y); }
        public int GetHashCode(T obj) { return obj.GetHashCode(); }
    }
}
