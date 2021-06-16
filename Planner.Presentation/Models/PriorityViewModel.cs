using System.ComponentModel.DataAnnotations;

namespace Planner.Presentation.Models {
    public class PriorityViewModel {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Range(0, 10)]
        public int Colour { get; set; }

        public PriorityViewModel() : this(-1, "", 0) {}

        public PriorityViewModel(int id, string name, int colour) {
            Id = id;
            Name = name;
            Colour = colour;
        }
    }
}
