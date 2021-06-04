using System.Collections.Generic;

namespace Planner.LogicInterfaces.Appointments {
    public interface IAppointmentCollection : IEnumerable<Appointment> {
        Appointment this[int id] { get; set; }
        void Add(Appointment appointment);
        bool RemoveById(int id);
    }
}
