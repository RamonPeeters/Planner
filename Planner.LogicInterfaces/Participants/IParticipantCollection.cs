namespace Planner.LogicInterfaces.Participants {
    public interface IParticipantCollection {
        Participant this[string email] { get; set; }
        void Add(Participant participant);
        bool RemoveByEmail(string email);
    }
}
