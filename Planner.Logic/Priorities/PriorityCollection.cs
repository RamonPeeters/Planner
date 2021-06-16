using Planner.DalInterfaces.Priorities;
using Planner.LogicInterfaces.Priorities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Planner.Logic.Priorities {
    public class PriorityCollection : IPriorityCollection, IPriorityReadOnlyCollection {
        private const string PriorityNameNotFound = "A priority with the name '{0}' was not found.";
        private const string PriorityNameAlreadyExists = "A priority with the name '{0}' already exists.";

        private readonly IPriorityDao PriorityDao;
        private readonly List<Priority> Priorities;

        public PriorityCollection(IPriorityDao priorityDao) {
            PriorityDao = priorityDao;

            List<PriorityDto> priorityDtos = PriorityDao.GetPriorities();
            Priorities = new List<Priority>(PriorityMapper.ToPriorities(priorityDtos));
        }

        public Priority this[string name] {
            get {
                if (name == null) {
                    throw new ArgumentNullException(nameof(name));
                }
                int index = Priorities.FindIndex(item => item.Name == name);
                if (index == -1) {
                    throw new ArgumentException(string.Format(PriorityNameNotFound, name));
                }
                return Priorities[index];
            }
            set {
                if (name == null) {
                    throw new ArgumentNullException(nameof(name));
                }
                if (value == null) {
                    throw new ArgumentNullException(nameof(value));
                }
                int index = Priorities.FindIndex(item => item.Name == name);
                if (index == -1) {
                    throw new ArgumentException(string.Format(PriorityNameNotFound, name));
                }
                int existingIndex = Priorities.IndexOf(value);
                if (existingIndex != index && existingIndex != -1) {
                    throw new ArgumentException(string.Format(PriorityNameAlreadyExists, value.Name));
                }
                PriorityDao.UpdatePriority(name, PriorityMapper.ToPriorityDto(value));
                Priorities[index] = value;
            }
        }

        public void Add(Priority priority) {
            if (Priorities.Contains(priority)) {
                throw new ArgumentException(string.Format(PriorityNameAlreadyExists, priority.Name));
            }
            PriorityDao.CreatePriority(PriorityMapper.ToPriorityDto(priority));
            Priorities.Add(priority);
        }

        public bool RemoveByName(string name) {
            int rows = PriorityDao.DeletePriority(name);
            if (rows > 0) {
                return Priorities.RemoveAll(p => p.Name == name) > 0;
            }
            return false;
        }

        public int Count { get { return Priorities.Count; } }

        public IEnumerator<Priority> GetEnumerator() {
            foreach (Priority priority in Priorities) {
                yield return priority;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
