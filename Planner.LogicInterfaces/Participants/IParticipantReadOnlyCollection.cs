namespace Planner.LogicInterfaces.Participants {
    public interface IParticipantReadOnlyCollection {
        Participant this[string email] { get; }
    }
}
