using System;
using System.Collections.Generic;

namespace _03_BiDictionary
{
    class BiDictionary<TKey1, TKey2, TValue>
    {
        private readonly Dictionary<TKey1, List<TValue>> key1;
        private readonly Dictionary<TKey2, List<TValue>> key2;
        private readonly Dictionary<Tuple<TKey1, TKey2>, List<TValue>> bothKeys;
        public int Count { get; private set; }

        public BiDictionary()
        {
            this.key1 = new Dictionary<TKey1, List<TValue>>();
            this.key2 = new Dictionary<TKey2, List<TValue>>();
            this.bothKeys = new Dictionary<Tuple<TKey1, TKey2>, List<TValue>>();
            this.Count = 0;
        }

        public void Add(TKey1 key1, TKey2 key2, TValue value)
        {
            // Adds value to key1 dictionary
            if (!this.key1.ContainsKey(key1))
            {
                this.key1.Add(key1, new List<TValue>());                
            }

            if (this.key1[key1].Contains(value))
            {
                throw new ArgumentException("Duplicated value");
            }

            this.key1[key1].Add(value);

            // Adds value to key2 dictionary
            if (!this.key2.ContainsKey(key2))
            {
                this.key2.Add(key2, new List<TValue>());
            }

            this.key2[key2].Add(value);

            // Adds value to both key1 and key2 dictionary
            var both = new Tuple<TKey1, TKey2>(key1, key2);
            if (!this.bothKeys.ContainsKey(both))
            {
                this.bothKeys.Add(both, new List<TValue>());
            }

            this.bothKeys[both].Add(value);
            this.Count++;
        }

        public ICollection<TValue> this[TKey1 key1]
        {
            get
            {
                return this.key1[key1].ToArray();
            }
        }

        public ICollection<TValue> this[TKey2 key2]
        {
            get
            {
                return this.key2[key2].ToArray();
            }
        }

        public ICollection<TValue> this[TKey1 key1, TKey2 key2]
        {
            get
            {
                var both = new Tuple<TKey1, TKey2>(key1, key2);
                return this.bothKeys[both].ToArray();
            }
        }
    }
}
