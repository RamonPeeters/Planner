using Planner.LogicInterfaces.Appointments;
using Planner.Presentation.Models.Appointments;
using System.Collections.Generic;

namespace Planner.Presentation.Mappers {
    static class AppointmentViewModelMapper {
        public static AppointmentViewModel ToAppointmentViewModel(Appointment appointment) {
            return new AppointmentViewModel(appointment.Id, appointment.Title, appointment.Description, appointment.StartDate, appointment.EndDate, appointment.Finished);
        }

        public static EditAppointmentViewModel ToEditAppointmentViewModel(Appointment appointment) {
            return new EditAppointmentViewModel(appointment.Id, appointment.Title, appointment.Description, appointment.StartDate, appointment.EndDate, appointment.Finished);
        }

        public static IEnumerable<AppointmentViewModel> ToAppointmentViewModels(IAppointmentCollection appointments) {
            foreach (Appointment appointment in appointments) {
                yield return ToAppointmentViewModel(appointment);
            }
        }

        public static Appointment ToAppointment(AppointmentViewModel appointmentViewModel) {
            return new Appointment(appointmentViewModel.Id, appointmentViewModel.Title, appointmentViewModel.Description, appointmentViewModel.StartDate, appointmentViewModel.EndDate, appointmentViewModel.Finished);
        }

        public static Appointment ToAppointment(NewAppointmentViewModel newAppointmentViewModel) {
            return new Appointment(-1, newAppointmentViewModel.Title, newAppointmentViewModel.Description, newAppointmentViewModel.StartDate, newAppointmentViewModel.EndDate, false);
        }

        public static Appointment ToAppointment(EditAppointmentViewModel editAppointmentViewModel) {
            return new Appointment(editAppointmentViewModel.Id, editAppointmentViewModel.Title, editAppointmentViewModel.Description, editAppointmentViewModel.StartDate, editAppointmentViewModel.EndDate, editAppointmentViewModel.Finished);
        }
    }
}
