using Planner.DalInterfaces.Priorities;
using System;
using System.Collections.Generic;

namespace Planner.Logic.Priorities {
    public class PriorityCollection {
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
                    throw new ArgumentException($"A priority with the name '{name}' was not found.");
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
                    throw new ArgumentException($"A priority with the name '{name}' was not found.");
                }
                if (Priorities.Contains(value)) {
                    throw new ArgumentException($"A priority with the name '{value.Name}' already exists.");
                }
                PriorityDao.UpdatePriority(name, PriorityMapper.ToPriorityDto(value));
                Priorities.Add(value);
            }
        }

        public void Add(Priority priority) {
            if (Priorities.Contains(priority)) {
                throw new ArgumentException($"A priority with the name '{priority.Name}' already exists.");
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
    }
}
