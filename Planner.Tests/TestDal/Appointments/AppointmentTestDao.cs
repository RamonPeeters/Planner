using Planner.DalInterfaces.Appointments;
using System.Collections.Generic;

namespace Planner.Tests.TestDal.Appointments {
    public class AppointmentTestDao : IAppointmentDao {
        private int IdAutoIncrement = 1;
        private readonly List<AppointmentDto> Appointments = new List<AppointmentDto>();

        public List<AppointmentDto> GetAppointments() {
            return new List<AppointmentDto>(Appointments);
        }

        public int CreateAppointment(AppointmentDto appointmentDto) {
            Appointments.Add(appointmentDto);
            appointmentDto.Id = IdAutoIncrement++;
            return 1;
        }

        public int UpdateAppointment(AppointmentDto appointmentDto) {
            int index = Appointments.FindIndex(a => a.Id == appointmentDto.Id);
            if (index == -1) return 0;
            Appointments[index] = appointmentDto;
            return 1;
        }

        public int DeleteAppointment(AppointmentDto appointmentDto) {
            return Appointments.RemoveAll(a => a.Id == appointmentDto.Id);
        }
    }
}
