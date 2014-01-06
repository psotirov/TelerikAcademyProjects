using System;
using System.Collections;
using System.Collections.Generic;

namespace _13_Queue
{
    class LinkedQueue<T> : IEnumerable<T>
    {
        private QueueItem<T> head;
        private QueueItem<T> tail;
        public int Count { get; private set; }

        public LinkedQueue()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            QueueItem<T> lastItem = this.head;
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

        public void Enqueue(T value)
        {
            QueueItem<T> newItem = new QueueItem<T>(value);
            if (this.head == null)
            {
                this.head = newItem;
                this.tail = this.head;
            }
            else
            {
                this.tail.Next = newItem;
                this.tail = newItem;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            T result = this.head.Value;
            this.head = this.head.Next;
            this.Count--;
            return result;
        }
    }
}
