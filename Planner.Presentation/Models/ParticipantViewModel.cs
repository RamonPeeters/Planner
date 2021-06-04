namespace Planner.Presentation.Models {
    public class ParticipantViewModel {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }

        public ParticipantViewModel(string firstName, string lastName, string email) {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
