using Planner.LogicInterfaces.Priorities;
using Planner.Presentation.Models;
using System.Collections.Generic;

namespace Planner.Presentation.Mappers {
    static class PriorityViewModelMapper {
        public static PriorityViewModel ToPriorityViewModel(Priority priority) {
            return new PriorityViewModel(priority.Name, priority.Colour);
        }

        public static IEnumerable<PriorityViewModel> ToPriorityViewModels(IPriorityCollection priorities) {
            foreach (Priority priority in priorities) {
                yield return ToPriorityViewModel(priority);
            }
        }

        public static Priority ToPriority(PriorityViewModel priorityViewModel) {
            return new Priority(priorityViewModel.Name, priorityViewModel.Colour);
        }
    }
}
