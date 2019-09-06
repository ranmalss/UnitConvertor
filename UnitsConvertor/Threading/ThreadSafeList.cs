using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using System.Linq.Expressions;
using static System.Linq.Enumerable;
using Newtonsoft.Json;

namespace Threading
{
    public class ThreadSafeList<T>
    {
        [JsonProperty]
        private List<T> _list = new List<T>();

        [JsonProperty]
        private object _sync = new object();

        public ThreadSafeList()
        {
        }

        public ThreadSafeList(int capacity)
        {
            _list = new List<T>(capacity);
        }

        public ThreadSafeList(List<T> values)
        {
            _list = values;
        }

        public void SetList(List<T> values)
        {
            lock (_sync)
            {
                _list = values;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return Clone().GetEnumerator();
        }

        public List<T> Clone()
        {
            ThreadLocal<List<T>> threadClonedList = new ThreadLocal<List<T>>();
            threadClonedList.Value = new List<T>();

            lock (_sync)
            {
                _list.ForEach(element => { threadClonedList.Value.Add(element); });
            }

            return (threadClonedList.Value);
        }

        public void Add(T value)
        {
            lock (_sync)
            {
                _list.Add(value);
            }
        }

        public void AddRange(List<T> values)
        {
            lock (_sync)
            {
                _list.AddRange(values);
            }
        }

        public void AddRange(ThreadSafeList<T> values)
        {
            lock (_sync)
            {
                foreach (T value in values)
                {
                    _list.Add(value);
                }
            }
        }

        public bool Remove(T value)
        {
            bool isRemoved;

            lock (_sync)
            {
                isRemoved = _list.Remove(value);
            }

            return (isRemoved);
        }

        public void Clear()
        {
            lock (_sync)
            {
                _list.Clear();
            }
        }

        public bool Contains(T value)
        {
            bool containsItem;

            lock (_sync)
            {
                containsItem = _list.Contains(value);
            }

            return (containsItem);
        }

        public int Count
        {
            get
            {
                int count;

                lock ((_sync))
                {
                    count = _list.Count;
                }

                return (count);
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public int IndexOf(T value)
        {
            int itemIndex;

            lock ((_sync))
            {
                itemIndex = _list.IndexOf(value);
            }

            return (itemIndex);
        }

        public void Insert(int index, T value)
        {
            lock ((_sync))
            {
                _list.Insert(index, value);
            }
        }

        public void RemoveAt(int index)
        {
            lock ((_sync))
            {
                _list.RemoveAt(index);
            }
        }

        public T this[int index]
        {
            get
            {
                lock ((_sync))
                {
                    return _list[index];
                }
            }
            set
            {
                lock ((_sync))
                {
                    _list[index] = value;
                }
            }
        }

        public T Find(Predicate<T> predicate)
        {
            lock (_sync)
            {
                return _list.Find(predicate);
            }
        }

        #region Linq
        public IEnumerable<TResult> Select<TResult>(Func<T, TResult> selector)
        {
            if (_list == null)
            {
                throw new Exception("List is null.");
            }

            if (selector == null)
            {
                throw new Exception("Selector is null.");
            }

            return _list.Select(selector);
        }

        public IOrderedEnumerable<T> OrderByDescending<TKey>(Func<T, TKey> selector)
        {
            if (_list == null)
            {
                throw new Exception("List is null.");
            }

            if (selector == null)
            {
                throw new Exception("Selector is null.");
            }

            return _list.OrderByDescending(selector);
        }

        public IOrderedEnumerable<T> OrderBy<TKey>(Func<T, TKey> selector)
        {
            if (_list == null)
            {
                throw new Exception("List is null.");
            }

            if (selector == null)
            {
                throw new Exception("Selector is null.");
            }

            return _list.OrderBy(selector);
        }

        public IEnumerable<T> Where(Func<T, bool> predicate)
        {
            if (_list == null)
            {
                throw new Exception("List is null.");
            }

            if (predicate == null)
            {
                throw new Exception("Predicate is null.");
            }

            return _list.Where(predicate);
        }

        public List<T> ToList()
        {
            return _list;
        }
        #endregion
    }
}
