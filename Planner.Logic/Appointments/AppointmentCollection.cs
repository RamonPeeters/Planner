using System.Collections.Generic;

namespace Planner.Logic.Appointments {
    public class AppointmentCollection {
        private readonly List<Appointment> Appointments;

        public AppointmentCollection() {
            Appointments = new List<Appointment>();
        }

        public Appointment this[int index] { get { return Appointments[index]; } set { Appointments[index] = value; } }

        public void Add(Appointment appointment) {
            Appointments.Add(appointment);
        }

        public bool Remove(Appointment appointment) {
            return Appointments.Remove(appointment);
        }
    }
}
