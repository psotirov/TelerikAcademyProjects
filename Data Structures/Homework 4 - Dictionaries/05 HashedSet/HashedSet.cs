using System;
using System.Collections.Generic;
using System.Collections;
using _04_HashTable;

namespace _05_HashedSet
{
    class HashedSet<T> : HashTable<T, bool>, IEnumerable<T>
    {
        public void Add(T value)
        {
            base.Add(value, true);
        }

        new public bool this[T key]
        {
            get
            {
                return base.Find(key);
            }
        }

        new public IEnumerator<T> GetEnumerator()
        {
            IEnumerator<KeyValuePair<T, bool>> enumerator = base.GetEnumerator();
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current.Key;
            }
        }
    }
}
