using System;

namespace _12_Stack
{
    class Stack<T>
    {
        private T[] stackValues;
        public int Count { get; private set; }

        public Stack()
        {
            this.stackValues = new T[4];
            this.Count = 0;
        }

        public void Push(T value)
        {
            if (this.Count == this.stackValues.Length)
            {
                T[] newValues = new T[this.stackValues.Length * 2];
                this.stackValues.CopyTo(newValues, 0);
                this.stackValues = newValues;
            }

            this.stackValues[this.Count] = value;
            this.Count++;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            return this.stackValues[this.Count-1];
        }

        public T Pop()
        {
            T result = this.Peek();
            this.Count--;
            return result;
        }
    }
}
