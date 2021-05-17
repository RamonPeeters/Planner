using Planner.DalInterfaces.Appointments;
using System;
using System.Collections.Generic;

namespace Planner.Logic.Appointments {
    public class AppointmentCollection {
        private const string AppointmentIdNotFound = "An appointment with id {0} was not found.";

        private readonly IAppointmentDao AppointmentDao;
        private readonly List<Appointment> Appointments;

        public AppointmentCollection(IAppointmentDao appointmentDao) {
            AppointmentDao = appointmentDao;

            List<AppointmentDto> appointmentDtos = AppointmentDao.GetAppointments();
            Appointments = new List<Appointment>(AppointmentMapper.ToAppointments(appointmentDtos));
        }

        public Appointment this[int id] {
            get {
                int index = Appointments.FindIndex(item => item.Id == id);
                if (index == -1) {
                    throw new ArgumentException(string.Format(AppointmentIdNotFound, id));
                }
                return Appointments[index];
            }
            set {
                int index = Appointments.FindIndex(a => a.Id == id);
                if (index == -1) {
                    throw new ArgumentException(string.Format(AppointmentIdNotFound, id));
                }
                AppointmentDao.UpdateAppointment(id, AppointmentMapper.ToAppointmentDto(value));
                Appointments[index] = new Appointment(id, value.Title, value.Description, value.StartDate, value.EndDate, value.Finished);
            }
        }

        public void Add(Appointment appointment) {
            int id = AppointmentDao.CreateAppointment(AppointmentMapper.ToAppointmentDto(appointment));
            Appointments.Add(new Appointment(id, appointment.Title, appointment.Description, appointment.StartDate, appointment.EndDate, appointment.Finished, appointment.Priority));
        }

        public bool RemoveById(int id) {
            int rows = AppointmentDao.DeleteAppointment(id);
            if (rows > 0) return Appointments.RemoveAll(a => a.Id == id) > 0;
            return false;
        }

        public int Count { get { return Appointments.Count; } }
    }
}
