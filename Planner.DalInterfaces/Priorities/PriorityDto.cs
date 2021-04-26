namespace Planner.DalInterfaces.Priorities {
    public class PriorityDto {
        public int Id { get; }
        public string Name { get; }
        public int Colour { get; }

        public PriorityDto() {}

        public PriorityDto(int id, string name, int colour) {
            Id = id;
            Name = name;
            Colour = colour;
        }
    }
}
