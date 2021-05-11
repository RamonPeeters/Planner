using Planner.DalFactory;
using Planner.Logic.Priorities;

namespace Planner.LogicFactory {
    public static class PriorityLogicFactory {
        public static PriorityCollection GetPriorityCollection(string connectionString) {
            return new PriorityCollection(PriorityDalFactory.GetPriorityDao(connectionString));
        }
    }
}
