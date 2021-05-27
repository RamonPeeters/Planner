namespace Planner.LogicInterfaces.Priorities {
    public interface IPriorityReadOnlyCollection {
        Priority this[string name] { get; }
    }
}
