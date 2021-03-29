using Microsoft.VisualStudio.TestTools.UnitTesting;
using Planner.Logic.Priorities;
using System;

namespace Planner.Tests.UnitTests.Priorities {
    [TestClass]
    public class PriorityCollectionTests {
        [TestMethod]
        public void PriorityCollection_AddsPriorityCorrectly() {
            // Arrange
            PriorityCollection priorityCollection = new PriorityCollection();
            Priority priority = new Priority() { Name = "foo" };

            // Act
            priorityCollection.Add(priority);

            // Assert
            Assert.AreEqual(1, priorityCollection.Count);
        }

        [TestMethod]
        public void PriorityCollection_RemovesPriorityCorrectly() {
            // Arrange
            PriorityCollection priorityCollection = new PriorityCollection();
            Priority priority = new Priority() { Name = "foo" };
            priorityCollection.Add(priority);

            // Act
            bool successful = priorityCollection.Remove(priority);

            // Assert
            Assert.IsTrue(successful);
        }

        [TestMethod]
        public void PriorityCollection_RemovesPriorityIncorrectly_BecauseItemIsNotInCollection() {
            // Arrange
            PriorityCollection priorityCollection = new PriorityCollection();
            Priority priority = new Priority() { Name = "foo" };

            // Act
            bool successful = priorityCollection.Remove(priority);

            // Assert
            Assert.IsFalse(successful);
        }

        [TestMethod]
        public void PriorityCollection_GetsPriorityByIndexCorrectly() {
            // Arrange
            PriorityCollection priorityCollection = new PriorityCollection();
            priorityCollection.Add(new Priority() { Name = "foo" });
            priorityCollection.Add(new Priority() { Name = "bar" });

            // Act
            Priority priority = priorityCollection[0];

            // Assert
            Assert.AreEqual("foo", priority.Name);
        }

        [TestMethod]
        public void PriorityCollection_GetThrowsException_BecauseIndexIsOutOfRange() {
            // Arrange
            PriorityCollection priorityCollection = new PriorityCollection();

            // Act, Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => priorityCollection[-1]);
        }

        [TestMethod]
        public void PriorityCollection_SetsPriorityByIndexCorrectly() {
            // Arrange
            PriorityCollection priorityCollection = new PriorityCollection();
            priorityCollection.Add(new Priority() { Name = "foo" });
            priorityCollection.Add(new Priority() { Name = "bar" });

            // Act
            priorityCollection[0] = new Priority() { Name = "baz" };

            // Assert
            Assert.AreEqual("baz", priorityCollection[0].Name);
        }

        [TestMethod]
        public void PriorityCollection_SetThrowsException_BecauseIndexIsOutOfRange() {
            // Arrange
            PriorityCollection priorityCollection = new PriorityCollection();

            // Act, Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => priorityCollection[-1] = new Priority() { Name = "foo" });
        }
    }
}
