using Microsoft.VisualStudio.TestTools.UnitTesting;
using Planner.Logic.Participants;
using System;

namespace Planner.Tests.UnitTests.Participants {
    [TestClass]
    public class ParticipantCollectionTests {
        [TestMethod]
        public void ParticipantCollection_AddsParticipantCorrectly() {
            // Arrange
            ParticipantCollection participantCollection = new ParticipantCollection();
            Participant participant = new Participant() { Email = "foo@a.b" };

            // Act
            participantCollection.Add(participant);

            // Assert
            Assert.AreEqual(1, participantCollection.Count);
        }

        [TestMethod]
        public void ParticipantCollection_RemovesParticipantCorrectly() {
            // Arrange
            ParticipantCollection participantCollection = new ParticipantCollection();
            Participant participant = new Participant() { Email = "foo@a.b" };
            participantCollection.Add(participant);

            // Act
            bool successful = participantCollection.Remove(participant);

            // Assert
            Assert.IsTrue(successful);
        }

        [TestMethod]
        public void ParticipantCollection_RemovesParticipantIncorrectly_BecauseItemIsNotInCollection() {
            // Arrange
            ParticipantCollection participantCollection = new ParticipantCollection();
            Participant participant = new Participant() { Email = "foo@a.b" };

            // Act
            bool successful = participantCollection.Remove(participant);

            // Assert
            Assert.IsFalse(successful);
        }

        [TestMethod]
        public void ParticipantCollection_GetsParticipantByIndexCorrectly() {
            // Arrange
            ParticipantCollection participantCollection = new ParticipantCollection();
            participantCollection.Add(new Participant() { Email = "foo@a.b" });
            participantCollection.Add(new Participant() { Email = "bar@a.b" });

            // Act
            Participant participant = participantCollection[0];

            // Assert
            Assert.AreEqual("foo@a.b", participant.Email);
        }

        [TestMethod]
        public void ParticipantCollection_GetThrowsException_BecauseIndexIsOutOfRange() {
            // Arrange
            ParticipantCollection participantCollection = new ParticipantCollection();

            // Act, Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => participantCollection[-1]);
        }

        [TestMethod]
        public void ParticipantCollection_SetsParticipantByIndexCorrectly() {
            // Arrange
            ParticipantCollection participantCollection = new ParticipantCollection();
            participantCollection.Add(new Participant() { Email = "foo@a.b" });
            participantCollection.Add(new Participant() { Email = "bar@a.b" });

            // Act
            participantCollection[0] = new Participant() { Email = "baz@a.b" };

            // Assert
            Assert.AreEqual("baz@a.b", participantCollection[0].Email);
        }

        [TestMethod]
        public void ParticipantCollection_SetThrowsException_BecauseIndexIsOutOfRange() {
            // Arrange
            ParticipantCollection participantCollection = new ParticipantCollection();

            // Act, Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => participantCollection[-1] = new Participant() { Email = "foo@a.b" });
        }
    }
}
