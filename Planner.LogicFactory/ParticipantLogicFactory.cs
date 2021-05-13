using Planner.DalFactory;
using Planner.Logic.Participants;

namespace Planner.LogicFactory {
    public static class ParticipantLogicFactory {
        public static ParticipantCollection GetParticipantCollection(string connectionString) {
            return new ParticipantCollection(ParticipantDalFactory.GetParticipantDao(connectionString));
        }
    }
}
