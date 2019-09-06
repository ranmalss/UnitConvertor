using System.Collections.Generic;
using System.Linq;

namespace DotNetNative.Extensions
{
    public static class LinkedListExtensions
    {
        public static LinkedList<T> GetBetween<T>(this LinkedList<T> list, LinkedListNode<T> startNode,
            LinkedListNode<T> endNode, bool remove)
        {
            var newList = new LinkedList<T>();

            var item = list.First;

            var startFound = false;
            var endFound = false;

            while (item != null)
            {
                var nextItem = item.Next;

                if (item == startNode) startFound = true;
                if (item == endNode) endFound = true;

                if (startFound)
                {
                    newList.AddLast(item.Value);

                    if (remove) list.Remove(item);

                    if (endFound) break;
                }

                item = nextItem;
            }

            return newList;
        }

        public static void RemoveFirstInstanceOfDistinctIn<T>(this LinkedList<T> list, IEnumerable<T> items,
            LinkedListNode<T> startingAt)
        {
            List<T> distinctData = items.Distinct().ToList();

            foreach (T data in distinctData)
            {
                LinkedListNode<T> item = startingAt;

                while (item != null)
                {
                    var nextItem = item.Next;

                    if (item.Value.Equals(data))
                    {
                        startingAt = nextItem;
                        list.Remove(item);
                        break;
                    }

                    item = nextItem;
                }
            }
        }
    }
}