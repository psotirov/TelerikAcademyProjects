using System;
using System.Collections.Generic;
using System.Collections;

namespace _04_HashTable
{
    public class HashTable<K, T> : IEnumerable<KeyValuePair<K, T>>
    {
        const int InitialCapacity = 16;
        const double FillFactor = 0.75;
 
        LinkedList<KeyValuePair<K, T>>[] data;
        public int Count { get; private set; }
        public int Capacity { get; private set; }

        public HashTable(int capacity = InitialCapacity)
        {
            this.data = new LinkedList<KeyValuePair<K, T>>[capacity];
            this.Count = 0;
            this.Capacity = capacity;
        }
            
        private void DoubleCapacity()
        {
            if (this.Capacity > int.MaxValue / 2)
            {
                // upper bound has been reached 
                return;
            }

            LinkedList<KeyValuePair<K, T>>[] newData = new LinkedList<KeyValuePair<K, T>>[Capacity * 2];
            for (int i = 0; i < this.data.Length; i++)
            {
                // copy elements with rehash
                newData[i*2] = this.data[i];                    
            }
            this.data = newData;
            this.Capacity = newData.Length;
        }
 
        public T this[K key]
        {
            get
            {
                return this.Find(key);
            }

            set
            {
                this.Append(key, value, true);
            }
        }

        public void Add(K key, T value)
        {
            this.Append(key, value, false);
        }

        private void Append(K key, T value, bool canUpdateValue)
        {
            if (key == null)
            {
                throw new ArgumentNullException("The hashtable key cannot be null");
            }

            if ((this.Count / (double)this.Capacity) > FillFactor)
            {
                this.DoubleCapacity();
            }

            int index = GetHash(key);
            if (this.data[index] == null)
            {
                this.data[index] = new LinkedList<KeyValuePair<K, T>>();
            }

            var listElement = this.data[index].First;
            while (listElement != null)
            {
                if (listElement.Value.Key.Equals(key))
                {
                    if (canUpdateValue)
	                {
                        // just updating the elements value
                        listElement.Value = new KeyValuePair<K,T>(key, value);
                        return;
	                }
                    else
                    {
                        throw new ArgumentException("The hashtable key already exists");
                    }
                }

                listElement = listElement.Next;
            }

            this.data[index].AddLast(new KeyValuePair<K, T>(key, value));
            this.Count++;
        }

        public T Find(K key)
        {
            int index = GetHash(key);
            if (data[index] != null)
            {
                var listElement = this.data[index].First;
                while (listElement != null)
                {
                    if (listElement.Value.Key.Equals(key))
                    {
                        return listElement.Value.Value;
                    }

                    listElement = listElement.Next;
                }
            }

            return default(T);
        }

        public void Remove(K key)
        {
            int index = GetHash(key);
            if (this.data[index] != null)
            {
                var listElement = this.data[index].First;
                while (listElement != null)
                {
                    if (listElement.Value.Key.Equals(key))
                    {
                        this.data[index].Remove(listElement);
                        this.Count--;
                        return;
                    }

                    listElement = listElement.Next;
                }
            }
            }

        public void Clear()
        {
            this.data = new LinkedList<KeyValuePair<K, T>>[InitialCapacity];
            this.Count = 0;
            this.Capacity = data.Length;
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            foreach (var item in this.data)
            {
                if (item != null)
                {
                    var listElement = item.First;
                    while (listElement != null)
                    {
                        yield return listElement.Value;
                        listElement = listElement.Next;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private int GetHash(K key)
        {
            int hashCode = key.GetHashCode() % this.data.Length;
            if (hashCode < 0)
            {
                hashCode *= -1;
            }

            return hashCode;
        }
    }
}
