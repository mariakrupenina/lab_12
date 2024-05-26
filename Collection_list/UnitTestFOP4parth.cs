using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using library_for_lab10;
using MyListTests;
using lab12;


namespace MyListTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ConstructorWithZeroSize()
        {
            // Arrange & Act
            var list = new MyList4<Tool>(0);

            // Assert
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void ConstructorWithPositiveSize()
        {
            // Arrange
            int size = 10;

            // Act
            var list = new MyList4<Tool>(size);

            // Assert
            Assert.AreEqual(size, list.Count);
        }


        [TestMethod]
        public void AddToEnd()
        {
            // Arrange
            var list = new MyList4<Tool>(0);
            var tool = new Tool();

            // Act
            list.AddToEnd(tool);

            // Assert
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void RemoveItem()
        {
            // Arrange
            var list = new MyList4<Tool>(0);
            var tool1 = new Tool();
            var tool2 = new Tool();
            list.AddToEnd(tool1);
            list.AddToEnd(tool2);

            // Act
            list.RemoveItem(tool1);

            // Assert
            Assert.IsFalse(list.Contains(tool1));
        }

        [TestMethod]
        public void InsertItemAtSpecifiedIndex()
        {
            // Arrange
            var list = new MyList4<Tool>();
            var tool1 = new Tool();
            var tool2 = new Tool();
            var tool3 = new Tool();
            list.AddToEnd(tool1);
            list.AddToEnd(tool3);

            // Act
            list.Insert(1, tool2);

            // Assert
            Assert.AreEqual(tool2, list[1]);
        }

        [TestMethod]
        public void IndexOfReturnsCorrectIndex()
        {
            // Arrange
            var list = new MyList4<Tool>();
            var tool1 = new Tool();
            var tool2 = new Tool();
            var tool3 = new Tool();
            list.AddToEnd(tool1);
            list.AddToEnd(tool2);
            list.AddToEnd(tool3);

            // Act
            var index = list.IndexOf(tool2);

            // Assert
            Assert.AreEqual(1, index);
        }

        [TestMethod]
        public void ClearRemovesAllItems()
        {
            // Arrange
            var list = new MyList4<Tool>();
            var tool1 = new Tool();
            var tool2 = new Tool();
            list.AddToEnd(tool1);
            list.AddToEnd(tool2);

            // Act
            list.Clear();

            // Assert
            Assert.AreEqual(0, list.Count);
            Assert.IsFalse(list.Contains(tool1));
            Assert.IsFalse(list.Contains(tool2));
        }

        [TestMethod]
        public void RemovesItemAtSpecifiedIndex()
        {
            // Arrange
            var list = new MyList4<Tool>();
            var tool1 = new Tool();
            var tool2 = new Tool();
            var tool3 = new Tool();
            list.AddToEnd(tool1);
            list.AddToEnd(tool2);
            list.AddToEnd(tool3);

            // Act
            list.RemoveAt(1);

            // Assert
            Assert.AreEqual(2, list.Count);
            Assert.IsFalse(list.Contains(tool2));
        }

        [TestMethod]
        public void CopiesItemsToArrayStartingAtIndex()
        {
            // Arrange
            var list = new MyList4<Tool>();
            var tool1 = new Tool();
            var tool2 = new Tool();
            var tool3 = new Tool();
            list.AddToEnd(tool1);
            list.AddToEnd(tool2);
            list.AddToEnd(tool3);
            var array = new Tool[5];

            // Act
            list.CopyTo(array, 1);

            // Assert
            Assert.AreEqual(tool1, array[1]);
            Assert.AreEqual(tool2, array[2]);
            Assert.AreEqual(tool3, array[3]);
        }

        [TestMethod]
        public void GetEnumerator()
        {
            // Arrange
            var list = new MyList4<Tool>();
            var tool1 = new Tool();
            var tool2 = new Tool();
            var tool3 = new Tool();
            list.AddToEnd(tool1);
            list.AddToEnd(tool2);
            list.AddToEnd(tool3);

            // Act
            var enumerator = list.GetEnumerator();

            // Assert
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(tool1, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(tool2, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(tool3, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

    }
}