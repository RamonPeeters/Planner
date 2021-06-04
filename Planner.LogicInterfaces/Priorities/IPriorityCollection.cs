using System.Collections.Generic;

namespace Planner.LogicInterfaces.Priorities {
    public interface IPriorityCollection : IEnumerable<Priority> {
        Priority this[string name] { get; set; }
        void Add(Priority priority);
        bool RemoveByName(string name);
    }
}
