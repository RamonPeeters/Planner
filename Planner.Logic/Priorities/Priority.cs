using System.Drawing;

namespace Planner.Logic.Priorities {
    public class Priority {
        public string Name { get; }
        public Color Colour { get; }

        public Priority(string name, Color colour) {
            Name = name;
            Colour = colour;
        }
    }
}
