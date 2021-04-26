using System.Collections.Generic;

namespace Planner.DalInterfaces.Priorities {
    public interface IPriorityDao {
        List<PriorityDto> GetPriorities();
        int CreatePriority(PriorityDto priorityDto);
        int UpdatePriority(string priorityName, PriorityDto priorityDto);
        int DeletePriority(string priorityName);
    }
}
