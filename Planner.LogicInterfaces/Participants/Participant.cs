using System;

namespace Planner.LogicInterfaces.Participants {
    public class Participant : IEquatable<Participant> {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }

        public Participant(int id, string firstName, string lastName, string email) {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public Participant(string firstName, string lastName, string email) : this(-1, firstName, lastName, email) {}

        public bool Equals(Participant other) {
            if (other == null) {
                return false;
            }
            return other.Email == Email;
        }

        public override bool Equals(object obj) {
            return Equals(obj as Participant);
        }

        public override int GetHashCode() {
            return HashCode.Combine(Email);
        }
    }
}
