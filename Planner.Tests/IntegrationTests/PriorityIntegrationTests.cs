using Dapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using Planner.Logic.Priorities;
using Planner.LogicFactory;
using Planner.LogicInterfaces.Priorities;
using System.Data;

namespace Planner.Tests.IntegrationTests {
    [TestClass]
    public class PriorityIntegrationTests {
        private readonly Priority TestPriority = new Priority("Test", 1);

        [TestInitialize]
        public void Initialise() {
            string sql = @"set FOREIGN_KEY_CHECKS = 0;
                           truncate table priorities;
                           set FOREIGN_KEY_CHECKS = 1;
                           insert into priorities(`Name`, `Colour`) values
                              ('Foo', 1),
                              ('Bar', 1),
                              ('Baz', 2);";
            using IDbConnection connection = new MySqlConnection(DalTestHelper.ConnectionString);
            connection.Execute(sql);
        }

        [TestMethod]
        public void PriorityCollection_GetPriorities() {
            // Arrange
            PriorityCollection priorityCollection = PriorityLogicFactory.GetPriorityCollection(DalTestHelper.ConnectionString);

            // Act
            Priority priority = priorityCollection["Foo"];

            // Assert
            Assert.AreEqual("Foo", priority.Name);
        }

        [TestMethod]
        public void PriorityCollection_AddPriority() {
            // Arrange
            PriorityCollection priorityCollection = PriorityLogicFactory.GetPriorityCollection(DalTestHelper.ConnectionString);

            // Act
            priorityCollection.Add(TestPriority);

            // Assert
            Assert.AreEqual("Test", priorityCollection["Test"].Name);
        }

        [TestMethod]
        public void PriorityCollection_DeletePriority() {
            // Arrange
            PriorityCollection priorityCollection = PriorityLogicFactory.GetPriorityCollection(DalTestHelper.ConnectionString);

            // Act
            bool successful = priorityCollection.RemoveByName("Foo");

            // Assert
            Assert.IsTrue(successful);
        }

        [TestMethod]
        public void PriorityCollection_SetPriority() {
            // Arrange
            PriorityCollection priorityCollection = PriorityLogicFactory.GetPriorityCollection(DalTestHelper.ConnectionString);

            // Act
            priorityCollection["Foo"] = TestPriority;

            // Assert
            Assert.AreEqual("Test", priorityCollection["Test"].Name);
        }
    }
}
