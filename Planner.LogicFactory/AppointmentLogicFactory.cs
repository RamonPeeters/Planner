using Planner.DalFactory;
using Planner.Logic.Appointments;

namespace Planner.LogicFactory {
    public static class AppointmentLogicFactory {
        public static AppointmentCollection GetAppointmentCollection(string connectionString) {
            return new AppointmentCollection(AppointmentDalFactory.GetAppointmentDao(connectionString));
        }
    }
}
