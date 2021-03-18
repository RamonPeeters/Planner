using Planner.LogicInterfaces.Appointments;
using System;
using System.Collections.Generic;

namespace Planner.Logic {
    public class Appointment : IAppointment, IAppointmentContainer {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Finished { get; set; }

        public List<IAppointment> GetAppointments(DateTime from, DateTime until) {
            throw new NotImplementedException();
        }

        public IAppointment GetAppointmentById(int id) {
            throw new NotImplementedException();
        }

        public bool CreateAppointment(IAppointment appointment) {
            throw new NotImplementedException();
        }

        public bool Update() {
            throw new NotImplementedException();
        }

        public bool Delete() {
            throw new NotImplementedException();
        }
    }
}
