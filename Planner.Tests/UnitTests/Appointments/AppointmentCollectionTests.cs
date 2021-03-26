﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Planner.Logic.Appointments;
using System;

namespace Planner.Tests.UnitTests.Appointments {
    [TestClass]
    public class AppointmentCollectionTests {
        [TestMethod]
        public void AppointmentCollection_AddsAppointmentCorrectly() {
            // Arrange
            AppointmentCollection appointmentCollection = new AppointmentCollection();
            Appointment appointment = new Appointment() { Title = "foo" };

            // Act
            appointmentCollection.Add(appointment);

            // Assert
            Assert.AreEqual(1, appointmentCollection.Count);
        }

        [TestMethod]
        public void AppointmentCollection_RemovesAppointmentCorrectly() {
            // Arrange
            AppointmentCollection appointmentCollection = new AppointmentCollection();
            Appointment appointment = new Appointment() { Title = "foo" };
            appointmentCollection.Add(appointment);

            // Act
            bool successful = appointmentCollection.Remove(appointment);

            // Assert
            Assert.IsTrue(successful);
        }

        [TestMethod]
        public void AppointmentCollection_RemovesAppointmentIncorrectly_BecauseItemIsNotInCollection() {
            // Arrange
            AppointmentCollection appointmentCollection = new AppointmentCollection();
            Appointment appointment = new Appointment() { Title = "foo" };

            // Act
            bool successful = appointmentCollection.Remove(appointment);

            // Assert
            Assert.IsFalse(successful);
        }

        [TestMethod]
        public void AppointmentCollection_GetsAppointmentByIndexCorrectly() {
            // Arrange
            AppointmentCollection appointmentCollection = new AppointmentCollection();
            appointmentCollection.Add(new Appointment() { Title = "foo" });
            appointmentCollection.Add(new Appointment() { Title = "bar" });

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
            appointmentCollection.Add(new Appointment() { Title = "foo" });
            appointmentCollection.Add(new Appointment() { Title = "bar" });

            // Act
            appointmentCollection[0] = new Appointment() { Title = "baz" };

            // Assert
            Assert.AreEqual("baz", appointmentCollection[0].Title);
        }

        [TestMethod]
        public void AppointmentCollection_SetThrowsException_BecauseIndexIsOutOfRange() {
            // Arrange
            AppointmentCollection appointmentCollection = new AppointmentCollection();

            // Act, Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => appointmentCollection[-1] = new Appointment() { Title = "foo" });
        }
    }
}