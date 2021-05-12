namespace Planner.DalInterfaces.Participants {
    public class ParticipantDto {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }

        public ParticipantDto() {}

        public ParticipantDto(int id, string firstName, string lastName, string email) {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
