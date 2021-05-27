namespace Planner.LogicInterfaces.Priorities {
    public interface IPriorityCollection {
        Priority this[string name] { get; set; }
        void Add(Priority priority);
        bool RemoveByName(string name);
    }
}
