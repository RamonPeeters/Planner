using Planner.DalInterfaces.Priorities;
using System.Collections.Generic;

namespace Planner.Logic.Priorities {
    static class PriorityMapper {
        public static Priority ToPriority(PriorityDto priorityDto) {
            return new Priority(priorityDto.Name, priorityDto.Colour);
        }

        public static IEnumerable<Priority> ToPriorities(IEnumerable<PriorityDto> priorityDtos) {
            foreach (PriorityDto priorityDto in priorityDtos) {
                yield return ToPriority(priorityDto);
            }
        }

        public static PriorityDto ToPriorityDto(Priority priority) {
            return new PriorityDto(-1, priority.Name, priority.Colour);
        }
    }
}
