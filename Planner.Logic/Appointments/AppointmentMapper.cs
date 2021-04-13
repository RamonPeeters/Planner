using Planner.DalInterfaces.Appointments;
using System.Collections.Generic;

namespace Planner.Logic.Appointments {
    static class AppointmentMapper {
        public static Appointment ToAppointment(AppointmentDto appointmentDto) {
            return new Appointment(appointmentDto.Id, appointmentDto.Title, appointmentDto.Description, appointmentDto.StartDate, appointmentDto.EndDate, appointmentDto.Finished);
        }

        public static IEnumerable<Appointment> ToAppointments(IEnumerable<AppointmentDto> appointmentDtos) {
            foreach (AppointmentDto appointmentDto in appointmentDtos) {
                yield return ToAppointment(appointmentDto);
            }
        }

        public static AppointmentDto ToAppointmentDto(Appointment appointment) {
            return new AppointmentDto(appointment.Id, appointment.Title, appointment.Description, appointment.StartDate, appointment.EndDate, appointment.Finished);
        }
    }
}
