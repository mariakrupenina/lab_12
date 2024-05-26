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
        public void ConstructorWithLength()
        {
            //Arrange
            int length = 5;

            //Act
            var tree = new Tree<Tool>(length);

            //Assert
            Assert.AreEqual(length, tree.Count);
        }

        [TestMethod]
        public void AddPointIncreasesCount()
        {
            //Arrange
            var tree = new Tree<Tool>(0);

            //Act
            tree.AddPoint(new Tool());

            //Assert
            Assert.AreEqual(1, tree.Count);
        }

        [TestMethod]
        public void GetTreeHeight()
        {
            //Arrange
            var tree = new Tree<Tool>(0);
            tree.AddPoint(new Tool());
            tree.AddPoint(new Tool());
            tree.AddPoint(new Tool());

            //Act
            int height = tree.GetTreeHeight();

            //Assert
            Assert.AreEqual(3, height);
        }

        [TestMethod]
        public void TransformToFindTree()
        {
            //Arrange
            var tree = new Tree<Tool>(0);
            tree.AddPoint(new Tool());
            tree.AddPoint(new Tool());
            tree.AddPoint(new Tool());

            //Act
            tree.TransformToFindTree();

            //Assert
            Assert.AreEqual(3, tree.Count);
        }

        [TestMethod]
        public void ConstructorWithZeroLength()
        {
            //Arrange & Act
            var tree = new Tree<Tool>(0);

            //Assert
            Assert.AreEqual(0, tree.Count);
        }

        [TestMethod]
        public void AddPointWithDuplicateData()
        {
            //Arrange
            var tree = new Tree<Tool>(0);
            var tool = new Tool();
            tree.AddPoint(tool);

            //Act
            tree.AddPoint(tool);

            //Assert
            Assert.AreEqual(1, tree.Count);
        }

        [TestMethod]
        public void GetTreeHeight2()
        {
            //Arrange
            var tree = new Tree<Tool>(0);

            //Act
            int height = tree.GetTreeHeight();

            //Assert
            Assert.AreEqual(0, height);
        }

        [TestMethod]
        public void AddPointIncreasesCount2()
        {
            //Arrange
            var tree = new Tree<Tool>(0);

            //Act
            tree.AddPoint(new Tool());

            //Assert
            Assert.AreEqual(1, tree.Count);
        }

    }
}