using System;

namespace Planner.LogicInterfaces.Priorities {
    public class Priority : IEquatable<Priority> {
        public string Name { get; }
        public int Colour { get; }

        public Priority(string name, int colour) {
            Name = name;
            Colour = colour;
        }

        public bool Equals(Priority other) {
            if (other == null) {
                return false;
            }
            return other.Name == Name;
        }

        public override bool Equals(object obj) {
            return Equals(obj as Priority);
        }

        public override int GetHashCode() {
            return HashCode.Combine(Name);
        }
    }
}
