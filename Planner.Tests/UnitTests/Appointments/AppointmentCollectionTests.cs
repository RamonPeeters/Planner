using Microsoft.VisualStudio.TestTools.UnitTesting;
using Planner.Logic.Appointments;
using Planner.Tests.TestDal.Appointments;
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
            AppointmentCollection appointmentCollection = new AppointmentCollection(new AppointmentTestDao());

            // Act
            appointmentCollection.Add(FooAppointment);

            // Assert
            Assert.AreEqual(1, appointmentCollection.Count);
        }

        [TestMethod]
        public void AppointmentCollection_RemovesAppointmentCorrectly() {
            // Arrange
            AppointmentCollection appointmentCollection = new AppointmentCollection(new AppointmentTestDao());
            appointmentCollection.Add(FooAppointment);

            // Act
            bool successful = appointmentCollection.RemoveById(1);

            // Assert
            Assert.IsTrue(successful);
        }

        [TestMethod]
        public void AppointmentCollection_RemovesAppointmentIncorrectly_BecauseItemIsNotInCollection() {
            // Arrange
            AppointmentCollection appointmentCollection = new AppointmentCollection(new AppointmentTestDao());

            // Act
            bool successful = appointmentCollection.RemoveById(-1);

            // Assert
            Assert.IsFalse(successful);
        }

        [TestMethod]
        public void AppointmentCollection_GetsAppointmentByIdCorrectly() {
            // Arrange
            AppointmentCollection appointmentCollection = new AppointmentCollection(new AppointmentTestDao());
            appointmentCollection.Add(FooAppointment);
            appointmentCollection.Add(BarAppointment);

            // Act
            Appointment appointment = appointmentCollection[1];

            // Assert
            Assert.AreEqual("foo", appointment.Title);
        }

        [TestMethod]
        public void AppointmentCollection_GetThrowsException_BecauseAppointmentWithIdDoesNotExist() {
            // Arrange
            AppointmentCollection appointmentCollection = new AppointmentCollection(new AppointmentTestDao());

            // Act, Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => appointmentCollection[-1]);
        }

        [TestMethod]
        public void AppointmentCollection_SetsAppointmentByIdCorrectly() {
            // Arrange
            AppointmentCollection appointmentCollection = new AppointmentCollection(new AppointmentTestDao());
            appointmentCollection.Add(FooAppointment);
            appointmentCollection.Add(BarAppointment);

            // Act
            appointmentCollection[1] = BazAppointment;

            // Assert
            Assert.AreEqual("baz", appointmentCollection[1].Title);
        }

        [TestMethod]
        public void AppointmentCollection_SetThrowsException_BecauseAppointmentWithIdDoesNotExist() {
            // Arrange
            AppointmentCollection appointmentCollection = new AppointmentCollection(new AppointmentTestDao());

            // Act, Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => appointmentCollection[-1] = FooAppointment);
        }
    }
}
