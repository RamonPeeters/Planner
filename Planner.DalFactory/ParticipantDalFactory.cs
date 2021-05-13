using Planner.Dal.Participants;
using Planner.DalInterfaces.Participants;

namespace Planner.DalFactory {
    public static class ParticipantDalFactory {
        public static IParticipantDao GetParticipantDao(string connectionString) {
            return new ParticipantDao(connectionString);
        }
    }
}
