using System.ComponentModel.DataAnnotations;

namespace Planner.Presentation.Models {
    public class ParticipantViewModel {
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

        public ParticipantViewModel() : this("", "", "") {}

        public ParticipantViewModel(string firstName, string lastName, string email) {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
