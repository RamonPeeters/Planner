using System.ComponentModel.DataAnnotations;

namespace Planner.Presentation.Models {
    public class PriorityViewModel {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Range(0, 10)]
        public int Colour { get; set; }

        public PriorityViewModel() : this("", 0) {}

        public PriorityViewModel(string name, int colour) {
            Name = name;
            Colour = colour;
        }
    }
}
