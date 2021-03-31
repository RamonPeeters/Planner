using Microsoft.VisualStudio.TestTools.UnitTesting;
using Planner.Logic.Priorities;
using System;
using System.Drawing;

namespace Planner.Tests.UnitTests.Priorities {
    [TestClass]
    public class PriorityCollectionTests {
        private readonly Priority FooPriority = new Priority("foo", Color.FromArgb(0x00FF0000));
        private readonly Priority BarPriority = new Priority("bar", Color.FromArgb(0x0000FF00));
        private readonly Priority BazPriority = new Priority("baz", Color.FromArgb(0x000000FF));

        [TestMethod]
        public void PriorityCollection_AddsPriorityCorrectly() {
            // Arrange
            PriorityCollection priorityCollection = new PriorityCollection();

            // Act
            priorityCollection.Add(FooPriority);

            // Assert
            Assert.AreEqual(1, priorityCollection.Count);
        }

        [TestMethod]
        public void PriorityCollection_RemovesPriorityCorrectly() {
            // Arrange
            PriorityCollection priorityCollection = new PriorityCollection();
            priorityCollection.Add(FooPriority);

            // Act
            bool successful = priorityCollection.Remove(FooPriority);

            // Assert
            Assert.IsTrue(successful);
        }

        [TestMethod]
        public void PriorityCollection_RemovesPriorityIncorrectly_BecauseItemIsNotInCollection() {
            // Arrange
            PriorityCollection priorityCollection = new PriorityCollection();

            // Act
            bool successful = priorityCollection.Remove(FooPriority);

            // Assert
            Assert.IsFalse(successful);
        }

        [TestMethod]
        public void PriorityCollection_GetsPriorityByIndexCorrectly() {
            // Arrange
            PriorityCollection priorityCollection = new PriorityCollection();
            priorityCollection.Add(FooPriority);
            priorityCollection.Add(BarPriority);

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
            priorityCollection.Add(FooPriority);
            priorityCollection.Add(BarPriority);

            // Act
            priorityCollection[0] = BazPriority;

            // Assert
            Assert.AreEqual("baz", priorityCollection[0].Name);
        }

        [TestMethod]
        public void PriorityCollection_SetThrowsException_BecauseIndexIsOutOfRange() {
            // Arrange
            PriorityCollection priorityCollection = new PriorityCollection();

            // Act, Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => priorityCollection[-1] = FooPriority);
        }
    }
}
