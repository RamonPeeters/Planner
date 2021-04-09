using Planner.DalInterfaces.Appointments;
using System.Collections.Generic;

namespace Planner.Logic.Appointments {
    static class AppointmentMapper {
        public static Appointment ToAppointment(AppointmentDto appointmentDto) {
            return new Appointment(appointmentDto.Title, appointmentDto.Description, appointmentDto.StartDate, appointmentDto.EndDate);
        }

        public static IEnumerable<Appointment> ToAppointments(IEnumerable<AppointmentDto> appointmentDtos) {
            foreach (AppointmentDto appointmentDto in appointmentDtos) {
                yield return ToAppointment(appointmentDto);
            }
        }
    }
}
