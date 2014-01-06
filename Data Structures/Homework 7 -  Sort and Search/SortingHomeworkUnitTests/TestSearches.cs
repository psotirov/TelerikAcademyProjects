using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SortingHomework;

namespace SortingHomeworkUnitTests
{
    [TestClass]
    public class TestSearches
    {
        [TestMethod]
        public void TestForNullCollection()
        {
            SortableCollection<string> collection = new SortableCollection<string>();
            Assert.IsFalse(collection.LinearSearch("1"), "Linear search failed on empty collection");
            Assert.IsFalse(collection.BinarySearch("1"), "Binary search failed on empty collection");                
        }

        [TestMethod]
        public void TestForSingleItem()
        {
            SortableCollection<string> collection = new SortableCollection<string>(
                new List<string>() { "1" });
            Assert.IsTrue(collection.LinearSearch("1"), "Linear search failed on single item collection");
            Assert.IsTrue(collection.BinarySearch("1"), "Binary search failed on single item collection");
            Assert.IsFalse(collection.LinearSearch("2"),
                "Linear search failed on single item collection - non-existing item");
            Assert.IsFalse(collection.BinarySearch("2"),
                "Binary search failed on single item collection - non-existing item");
        }

        [TestMethod]
        public void TestForEvenItems()
        {
            SortableCollection<string> collection = new SortableCollection<string>(
                new List<string>() { "5", "1", "4", "1" });
            Assert.IsTrue(collection.LinearSearch("1"), "Linear search failed on even items collection");
            collection.Sort(new SelectionSorter<string>());
            Assert.IsTrue(collection.BinarySearch("1"), "Binary search failed on even items collection");
            Assert.IsFalse(collection.LinearSearch("2"),
                "Linear search failed on even items collection - non-existing item");
            Assert.IsFalse(collection.BinarySearch("2"),
                "Binary search failed on even items collection - non-existing item");
        }

        [TestMethod]
        public void TestForOddItems()
        {
            SortableCollection<string> collection = new SortableCollection<string>(
                new List<string>() { "5", "1", "4", "1", "6" });
            Assert.IsTrue(collection.LinearSearch("1"), "Linear search failed on odd items collection");
            collection.Sort(new SelectionSorter<string>());
            Assert.IsTrue(collection.BinarySearch("1"), "Binary search failed on odd items collection");
            Assert.IsFalse(collection.LinearSearch("2"),
                "Linear search failed on odd items collection - non-existing item");
            Assert.IsFalse(collection.BinarySearch("2"),
                "Binary search failed on odd items collection - non-existing item");
        }
    }
}
