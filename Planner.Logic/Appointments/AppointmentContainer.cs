using Planner.LogicInterfaces;
using Planner.LogicInterfaces.Appointments;
using System;
using System.Collections.Generic;

namespace Planner.Logic.Appointments {
    public class AppointmentContainer : IAppointmentContainer {
        public List<IAppointment> GetAppointments(DateTime date, DateType dateType) {
            DateTime start = date.GetStart(dateType);
            DateTime end = date.GetEnd(dateType);
            throw new NotImplementedException();
        }

        public IAppointment GetAppointmentById(int id) {
            throw new NotImplementedException();
        }

        public bool CreateAppointment(IAppointment appointment) {
            throw new NotImplementedException();
        }
    }
}
