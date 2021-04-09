using System.Collections.Generic;

namespace Planner.DalInterfaces.Appointments {
    public interface IAppointmentDao {
        public List<AppointmentDto> GetAppointments();
        public int CreateAppointment(AppointmentDto appointmentDto);
        public int UpdateAppointment(AppointmentDto appointmentDto);
        public int DeleteAppointment(AppointmentDto appointmentDto);
    }
}
