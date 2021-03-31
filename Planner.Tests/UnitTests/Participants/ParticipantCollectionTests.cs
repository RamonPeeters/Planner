using Microsoft.VisualStudio.TestTools.UnitTesting;
using Planner.Logic.Participants;
using System;

namespace Planner.Tests.UnitTests.Participants {
    [TestClass]
    public class ParticipantCollectionTests {
        private readonly Participant FooParticipant = new Participant("Foo", "Test", "foo@ema.il");
        private readonly Participant BarParticipant = new Participant("Bar", "Test", "bar@ema.il");
        private readonly Participant BazParticipant = new Participant("Baz", "Test", "baz@ema.il");

        [TestMethod]
        public void ParticipantCollection_AddsParticipantCorrectly() {
            // Arrange
            ParticipantCollection participantCollection = new ParticipantCollection();

            // Act
            participantCollection.Add(FooParticipant);

            // Assert
            Assert.AreEqual(1, participantCollection.Count);
        }

        [TestMethod]
        public void ParticipantCollection_RemovesParticipantCorrectly() {
            // Arrange
            ParticipantCollection participantCollection = new ParticipantCollection();
            participantCollection.Add(FooParticipant);

            // Act
            bool successful = participantCollection.Remove(FooParticipant);

            // Assert
            Assert.IsTrue(successful);
        }

        [TestMethod]
        public void ParticipantCollection_RemovesParticipantIncorrectly_BecauseItemIsNotInCollection() {
            // Arrange
            ParticipantCollection participantCollection = new ParticipantCollection();

            // Act
            bool successful = participantCollection.Remove(FooParticipant);

            // Assert
            Assert.IsFalse(successful);
        }

        [TestMethod]
        public void ParticipantCollection_GetsParticipantByIndexCorrectly() {
            // Arrange
            ParticipantCollection participantCollection = new ParticipantCollection();
            participantCollection.Add(FooParticipant);
            participantCollection.Add(BarParticipant);

            // Act
            Participant participant = participantCollection[0];

            // Assert
            Assert.AreEqual("foo@ema.il", participant.Email);
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
            participantCollection.Add(FooParticipant);
            participantCollection.Add(BarParticipant);

            // Act
            participantCollection[0] = BazParticipant;

            // Assert
            Assert.AreEqual("baz@ema.il", participantCollection[0].Email);
        }

        [TestMethod]
        public void ParticipantCollection_SetThrowsException_BecauseIndexIsOutOfRange() {
            // Arrange
            ParticipantCollection participantCollection = new ParticipantCollection();

            // Act, Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => participantCollection[-1] = FooParticipant);
        }
    }
}
