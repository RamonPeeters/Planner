namespace Planner.Presentation.Models {
    public class PriorityViewModel {
        public string Name { get; }
        public int Colour { get; }

        public PriorityViewModel(string name, int colour) {
            Name = name;
            Colour = colour;
        }
    }
}
