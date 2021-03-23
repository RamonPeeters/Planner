using System;

namespace Planner.Logic.Appointments {
    public class Appointment {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Finished { get; set; }

        public bool CreateAppointment(Appointment appointment) {
            throw new NotImplementedException();
        }

        public bool UpdateAppointment() {
            throw new NotImplementedException();
        }

        public bool DeleteAppointment() {
            throw new NotImplementedException();
        }
    }
}
