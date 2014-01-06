using System;

namespace _05_07_GenericList
{
    public class GenericList<T>
    {
        private T[] list;
        public int Length { get; private set; }

        public GenericList() // default constructor - creates empty list with capacity of 5 elements
        {
            this.Clear();
        }

        public GenericList(params T[] elems) // constructor with various number of elements
        {
            this.list = new T[elems.Length * 2]; // creates an array with length of twice than the number of input parameters
            elems.CopyTo(this.list, 0); // copies the input parameters into the list
            this.Length = elems.Length; // sets the Length property
        }

        public void Clear() // clears the list - simply creates a new empty list with capacity of 5 elements
        {
            this.list = new T[5];
            this.Length = 0;
        }

        public T this[int idx]
        {
            get // invoked when asks for value of matrix certain matrix element
            {
                if (idx < 0 || idx >= this.Length) throw new ArgumentOutOfRangeException(); // checks index
                return this.list[idx];
            }

            set // invoked when puts value into the matrix content
            {
                if (idx < 0 || idx >= this.Length) throw new ArgumentOutOfRangeException(); // checks index
                this.list[idx] = value;
            }
        }

        public void Insert(int idx, T elem)
        {
            if (idx < 0 || idx > this.Length) throw new ArgumentOutOfRangeException(); // checks index

            if (this.Length == list.Length) // we need explanding of the list 
            {
                T[] more = new T[this.Length * 2]; // creates a new list with twice length
                this.list.CopyTo(more, 0); // copies values to the new list
                this.list = more; // and sets its reference to the object member
            }

            if (idx < this.Length) // opens slot for the new element
            {
                for (int i = this.Length; i > idx; i--)
                {
                    this.list[i] = this.list[i - 1];
                }
            }

            this.list[idx] = elem;
            this.Length++;
        }

        public void Add(T elem) // appends element to the list
        {
            this.Insert(this.Length, elem); // inserts it on the last position
        }

        public void Remove(int idx)
        {
            if (idx < 0 || idx >= this.Length) throw new ArgumentOutOfRangeException(); // checks index
            for (int i = idx; i < this.Length; i++)
            {
                this.list[i] = this.list[i + 1];
            }
            this.Length--;
        }

        public int Find(T elem) // looking for element
        {
            int idx = -1; // by default the find is not successfull
            for (int i = 0; i < this.Length; i++)
            {
                if (this.list[i].Equals(elem)) // compares the pattern with each element
                {
                    idx = i;
                    break;
                }
            }

            return idx;
        }

        public override string ToString() // returns the GenericList<T> content  
        {
            string result = "{ ";
            for(int i=0; i < this.Length; i++)
            {
                result += this.list[i].ToString();
                if (this.Length - i > 1) result += ", ";
            }
            result += " }";
            return result;
        }

        public T Min(params T[] elems) // looking for minimal element in a set of elements
        {
            if (elems == null) return this.Min(this.list); // if the set is empty looks in the whole list

            dynamic result = this.list[0]; // converting everything to dynamic in order to avoid compilation errors
            // the other way is to implement IComparable inheritance
            for (int i = 0; i < this.Length; i++)
            {
                if (result.CompareTo((dynamic)this.list[i]) >= 0) result = (dynamic)this.list[i];
            }

            return result;
        }

        public T Max(params T[] elems) // looking for a maximal element in a set of elements
        {
            if (elems == null) return this.Min(this.list);

            dynamic result = this.list[0];
            for (int i = 0; i < this.Length; i++)
            {
                if (result.CompareTo((dynamic)this.list[i]) <= 0) result = (dynamic)this.list[i];
            }

            return result;
        }
    }
}
