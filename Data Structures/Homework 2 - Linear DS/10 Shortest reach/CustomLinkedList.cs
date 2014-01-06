using System;
using System.Collections.Generic;

namespace _10_Shortest_reach
{
    public class CustomLinkedList<T> where T : IComparable
    {
        private T[] values;
        private int[] parents;
        private SortedSet<T> sortedValues; // this member is used only to increase the searching speed from O(n) to O(ln n)
        public int Count { get; private set; }

        public CustomLinkedList()
        {
            this.values = new T[4];
            this.parents = new int[4];
            this.sortedValues = new SortedSet<T>();
            this.Count = 0;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                return this.values[index];
            }
        }

        /// <summary>
        /// Returns the index of the parent element (i.e. upper level of the tree)
        /// </summary>
        public int GetParent(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            return this.parents[index];
        }

        /// <summary>
        /// Adds new value to the queue
        /// </summary>
        /// <param name="parent">index of the parent element (i.e. upper level of the tree)</param>
        public void Add(T value, int parent=-1)
        {
            if (this.Count == this.values.Length)
            {
                T[] newValues = new T[this.values.Length * 2];
                this.values.CopyTo(newValues, 0);
                this.values = newValues;

                int[] newParents = new int[this.parents.Length * 2];
                this.parents.CopyTo(newParents, 0);
                this.parents = newParents;
            }

            this.values[this.Count] = value;
            this.parents[this.Count] = parent;
            this.sortedValues.Add(value); // it will add sucessfully only unique values 
            this.Count++;
        }

        public bool Contains(T value)
        {
            // return (Array.IndexOf<T>(this.values, value) >= 0); // O(n) that results to O(n^2) for the application, very slow for numbers above 50000
            return (this.sortedValues.Contains(value)); // O(ln n), better
        }
    }

}
