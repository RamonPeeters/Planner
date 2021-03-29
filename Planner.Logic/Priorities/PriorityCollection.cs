using System.Collections.Generic;

namespace Planner.Logic.Priorities {
    public class PriorityCollection {
        private readonly List<Priority> Priorities;

        public PriorityCollection() {
            Priorities = new List<Priority>();
        }

        public Priority this[int index] { get { return Priorities[index]; } set { Priorities[index] = value; } }

        public void Add(Priority priority) {
            Priorities.Add(priority);
        }

        public bool Remove(Priority priority) {
            return Priorities.Remove(priority);
        }

        public int Count { get { return Priorities.Count; } }
    }
}
