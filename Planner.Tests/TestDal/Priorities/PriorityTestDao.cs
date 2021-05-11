using Planner.DalInterfaces.Priorities;
using System.Collections.Generic;

namespace Planner.Tests.TestDal.Priorities {
    public class PriorityTestDao : IPriorityDao {
        private int IdAutoIncrement = 1;
        private readonly List<PriorityDto> Priorities = new List<PriorityDto>();

        public List<PriorityDto> GetPriorities() {
            return new List<PriorityDto>(Priorities);
        }

        public int CreatePriority(PriorityDto priorityDto) {
            PriorityDto actualPriorityDto = new PriorityDto(IdAutoIncrement++, priorityDto.Name, priorityDto.Colour);
            Priorities.Add(actualPriorityDto);
            return 1;
        }

        public int UpdatePriority(string priorityName, PriorityDto priorityDto) {
            int index = Priorities.FindIndex(p => p.Name == priorityName);
            if (index == -1) return 0;
            Priorities[index] = priorityDto;
            return 1;
        }

        public int DeletePriority(string priorityName) {
            return Priorities.RemoveAll(p => p.Name == priorityName);
        }
    }
}
