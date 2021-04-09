using Planner.DalInterfaces.Appointments;
using System.Collections.Generic;

namespace Planner.Logic.Appointments {
    public class AppointmentCollection {
        private readonly IAppointmentDao AppointmentDao;
        private readonly List<Appointment> Appointments;

        public AppointmentCollection(IAppointmentDao appointmentDao) {
            AppointmentDao = appointmentDao;

            List<AppointmentDto> appointmentDtos = AppointmentDao.GetAppointments();
            Appointments = new List<Appointment>(AppointmentMapper.ToAppointments(appointmentDtos));
        }

        public Appointment this[int index] { get { return Appointments[index]; } set { Appointments[index] = value; } }

        public void Add(Appointment appointment) {
            Appointments.Add(appointment);
        }

        public bool Remove(Appointment appointment) {
            return Appointments.Remove(appointment);
        }

        public int Count { get { return Appointments.Count; } }
    }
}
