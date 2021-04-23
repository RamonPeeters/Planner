using Dapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using Planner.Logic.Appointments;
using Planner.LogicFactory;
using System;
using System.Data;

namespace Planner.Tests.IntegrationTests {
    [TestClass]
    public class AppointmentIntegrationTests {
        private readonly string ConnectionString = "Server=localhost;Database=plannertestdb;Uid=root;Pwd=;";
        private readonly Appointment TestAppointment = new Appointment("Test", new DateTime(2021, 4, 1, 10, 0, 0), new DateTime(2021, 4, 1, 11, 0, 0));

        [TestInitialize]
        public void Initialise() {
            string sql = @"set FOREIGN_KEY_CHECKS = 0;
                           truncate table appointments;
                           set FOREIGN_KEY_CHECKS = 1;
                           insert into appointments(`Title`, `StartDate`, `EndDate`) values
                              ('Foo', '2021-4-1T12:00:00', '2021-4-1T13:00:00'),
                              ('Bar', '2021-4-1T12:30:00', '2021-4-1T14:00:00'),
                              ('Baz', '2021-4-1T13:00:00', '2021-4-1T14:00:00');";
            using IDbConnection connection = new MySqlConnection(ConnectionString);
            connection.Execute(sql);
        }

        [TestMethod]
        public void AppointmentCollection_GetAppointments() {
            // Arrange
            AppointmentCollection appointmentCollection = AppointmentLogicFactory.GetAppointmentCollection(ConnectionString);

            // Act
            Appointment appointment = appointmentCollection[1];

            // Assert
            Assert.AreEqual("Foo", appointment.Title);
        }

        [TestMethod]
        public void AppointmentCollection_AddAppointment() {
            // Arrange
            AppointmentCollection appointmentCollection = AppointmentLogicFactory.GetAppointmentCollection(ConnectionString);

            // Act
            appointmentCollection.Add(TestAppointment);

            // Assert
            Assert.AreEqual(4, appointmentCollection[4].Id);
        }

        [TestMethod]
        public void AppointmentCollection_DeleteAppointment() {
            // Arrange
            AppointmentCollection appointmentCollection = AppointmentLogicFactory.GetAppointmentCollection(ConnectionString);

            // Act
            bool successful = appointmentCollection.RemoveById(1);

            // Assert
            Assert.IsTrue(successful);
        }

        [TestMethod]
        public void AppointmentCollection_SetAppointment() {
            // Arrange
            AppointmentCollection appointmentCollection = AppointmentLogicFactory.GetAppointmentCollection(ConnectionString);

            // Act
            appointmentCollection[1] = TestAppointment;

            // Assert
            Assert.AreEqual("Test", appointmentCollection[1].Title);
        }
    }
}
