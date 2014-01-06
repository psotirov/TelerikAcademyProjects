using System;
using System.Collections;
using System.Collections.Generic;

namespace FriendsInNeed
{
    public class PriorityQueue<T> : IEnumerable<T> where T : IComparable
    {
        private T[] elements;
        public int Count { get; private set; }

        public PriorityQueue()
        {
            this.elements = new T[4];
            this.Count = 0;
        }

        public void Enqueue(T value)
        {
            if (this.elements.Length - this.Count == 1)
            {
                T[] doubleLength = new T[this.elements.Length * 2];
                this.elements.CopyTo(doubleLength, 0);
                this.elements = doubleLength;
            }

            this.elements[this.Count++] = value;

            // swap the new element with its parent until the new element is smaller (move to the left/up)
            int i = this.Count - 1;
            while (i > 0 && this.elements[i].CompareTo(this.elements[this.ParentIndex(i)]) < 0)
            {
                this.Swap(i, this.ParentIndex(i));
                i = this.ParentIndex(i);
            }
        }

        public T Dequeue()
        {
            var result = this.Peek();

            this.elements[0] = this.elements[--this.Count];

            // swap the new first element (previously the last) with its smaller child until that first element is greater (move to the right/down)
            int i = 0;
            int smallerChildIndex = 1;
            if (this.Count > 2 && this.elements[1].CompareTo(this.elements[2]) > 0)
            {
                smallerChildIndex = 2;
            }

            while (smallerChildIndex < this.Count && this.elements[i].CompareTo(this.elements[smallerChildIndex]) > 0)
            {
                this.Swap(i, smallerChildIndex);
                i = smallerChildIndex;
                smallerChildIndex = this.Child1Index(i);
                if (this.Child2Index(i) < this.Count &&
                    this.elements[this.Child1Index(i)].CompareTo(this.elements[this.Child2Index(i)]) > 0)
                {
                    smallerChildIndex = this.Child2Index(i);
                }
            }

            return result;
        }

        public T Peek()
        {
            return this.elements[0];
        }

        private int ParentIndex(int i)
        {
            return (i - 1) / 2;
        }

        private int Child1Index(int i)
        {
            return (i * 2) + 1;
        }

        private int Child2Index(int i)
        {
            return (i * 2) + 2;
        }

        private void Swap(int i, int j)
        {
            T temp = this.elements[i];
            this.elements[i] = this.elements[j];
            this.elements[j] = temp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
