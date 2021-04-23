using Planner.Dal.Appointments;
using Planner.DalInterfaces.Appointments;

namespace Planner.DalFactory {
    public static class AppointmentDalFactory {
        public static IAppointmentDao GetAppointmentDao(string connectionString) {
            return new AppointmentDao(connectionString);
        }
    }
}
