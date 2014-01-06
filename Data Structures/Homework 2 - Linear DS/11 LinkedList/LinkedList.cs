using System;
using System.Collections;
using System.Collections.Generic;

namespace _11_LinkedList
{
    class LinkedList<T> : IEnumerable<T>
    {
        private ListItem<T> head;
        public int Count { get; private set; }

        public LinkedList()
        {
            this.head = null;
            this.Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            ListItem<T> lastItem = this.head;
            while (lastItem != null)
            {
                yield return lastItem.Value;
                lastItem = lastItem.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(T value)
        {
            ListItem<T> newItem = new ListItem<T>(value);
            if (this.head == null)
            {
                this.head = newItem;
            }
            else
            {
                ListItem<T> lastItem = this.head;
                while (lastItem.Next != null)
                {
                    lastItem = lastItem.Next;
                }

                lastItem.Next = newItem;
            }

            this.Count++;

        }

        public void InsertAtStart(T value)
        {
            ListItem<T> newItem = new ListItem<T>(value, this.head);
            this.head = newItem;
            this.Count++;
        }
    }
}
