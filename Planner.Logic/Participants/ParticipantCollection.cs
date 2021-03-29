using System.Collections.Generic;

namespace Planner.Logic.Participants {
    public class ParticipantCollection {
        private readonly List<Participant> Participants;

        public ParticipantCollection() {
            Participants = new List<Participant>();
        }

        public Participant this[int index] { get { return Participants[index]; } set { Participants[index] = value; } }

        public void Add(Participant participant) {
            Participants.Add(participant);
        }

        public bool Remove(Participant participant) {
            return Participants.Remove(participant);
        }

        public int Count { get { return Participants.Count; } }
    }
}
