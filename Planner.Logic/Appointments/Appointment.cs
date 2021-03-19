using Planner.LogicInterfaces.Appointments;
using System;

namespace Planner.Logic.Appointments {
    public class Appointment : IAppointment {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Finished { get; set; }

        public bool UpdateAppointment() {
            throw new NotImplementedException();
        }

        public bool DeleteAppointment() {
            throw new NotImplementedException();
        }
    }
}
