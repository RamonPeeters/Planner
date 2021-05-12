using Microsoft.VisualStudio.TestTools.UnitTesting;
using Planner.Logic.Participants;
using Planner.Tests.TestDal.Participants;
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
            ParticipantCollection participantCollection = new ParticipantCollection(new ParticipantTestDao());

            // Act
            participantCollection.Add(FooParticipant);

            // Assert
            Assert.AreEqual(1, participantCollection.Count);
        }

        [TestMethod]
        public void ParticipantCollection_Add_ThrowsException_BecauseParticipantWithEmailAlreadyExists() {
            // Arrange
            ParticipantCollection participantCollection = new ParticipantCollection(new ParticipantTestDao());
            participantCollection.Add(FooParticipant);

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => participantCollection.Add(new Participant("Foo2", "Test2", "foo@ema.il")));
        }

        [TestMethod]
        public void ParticipantCollection_RemovesParticipantByEmailCorrectly() {
            // Arrange
            ParticipantCollection participantCollection = new ParticipantCollection(new ParticipantTestDao());
            participantCollection.Add(FooParticipant);

            // Act
            bool successful = participantCollection.RemoveByEmail("foo@ema.il");

            // Assert
            Assert.IsTrue(successful);
        }

        [TestMethod]
        public void ParticipantCollection_RemoveByEmail_ReturnsFalse_BecauseParticipantWithEmailDoesNotExist() {
            // Arrange
            ParticipantCollection participantCollection = new ParticipantCollection(new ParticipantTestDao());

            // Act
            bool successful = participantCollection.RemoveByEmail("foo@ema.il");

            // Assert
            Assert.IsFalse(successful);
        }

        [TestMethod]
        public void ParticipantCollection_GetsParticipantByEmailCorrectly() {
            // Arrange
            ParticipantCollection participantCollection = new ParticipantCollection(new ParticipantTestDao());
            participantCollection.Add(FooParticipant);
            participantCollection.Add(BarParticipant);

            // Act
            Participant participant = participantCollection["foo@ema.il"];

            // Assert
            Assert.AreEqual("foo@ema.il", participant.Email);
        }

        [TestMethod]
        public void ParticipantCollection_Get_ThrowsException_BecauseEmailIsNull() {
            // Arrange
            ParticipantCollection participantCollection = new ParticipantCollection(new ParticipantTestDao());

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => participantCollection[null]);
        }

        [TestMethod]
        public void ParticipantCollection_Get_ThrowsException_BecauseEmailDoesNotExist() {
            // Arrange
            ParticipantCollection participantCollection = new ParticipantCollection(new ParticipantTestDao());

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => participantCollection["foo@ema.il"]);
        }

        [TestMethod]
        public void ParticipantCollection_SetsParticipantByEmailCorrectly() {
            // Arrange
            ParticipantCollection ParticipantCollection = new ParticipantCollection(new ParticipantTestDao());
            ParticipantCollection.Add(FooParticipant);
            ParticipantCollection.Add(BarParticipant);

            // Act
            ParticipantCollection["foo@ema.il"] = BazParticipant;

            // Assert
            Assert.AreEqual("baz@ema.il", ParticipantCollection["baz@ema.il"].Email);
        }

        [TestMethod]
        public void ParticipantCollection_Set_ThrowsException_BecauseEmailIsNull() {
            // Arrange
            ParticipantCollection ParticipantCollection = new ParticipantCollection(new ParticipantTestDao());
            ParticipantCollection.Add(FooParticipant);
            ParticipantCollection.Add(BarParticipant);

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => ParticipantCollection[null] = BazParticipant);
        }

        [TestMethod]
        public void ParticipantCollection_Set_ThrowsException_BecauseValueIsNull() {
            // Arrange
            ParticipantCollection ParticipantCollection = new ParticipantCollection(new ParticipantTestDao());
            ParticipantCollection.Add(FooParticipant);
            ParticipantCollection.Add(BarParticipant);

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => ParticipantCollection["foo@ema.il"] = null);
        }

        [TestMethod]
        public void ParticipantCollection_Set_ThrowsException_BecauseParticipantWithEmailDoesNotExist() {
            // Arrange
            ParticipantCollection ParticipantCollection = new ParticipantCollection(new ParticipantTestDao());

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => ParticipantCollection["foo@ema.il"] = BazParticipant);
        }

        [TestMethod]
        public void ParticipantCollection_Set_ThrowsException_BecauseParticipantWithEmailAlreadyExists() {
            // Arrange
            ParticipantCollection ParticipantCollection = new ParticipantCollection(new ParticipantTestDao());
            ParticipantCollection.Add(FooParticipant);
            ParticipantCollection.Add(BarParticipant);

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => ParticipantCollection["foo@ema.il"] = BarParticipant);
        }
    }
}
