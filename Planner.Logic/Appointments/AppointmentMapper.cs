﻿using Planner.DalInterfaces.Appointments;
using Planner.Logic.Priorities;
using System.Collections.Generic;

namespace Planner.Logic.Appointments {
    static class AppointmentMapper {
        public static Appointment ToAppointment(AppointmentDto appointmentDto) {
            if (appointmentDto == null) {
                return null;
            }
            return new Appointment(appointmentDto.Id, appointmentDto.Title, appointmentDto.Description, appointmentDto.StartDate, appointmentDto.EndDate, appointmentDto.Finished, PriorityMapper.ToPriority(appointmentDto.Priority));
        }

        public static IEnumerable<Appointment> ToAppointments(IEnumerable<AppointmentDto> appointmentDtos) {
            if (appointmentDtos == null) {
                yield break;
            }
            foreach (AppointmentDto appointmentDto in appointmentDtos) {
                yield return ToAppointment(appointmentDto);
            }
        }

        public static AppointmentDto ToAppointmentDto(Appointment appointment) {
            if (appointment == null) {
                return null;
            }
            return new AppointmentDto(appointment.Id, appointment.Title, appointment.Description, appointment.StartDate, appointment.EndDate, appointment.Finished, PriorityMapper.ToPriorityDto(appointment.Priority));
        }
    }
}
