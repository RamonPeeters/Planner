using Microsoft.VisualStudio.TestTools.UnitTesting;
using Planner.Logic.Appointments;
using Planner.LogicInterfaces.Appointments;
using System;

namespace Planner.Tests.UnitTests.Appointments {
    [TestClass]
    public class AppointmentTests {
        [TestMethod]
        public void Appointment_ShouldBeFinished_BecauseAppointmentWasMarkedAsFinished() {
            // Arrange
            Appointment appointment = new Appointment("foo", new DateTime(2000, 1, 1), new DateTime(2000, 1, 2));

            // Act
            appointment.FinishAppointment();

            // Assert
            Assert.IsTrue(appointment.Finished);
        }
    }
}
