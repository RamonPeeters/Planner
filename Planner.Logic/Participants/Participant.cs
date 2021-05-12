using System;

namespace Planner.Logic.Participants {
    public class Participant : IEquatable<Participant> {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }

        public Participant(string firstName, string lastName, string email) {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

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
