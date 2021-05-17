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
            AppointmentDto actualAppointmentDto = new AppointmentDto(IdAutoIncrement++, appointmentDto.Title, appointmentDto.Description, appointmentDto.StartDate, appointmentDto.EndDate, appointmentDto.Finished, appointmentDto.Priority);
            Appointments.Add(actualAppointmentDto);
            return actualAppointmentDto.Id;
        }

        public int UpdateAppointment(int id, AppointmentDto appointmentDto) {
            int index = Appointments.FindIndex(a => a.Id == id);
            if (index == -1) return 0;
            Appointments[index] = appointmentDto;
            return 1;
        }

        public int DeleteAppointment(int id) {
            return Appointments.RemoveAll(a => a.Id == id);
        }
    }
}
