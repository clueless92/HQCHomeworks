using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomLinkedList;

namespace CustomLinkedListTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestCount_ValidCountOnNewListCreation_ExpectSuccess()
        {
            DynamicList<int> list = new DynamicList<int>();
            int actual = list.Count;
            int expected = 0;
            Assert.AreEqual(expected, actual, "List count should be 0.");
        }

        [TestMethod]
        public void TestCount_ValidCountOnTwoItemsInList_ExpectSuccess()
        {
            DynamicList<int> list = new DynamicList<int>();
            list.Add(5);
            list.Add(7);
            int actual = list.Count;
            int expected = 2;
            Assert.AreEqual(expected, actual, "List count should be 2.");
        }

        [TestMethod]
        public void TestIndexator_GetValid_ExpectSuccess()
        {
            DynamicList<int> list = new DynamicList<int>();
            list.Add(5);
            list.Add(8);
            int actual = list[1];
            int expected = 8;
            Assert.AreEqual(expected, actual, "Item on index 1 should be 8.");
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void TestIndexator_GetNegative_ExpectArgumentOutOfRangeException()
        {
            DynamicList<int> list = new DynamicList<int>();
            int actual = list[-1];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIndexator_GetMoreThanOrEqualToCount_ExpectArgumentOutOfRangeException()
        {
            DynamicList<int> list = new DynamicList<int>();
            int actual = list[1];
        }

        [TestMethod]
        public void TestIndexator_SetValid_ExpectSuccess()
        {
            DynamicList<int> list = new DynamicList<int>();
            list.Add(5);
            list.Add(8);
            list[1] = 3;
            int expected = 3;
            Assert.AreEqual(expected, list[1], "Item on index 1 should be 3.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIndexator_SetNegative_ExpectArgumentOutOfRangeException()
        {
            DynamicList<int> list = new DynamicList<int>();
            list[-1] = 3;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIndexator_SetMoreThanOrEqualToCount_ExpectArgumentOutOfRangeException()
        {
            DynamicList<int> list = new DynamicList<int>();
            list[1] = 3;
        }

        [TestMethod]
        public void TestAdd_OneItem_ExpectSuccess()
        {
            DynamicList<int> list = new DynamicList<int>();
            list.Add(5);
            int expected = 5;
            int actual = list[0];
            Assert.AreEqual(expected, actual, "Item on index 0 should be 5.");
        }

        [TestMethod]
        public void TestAdd_TwoItems_ExpectSuccess()
        {
            DynamicList<int> list = new DynamicList<int>();
            list.Add(5);
            list.Add(6);
            int expected = 6;
            int actual = list[1];
            Assert.AreEqual(expected, actual, "Item on index 1 should be 6.");
        }

        [TestMethod]
        public void TestRemoveAt_ValidIndex_ExpectItemAtIndex()
        {
            DynamicList<int> list = new DynamicList<int>();
            list.Add(5);
            list.Add(6);
            int actual = list.RemoveAt(1);
            int expected = 6;
            Assert.AreEqual(expected, actual, "Removed item should be 6.");
        }

        [TestMethod]
        public void TestRemoveAt_ValidIndex_ExpectItemNotContained()
        {
            DynamicList<int> list = new DynamicList<int>();
            list.Add(5);
            list.Add(6);
            list.RemoveAt(1);
            Assert.IsFalse(list.Contains(6), "Item at index 1 should not be contained.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemoveAt_InvalidIndex_ExpectArgumentOutOfRangeException()
        {
            DynamicList<int> list = new DynamicList<int>();
            list.RemoveAt(1);
        }

        [TestMethod]
        public void TestRemove_ValidItem_ExpectSuccess()
        {
            DynamicList<int> list = new DynamicList<int>();
            list.Add(5);
            list.Add(6);
            int actual = list.Remove(6);
            int expected = 1;
            Assert.AreEqual(expected, actual, "Index of removed item should be 1.");
        }

        [TestMethod]
        public void TestRemove_ValidIndex_ExpectItemNotContained()
        {
            DynamicList<int> list = new DynamicList<int>();
            list.Add(5);
            list.Add(6);
            list.Remove(6);
            Assert.IsFalse(list.Contains(6), "Item 6 should not be contained.");
        }

        [TestMethod]
        public void TestRemove_InvalidIndex_ExpectTheNegativeOne()
        {
            DynamicList<int> list = new DynamicList<int>();
            int actual = list.Remove(1);
            int expected = -1;
            Assert.AreEqual(expected, actual, "Removing item that isn't in the list. Expect -1.");
        }

        [TestMethod]
        public void TestIndexOf_OneOccurance_ExpectSuccess()
        {
            DynamicList<int> list = new DynamicList<int>();
            list.Add(5);
            list.Add(6);
            int actual = list.IndexOf(6);
            int expected = 1;
            Assert.AreEqual(expected, actual, "Index of searched item 6 should be 1.");
        }

        [TestMethod]
        public void TestIndexOf_MultipleOccurance_ExpectSuccess()
        {
            DynamicList<int> list = new DynamicList<int>();
            list.Add(5);
            list.Add(6);
            list.Add(6);
            list.Add(6);
            int actual = list.IndexOf(6);
            int expected = 1;
            Assert.AreEqual(expected, actual, "Index of searched item 6 should be 1.");
        }

        [TestMethod]
        public void TestRemoveAt_NoOccurance_ExpectTheNegativeOne()
        {
            DynamicList<int> list = new DynamicList<int>();
            list.Add(5);
            list.Add(6);
            int actual = list.IndexOf(3);
            int expected = -1;
            Assert.AreEqual(expected, actual, "Expect -1.");
        }

        [TestMethod]
        public void TestContains_ExpectTrue()
        {
            DynamicList<int> list = new DynamicList<int>();
            list.Add(5);
            Assert.IsTrue(list.Contains(5), "Expect true.");
        }

        [TestMethod]
        public void TestContains_ExpectFalse()
        {
            DynamicList<int> list = new DynamicList<int>();
            list.Add(6);
            Assert.IsFalse(list.Contains(5), "Expect false.");
        }
    }
}
