using Planner.Dal.Priorities;
using Planner.DalInterfaces.Priorities;

namespace Planner.DalFactory {
    public static class PriorityDalFactory {
        public static IPriorityDao GetPriorityDao(string connectionString) {
            return new PriorityDao(connectionString);
        }
    }
}
