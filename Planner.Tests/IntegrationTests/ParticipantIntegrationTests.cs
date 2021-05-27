using Dapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using Planner.Logic.Participants;
using Planner.LogicFactory;
using Planner.LogicInterfaces.Participants;
using System.Data;

namespace Planner.Tests.IntegrationTests {
    [TestClass]
    public class ParticipantIntegrationTests {
        private readonly Participant TestParticipant = new Participant("Test", "Tester", "test@ema.il");

        [TestInitialize]
        public void Initialise() {
            string sql = @"set FOREIGN_KEY_CHECKS = 0;
                           truncate table participants;
                           set FOREIGN_KEY_CHECKS = 1;
                           insert into participants(`FirstName`, `LastName`, `Email`) values
                              ('Foo', 'Test', 'foo@ema.il'),
                              ('Bar', 'Test', 'bar@ema.il'),
                              ('Baz', 'Test', 'baz@ema.il');";
            using IDbConnection connection = new MySqlConnection(DalTestHelper.ConnectionString);
            connection.Execute(sql);
        }

        [TestMethod]
        public void ParticipantCollection_GetParticipants() {
            // Arrange
            ParticipantCollection participantCollection = ParticipantLogicFactory.GetParticipantCollection(DalTestHelper.ConnectionString);

            // Act
            Participant participant = participantCollection["foo@ema.il"];

            // Assert
            Assert.AreEqual("foo@ema.il", participant.Email);
        }

        [TestMethod]
        public void ParticipantCollection_AddParticipant() {
            // Arrange
            ParticipantCollection participantCollection = ParticipantLogicFactory.GetParticipantCollection(DalTestHelper.ConnectionString);

            // Act
            participantCollection.Add(TestParticipant);

            // Assert
            Assert.AreEqual("test@ema.il", participantCollection["test@ema.il"].Email);
        }

        [TestMethod]
        public void ParticipantCollection_DeleteParticipant() {
            // Arrange
            ParticipantCollection participantCollection = ParticipantLogicFactory.GetParticipantCollection(DalTestHelper.ConnectionString);

            // Act
            bool successful = participantCollection.RemoveByEmail("foo@ema.il");

            // Assert
            Assert.IsTrue(successful);
        }

        [TestMethod]
        public void ParticipantCollection_SetParticipant() {
            // Arrange
            ParticipantCollection participantCollection = ParticipantLogicFactory.GetParticipantCollection(DalTestHelper.ConnectionString);

            // Act
            participantCollection["foo@ema.il"] = TestParticipant;

            // Assert
            Assert.AreEqual("test@ema.il", participantCollection["test@ema.il"].Email);
        }
    }
}
