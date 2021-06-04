using Planner.LogicInterfaces.Appointments;
using Planner.Presentation.Models;
using System.Collections.Generic;

namespace Planner.Presentation.Mappers {
    static class AppointmentViewModelMapper {
        public static AppointmentViewModel ToAppointmentViewModel(Appointment appointment) {
            return new AppointmentViewModel(appointment.Id, appointment.Title, appointment.Description, appointment.StartDate, appointment.EndDate, appointment.Finished);
        }

        public static IEnumerable<AppointmentViewModel> ToAppointmentViewModels(IAppointmentCollection appointments) {
            foreach (Appointment appointment in appointments) {
                yield return ToAppointmentViewModel(appointment);
            }
        }
    }
}
