using Microsoft.VisualStudio.TestTools.UnitTesting;
using library_for_lab10;
using MyListTests;
using lab12;


namespace MyListTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddItemWhenCapacityExceeded()
        {
            //Arrange
            var hashTable = new MyHashTable2<Tool>(2, 0.72); //ёмкость 2, заполненность 72%
            hashTable.AddItem3(new Tool()); //первое добавление

            //Act
            hashTable.AddItem3(new Tool()); //второе добавление

            //Assert
            Assert.AreEqual(4, hashTable.Capacity); //ожидаем, что ёмкость увеличена до 4

        }

        [TestMethod]
        public void AddItem2WhenTableIsEmpty()
        {
            //Arrange
            var hashTable = new MyHashTable2<Tool>();

            //Act
            hashTable.AddItem3(new Tool());

            //Assert
            Assert.AreEqual(1, hashTable.Count); //Ожидаем, что количество элементов равно 1
        }

        [TestMethod]
        public void AddItemWhenTableIsNotEmpty()
        {
            //Arrange
            var hashTable = new MyHashTable2<Tool>();
            hashTable.AddItem3(new Tool());

            //Act
            hashTable.AddItem3(new Tool());

            //Assert
            Assert.AreEqual(2, hashTable.Count); //Ожидаем, что количество элементов равно 2
        }

        [TestMethod]
        public void RemoveItemWhenItemExists()
        {
            //Arrange
            var hashTable = new MyHashTable2<Tool>();
            var tool = new Tool();
            hashTable.AddItem3(tool); //добавляем элемент

            //Act
            bool removed = hashTable.RemoveItem(tool);

            //Assert
            Assert.IsTrue(removed); //ожидаем удаление
            Assert.AreEqual(0, hashTable.Count); //ожидаем, что количество элементов уменьшилось до 0
        }

        [TestMethod]
        public void AddItemWhenTableIsEmpty()
        {
            //Arrange
            var hashTable = new MyHashTable2<Tool>();
            var newTool = new Tool();

            //Act
            hashTable.AddItem3(newTool);

            //Assert
            Assert.AreEqual(1, hashTable.Count);
            Assert.IsTrue(hashTable.Contains(newTool));
        }

        [TestMethod]
        public void RemoveItemWhenItemExist()
        {
            //Arrange
            var hashTable = new MyHashTable2<Tool>();
            var toolToRemove = new Tool();
            hashTable.AddItem3(toolToRemove);

            //Act
            bool removed = hashTable.RemoveItem(toolToRemove);

            //Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(0, hashTable.Count);
            Assert.IsFalse(hashTable.Contains(toolToRemove));
        }

        [TestMethod]
        public void ContainsWhenItemExists()
        {
            //Arrange
            var hashTable = new MyHashTable2<Tool>();
            var existingTool = new Tool();
            hashTable.AddItem3(existingTool);

            //Act
            bool result = hashTable.Contains(existingTool);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ContainsWhenItemNotExist()
        {
            //Arrange
            var hashTable = new MyHashTable2<Tool>();
            var nonExistingTool = new Tool();

            //Act
            bool result = hashTable.Contains(nonExistingTool);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ConstructorWithDefaultSize()
        {
            // Arrange & Act
            var hashTable = new MyHashTable2<Tool>();

            // Assert
            Assert.AreEqual(10, hashTable.Capacity);
        }

        [TestMethod]
        public void AddItemIncreasesCount()
        {
            //Arrange
            var hashTable = new MyHashTable2<Tool>();

            //Act
            hashTable.AddItem(new Tool());

            //Assert
            Assert.AreEqual(1, hashTable.Count);
        }

        [TestMethod]
        public void ContainsExistingItem()
        {
            //Arrange
            var hashTable = new MyHashTable2<Tool>();
            var tool = new Tool();
            hashTable.AddItem(tool);

            //Act
            bool result = hashTable.Contains(tool);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveItem1()
        {
            //Arrange
            var hashTable = new MyHashTable2<Tool>();
            var tool = new Tool();
            hashTable.AddItem(tool);

            //Act
            bool removed = hashTable.RemoveItem(tool);

            //Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(0, hashTable.Count);
        }

        [TestMethod]
        public void RemoveItem_NonExistingItem()
        {
            //Arrange
            var hashTable = new MyHashTable2<Tool>();
            var tool = new Tool();

            //Act
            bool removed = hashTable.RemoveItem(tool);

            //Assert
            Assert.IsFalse(removed);
        }

        [TestMethod]
        public void RemoveItem_RetrySearce()
        {
            // Arrange
            var hashTable = new MyHashTable2<Tool>();
            var tool = new Tool();
            hashTable.AddItem(tool);

            // Act
            bool removed = hashTable.RemoveItem(tool, retrySearch: true);

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(0, hashTable.Count);
        }

        [TestMethod]
        public void FindItemExistingItem()
        {
            // Arrange
            var hashTable = new MyHashTable2<Tool>();
            var tool = new Tool();
            hashTable.AddItem(tool);

            // Act
            int index = hashTable.FindItem(tool);

            // Assert
            Assert.AreEqual(0, index);
        }

        [TestMethod]
        public void FindItemNonExistingItem()
        {
            //Arrange
            var hashTable = new MyHashTable2<Tool>();
            var tool = new Tool();

            //Act
            int index = hashTable.FindItem(tool);

            //Assert
            Assert.AreEqual(-1, index);
        }
    }
}
