namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null || collection.Count < 2)
            {
                return;
            }

            for (int i = 0; i < collection.Count - 1; i++)
            {
                int minElementIndex = i;
                for (int j = i+1; j < collection.Count; j++)
                {
                    if (collection[minElementIndex].CompareTo(collection[j]) > 0)
                    {
                        minElementIndex = j;
                    }
                }

                if (minElementIndex != i)
                {
                    T temp = collection[minElementIndex];
                    collection[minElementIndex] = collection[i];
                    collection[i] = temp;
                }
            }
        }
    }
}
