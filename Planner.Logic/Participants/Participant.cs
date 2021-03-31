namespace Planner.Logic.Participants {
    public class Participant {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }

        public Participant(string firstName, string lastName, string email) {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
