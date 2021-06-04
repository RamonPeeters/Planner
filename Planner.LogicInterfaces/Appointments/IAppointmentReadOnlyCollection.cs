using System.Collections.Generic;

namespace Planner.LogicInterfaces.Appointments {
    public interface IAppointmentReadOnlyCollection : IEnumerable<Appointment> {
        Appointment this[int id] { get; }
    }
}
