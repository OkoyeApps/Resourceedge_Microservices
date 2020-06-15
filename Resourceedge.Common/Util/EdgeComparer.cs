using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Common.Util
{
    public class EdgeComparer
    {
        public static EdgeComparer<U> Get<U>(Func<U, U, bool> func, string uniqueKey="") { return new EdgeComparer<U>(func, uniqueKey); }
    }
    public class EdgeComparer<T> : EdgeComparer, IEqualityComparer<T>
    {
        private Func<T, T, bool> comparisonFunction;
        private string key;
        public EdgeComparer(Func<T, T, bool> func, string uniqueKey = "") { comparisonFunction = func; key = uniqueKey; }
        public bool Equals(T x, T y) { return comparisonFunction(x, y); }
        public int GetHashCode(T obj) {
            if (string.IsNullOrEmpty(key))
            {
                return obj.GetHashCode();
            }

            return obj.GetType().GetProperty(key).GetHashCode();
        }
    }
}
