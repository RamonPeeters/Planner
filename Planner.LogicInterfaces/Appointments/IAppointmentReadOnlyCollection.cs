namespace Planner.LogicInterfaces.Appointments {
    public interface IAppointmentReadOnlyCollection {
        Appointment this[int id] { get; }
    }
}
