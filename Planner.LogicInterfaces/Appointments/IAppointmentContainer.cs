using System;
using System.Collections.Generic;

namespace Planner.LogicInterfaces.Appointments {
    public interface IAppointmentContainer {
        List<IAppointment> GetAppointments(DateTime from, DateTime until);
        IAppointment GetAppointmentById(int id);
        bool CreateAppointment(IAppointment appointment);
    }
}
