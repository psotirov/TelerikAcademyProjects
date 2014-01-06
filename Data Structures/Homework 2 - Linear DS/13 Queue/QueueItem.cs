using System;

namespace _13_Queue
{
    class QueueItem<T>
    {
        public T Value { get; set; }
        public QueueItem<T> Next { get; set; }

        public QueueItem(T value, QueueItem<T> next = null)
        {
            this.Value = value;
            this.Next = next;
        }
    }
}
