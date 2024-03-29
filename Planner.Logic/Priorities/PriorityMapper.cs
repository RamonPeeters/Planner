﻿using Planner.DalInterfaces.Priorities;
using Planner.LogicInterfaces.Priorities;
using System.Collections.Generic;

namespace Planner.Logic.Priorities {
    static class PriorityMapper {
        public static Priority ToPriority(PriorityDto priorityDto) {
            if (priorityDto == null) {
                return null;
            }
            return new Priority(priorityDto.Id, priorityDto.Name, priorityDto.Colour);
        }

        public static IEnumerable<Priority> ToPriorities(IEnumerable<PriorityDto> priorityDtos) {
            if (priorityDtos == null) {
                yield break;
            }
            foreach (PriorityDto priorityDto in priorityDtos) {
                yield return ToPriority(priorityDto);
            }
        }

        public static PriorityDto ToPriorityDto(Priority priority) {
            if (priority == null) {
                return null;
            }
            return new PriorityDto(priority.Id, priority.Name, priority.Colour);
        }
    }
}
