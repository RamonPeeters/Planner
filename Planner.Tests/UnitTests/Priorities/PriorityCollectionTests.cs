using Microsoft.VisualStudio.TestTools.UnitTesting;
using Planner.Logic.Priorities;
using Planner.Tests.TestDal.Priorities;
using System;

namespace Planner.Tests.UnitTests.Priorities {
    [TestClass]
    public class PriorityCollectionTests {
        private readonly Priority FooPriority = new Priority("foo", 1);
        private readonly Priority BarPriority = new Priority("bar", 1);
        private readonly Priority BazPriority = new Priority("baz", 2);

        [TestMethod]
        public void PriorityCollection_AddsPriorityCorrectly() {
            // Arrange
            PriorityCollection priorityCollection = new PriorityCollection(new PriorityTestDao());

            // Act
            priorityCollection.Add(FooPriority);

            // Assert
            Assert.AreEqual(1, priorityCollection.Count);
        }

        [TestMethod]
        public void PriorityCollection_Add_ThrowsException_BecausePriorityWithNameAlreadyExists() {
            // Arrange
            PriorityCollection priorityCollection = new PriorityCollection(new PriorityTestDao());
            priorityCollection.Add(FooPriority);

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => priorityCollection.Add(new Priority("foo", 2)));
        }

        [TestMethod]
        public void PriorityCollection_RemovesPriorityByNameCorrectly() {
            // Arrange
            PriorityCollection priorityCollection = new PriorityCollection(new PriorityTestDao());
            priorityCollection.Add(FooPriority);

            // Act
            bool successful = priorityCollection.RemoveByName("foo");

            // Assert
            Assert.IsTrue(successful);
        }

        [TestMethod]
        public void PriorityCollection_RemoveByName_ReturnsFalse_BecausePriorityWithNameDoesNotExist() {
            // Arrange
            PriorityCollection priorityCollection = new PriorityCollection(new PriorityTestDao());
            
            // Act
            bool successful = priorityCollection.RemoveByName("foo");

            // Assert
            Assert.IsFalse(successful);
        }

        [TestMethod]
        public void PriorityCollection_GetsPriorityByNameCorrectly() {
            // Arrange
            PriorityCollection priorityCollection = new PriorityCollection(new PriorityTestDao());
            priorityCollection.Add(FooPriority);
            priorityCollection.Add(BarPriority);

            // Act
            Priority priority = priorityCollection["foo"];

            // Assert
            Assert.AreEqual("foo", priority.Name);
        }

        [TestMethod]
        public void PriorityCollection_Get_ThrowsException_BecauseNameIsNull() {
            // Arrange
            PriorityCollection priorityCollection = new PriorityCollection(new PriorityTestDao());

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => priorityCollection[null]);
        }

        [TestMethod]
        public void PriorityCollection_Get_ThrowsException_BecausePriorityWithNameDoesNotExist() {
            // Arrange
            PriorityCollection priorityCollection = new PriorityCollection(new PriorityTestDao());

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => priorityCollection["foo"]);
        }

        [TestMethod]
        public void PriorityCollection_SetsPriorityByNameCorrectly() {
            // Arrange
            PriorityCollection priorityCollection = new PriorityCollection(new PriorityTestDao());
            priorityCollection.Add(FooPriority);
            priorityCollection.Add(BarPriority);

            // Act
            priorityCollection["foo"] = BazPriority;

            // Assert
            Assert.AreEqual("baz", priorityCollection["baz"].Name);
        }

        [TestMethod]
        public void PriorityCollection_Set_ThrowsException_BecauseNameIsNull() {
            // Arrange
            PriorityCollection priorityCollection = new PriorityCollection(new PriorityTestDao());
            priorityCollection.Add(FooPriority);
            priorityCollection.Add(BarPriority);

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => priorityCollection[null] = BazPriority);
        }

        [TestMethod]
        public void PriorityCollection_Set_ThrowsException_BecauseValueIsNull() {
            // Arrange
            PriorityCollection priorityCollection = new PriorityCollection(new PriorityTestDao());
            priorityCollection.Add(FooPriority);
            priorityCollection.Add(BarPriority);

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => priorityCollection["foo"] = null);
        }

        [TestMethod]
        public void PriorityCollection_Set_ThrowsException_BecausePriorityWithNameDoesNotExist() {
            // Arrange
            PriorityCollection priorityCollection = new PriorityCollection(new PriorityTestDao());
            
            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => priorityCollection["foo"] = BazPriority);
        }

        [TestMethod]
        public void PriorityCollection_Set_ThrowsException_BecausePriorityWithNameAlreadyExists() {
            // Arrange
            PriorityCollection priorityCollection = new PriorityCollection(new PriorityTestDao());
            priorityCollection.Add(FooPriority);
            priorityCollection.Add(BarPriority);

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => priorityCollection["foo"] = BarPriority);
        }
    }
}
