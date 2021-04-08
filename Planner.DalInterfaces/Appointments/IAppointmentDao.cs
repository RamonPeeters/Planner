using System.Collections.Generic;

namespace Planner.DalInterfaces.Appointments {
    public interface IAppointmentDao {
        public List<IAppointmentDto> GetAppointments();
        public int CreateAppointment(IAppointmentDto appointmentDto);
        public int UpdateAppointment(IAppointmentDto appointmentDto);
        public int DeleteAppointment(IAppointmentDto appointmentDto);
    }
}
