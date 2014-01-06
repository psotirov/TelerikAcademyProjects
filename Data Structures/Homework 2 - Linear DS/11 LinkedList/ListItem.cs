using System;

namespace _11_LinkedList
{
    class ListItem<T>
    {
        public T Value { get; set; }
        public ListItem<T> Next { get; set; }

        public ListItem(T value, ListItem<T> next = null)
        {
            this.Value = value;
            this.Next = next;
        }
    }
}
