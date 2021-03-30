using Microsoft.VisualStudio.TestTools.UnitTesting;
using Planner.Logic.Appointments;
using System;

namespace Planner.Tests.UnitTests.Appointments {
    [TestClass]
    public class AppointmentCollectionTests {
        private readonly Appointment FooAppointment = new Appointment("foo", new DateTime(2000, 1, 1), new DateTime(2000, 1, 2));
        private readonly Appointment BarAppointment = new Appointment("bar", new DateTime(2000, 1, 10), new DateTime(2000, 1, 11));
        private readonly Appointment BazAppointment = new Appointment("baz", new DateTime(2000, 2, 1), new DateTime(2000, 2, 2));

        [TestMethod]
        public void AppointmentCollection_AddsAppointmentCorrectly() {
            // Arrange
            AppointmentCollection appointmentCollection = new AppointmentCollection();

            // Act
            appointmentCollection.Add(FooAppointment);

            // Assert
            Assert.AreEqual(1, appointmentCollection.Count);
        }

        [TestMethod]
        public void AppointmentCollection_RemovesAppointmentCorrectly() {
            // Arrange
            AppointmentCollection appointmentCollection = new AppointmentCollection();
            appointmentCollection.Add(FooAppointment);

            // Act
            bool successful = appointmentCollection.Remove(FooAppointment);

            // Assert
            Assert.IsTrue(successful);
        }

        [TestMethod]
        public void AppointmentCollection_RemovesAppointmentIncorrectly_BecauseItemIsNotInCollection() {
            // Arrange
            AppointmentCollection appointmentCollection = new AppointmentCollection();

            // Act
            bool successful = appointmentCollection.Remove(FooAppointment);

            // Assert
            Assert.IsFalse(successful);
        }

        [TestMethod]
        public void AppointmentCollection_GetsAppointmentByIndexCorrectly() {
            // Arrange
            AppointmentCollection appointmentCollection = new AppointmentCollection();
            appointmentCollection.Add(FooAppointment);
            appointmentCollection.Add(BarAppointment);

            // Act
            Appointment appointment = appointmentCollection[0];

            // Assert
            Assert.AreEqual("foo", appointment.Title);
        }

        [TestMethod]
        public void AppointmentCollection_GetThrowsException_BecauseIndexIsOutOfRange() {
            // Arrange
            AppointmentCollection appointmentCollection = new AppointmentCollection();

            // Act, Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => appointmentCollection[-1]);
        }

        [TestMethod]
        public void AppointmentCollection_SetsAppointmentByIndexCorrectly() {
            // Arrange
            AppointmentCollection appointmentCollection = new AppointmentCollection();
            appointmentCollection.Add(FooAppointment);
            appointmentCollection.Add(BarAppointment);

            // Act
            appointmentCollection[0] = BazAppointment;

            // Assert
            Assert.AreEqual("baz", appointmentCollection[0].Title);
        }

        [TestMethod]
        public void AppointmentCollection_SetThrowsException_BecauseIndexIsOutOfRange() {
            // Arrange
            AppointmentCollection appointmentCollection = new AppointmentCollection();

            // Act, Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => appointmentCollection[-1] = FooAppointment);
        }
    }
}
