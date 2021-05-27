using System.Collections.Generic;

namespace Planner.LogicInterfaces.Participants {
    public interface IParticipantCollection : IEnumerable<Participant> {
        Participant this[string email] { get; set; }
        void Add(Participant participant);
        bool RemoveByEmail(string email);
    }
}
