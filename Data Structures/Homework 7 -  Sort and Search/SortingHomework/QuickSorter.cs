namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class QuickSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null || collection.Count < 2)
            {
                return;
            }

            int PivotIndex = collection.Count / 2;
            IList<T> smallers = new List<T>();
            IList<T> greaters = new List<T>();
            for (int i = 0; i < collection.Count; i++)
            {
                if (i == PivotIndex) continue;

                if (collection[PivotIndex].CompareTo(collection[i]) < 0)
                {
                    greaters.Add(collection[i]);
                }
                else
                {
                    smallers.Add(collection[i]);                    
                }
            }

            this.Sort(greaters);
            this.Sort(smallers);
            smallers.Add(collection[PivotIndex]);
            foreach (var item in greaters)
			{
                smallers.Add(item);			 
			}

            collection = smallers;
        }
    }
}
