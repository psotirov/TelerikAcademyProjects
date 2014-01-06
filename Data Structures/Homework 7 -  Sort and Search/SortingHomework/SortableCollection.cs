namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private static Random generator = new Random();
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (item.CompareTo(this.items[i]) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            int left = 0;
            int right = this.items.Count;
            while (right > left)
            {
                int middle = (left + right) / 2;
                int comparison = item.CompareTo(this.items[middle]);
                if (comparison == 0)
                {
                    return true;
                }

                if (comparison > 0)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }

            return false;
        }

        public void Shuffle()
        {
            // Durstenfeld algorithm (a variation of Fisher–Yates shuffle)
            // the complexity of this shuffling algorithm is O(n)
            // since there is only one loop

            for (int i = this.items.Count-1; i > 0; i--)
            {
                int randomPosition = generator.Next(i+1);
                if (i != randomPosition)
                {
                    T temp = this.items[i];
                    this.items[i] = this.items[randomPosition];
                    this.items[randomPosition] = temp;
                }
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
