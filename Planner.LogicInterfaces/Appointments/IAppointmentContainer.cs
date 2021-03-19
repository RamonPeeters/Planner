using System;
using System.Collections.Generic;

namespace Planner.LogicInterfaces.Appointments {
    public interface IAppointmentContainer {
        List<IAppointment> GetAppointments(DateTime date, DateType dateType);
        IAppointment GetAppointmentById(int id);
        bool CreateAppointment(IAppointment appointment);
    }
}
