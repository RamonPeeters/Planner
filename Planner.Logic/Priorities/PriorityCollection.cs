using System.Collections.Generic;

namespace Planner.Logic.Priorities {
    public class PriorityCollection {
        private readonly List<Priority> Priorities;

        public PriorityCollection() {
            Priorities = new List<Priority>();
        }

        public Priority this[int index] { get { return Priorities[index]; } set { Priorities[index] = value; } }

        public void Add(Priority appointment) {
            Priorities.Add(appointment);
        }

        public bool Remove(Priority appointment) {
            return Priorities.Remove(appointment);
        }

        public int Count { get { return Priorities.Count; } }
    }
}
