using System.Collections.Generic;

namespace Planner.LogicInterfaces.Priorities {
    public interface IPriorityReadOnlyCollection : IEnumerable<Priority> {
        Priority this[string name] { get; }
    }
}
