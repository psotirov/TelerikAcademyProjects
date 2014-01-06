using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SortingHomework;


namespace SortingHomeworkUnitTests
{
    [TestClass]
    public class TestsSorters
    {
        static class Comparing<T>
        {
            public static bool Collections(IList<T> first, IList<T> second)
            {
                if (first.Count != second.Count)
                {
                    return false;
                }

                for (int i = 0; i < first.Count; i++)
                {
                    if (!first[i].Equals(second[i]))
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        static ISorter<string>[] sorters = { new SelectionSorter<string>(),
                                             new QuickSorter<string>(),
                                             new MergeSorter<string>() };

        [TestMethod]
        public void TestForNullCollection()
        {
            SortableCollection<string> collection = new SortableCollection<string>();
            foreach (var sorter in sorters)
            {
                collection.Sort(sorter);
                Assert.AreEqual(collection.Items.Count, 0, "Could not sort null array: " + sorter.ToString());
            }
        }

        [TestMethod]
        public void TestForSingleItem()
        {
            SortableCollection<string> collection = new SortableCollection<string>(
                new List<string>() { "1" });
            IList<string> expected = new List<string>() { "1" };
            foreach (var sorter in sorters)
            {
                collection.Sort(sorter);
                Assert.IsTrue(Comparing<string>.Collections(collection.Items, expected),
                    "Could not sort single item array: " + sorter.ToString());
            }
        }

        [TestMethod]
        public void TestForManyItems()
        {
            SortableCollection<string> collection = new SortableCollection<string>(
                new List<string>() { "5", "1", "4", "1", "6" });
            IList<string> expected = new List<string>() { "1", "1", "4", "5", "6" };
            foreach (var sorter in sorters)
            {
                collection.Sort(sorter);
                Assert.IsTrue(Comparing<string>.Collections(collection.Items, expected),
                    "Could not sort array of many items with repetitions : " + sorter.ToString());
            }
        }

        [TestMethod]
        public void TestForBestCase()
        {
            SortableCollection<string> collection = new SortableCollection<string>(
                new List<string>() { "1", "2", "3", "4", "5" });
            IList<string> expected = new List<string>() { "1", "2", "3", "4", "5" };
            foreach (var sorter in sorters)
            {
                collection.Sort(sorter);
                Assert.IsTrue(Comparing<string>.Collections(collection.Items, expected),
                    "Could not sort array of many items in best case : " + sorter.ToString());
            }
        }

        [TestMethod]
        public void TestForWorstCase()
        {
            SortableCollection<string> collection = new SortableCollection<string>(
                new List<string>() { "5", "4", "3", "2", "1" });
            IList<string> expected = new List<string>() { "1", "2", "3", "4", "5" };
            foreach (var sorter in sorters)
            {
                collection.Sort(sorter);
                Assert.IsTrue(Comparing<string>.Collections(collection.Items, expected),
                    "Could not sort array of many items in worst case : " + sorter.ToString());
            }
        }
    }
}
