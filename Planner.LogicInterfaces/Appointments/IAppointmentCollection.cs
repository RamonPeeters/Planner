namespace Planner.LogicInterfaces.Appointments {
    public interface IAppointmentCollection {
        Appointment this[int id] { get; set; }
        void Add(Appointment appointment);
        bool RemoveById(int id);
    }
}
