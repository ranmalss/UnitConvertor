using System.Collections.Generic;

namespace DotNetNative.Extensions
{
    public static class ListExtensions
    {
        public static void MoveFirstItemToLast<T>(this List<T> list)
        {
            T item = list[0];
            list.RemoveAt(0);
            list.Add(item);
        }
    }
}