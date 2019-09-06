using System.Linq;
using Threading;
using System.Collections.Generic;
using Threading;

namespace DotNetNative.Extensions
{
    public static class IEnumerableExtensions
    {
        public static ThreadSafeList<T> ToThreadSafeList<T>(this IEnumerable<T> collection)
        {
            ThreadSafeList<T> tsList = new ThreadSafeList<T>(collection.Count());

            foreach (T item in collection)
            {
                tsList.Add(item);
            }

            return tsList;
        }
        
        public static void ForEach<T>(this IEnumerable<T> list, System.Action<T> action)
        {
            foreach (T item in list)
                action(item);
        }
    }
}