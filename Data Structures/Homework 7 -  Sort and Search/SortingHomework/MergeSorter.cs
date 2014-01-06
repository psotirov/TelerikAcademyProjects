namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null || collection.Count < 2)
            {
                return;
            }

            int pivotIndex = collection.Count / 2;
            IList<T> left = new List<T>();
            IList<T> right = new List<T>();
            for (int i = 0; i < collection.Count; i++)
            {
                if (i < pivotIndex)
                {
                    left.Add(collection[i]);
                }
                else
                {
                    right.Add(collection[i]);
                }
            }

            this.Sort(left);
            this.Sort(right);
            collection = this.Merge(left, right);
        }

        private IList<T> Merge(IList<T> left, IList<T> right)
        {
            IList<T> result = new List<T>();
            int leftIndex = 0;
            int rightIndex = 0;
            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (left[leftIndex].CompareTo(right[rightIndex]) > 0)
                {
                    result.Add(right[rightIndex++]);
                }
                else
                {
                    result.Add(left[leftIndex++]);
                }
            }

            while (leftIndex < left.Count)
            {
                result.Add(left[leftIndex++]);
            }

            while (rightIndex < right.Count)
            {
                result.Add(right[rightIndex++]);
            }

            return result;
        }
    }
}
