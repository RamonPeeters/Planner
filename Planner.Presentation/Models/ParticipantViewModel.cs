using System.ComponentModel.DataAnnotations;

namespace Planner.Presentation.Models {
    public class ParticipantViewModel {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }

        public ParticipantViewModel() : this(-1, "", "", "") {}

        public ParticipantViewModel(int id, string firstName, string lastName, string email) {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
