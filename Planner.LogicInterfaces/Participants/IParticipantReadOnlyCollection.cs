using System.Collections.Generic;

namespace Planner.LogicInterfaces.Participants {
    public interface IParticipantReadOnlyCollection : IEnumerable<Participant> {
        Participant this[string email] { get; }
    }
}
