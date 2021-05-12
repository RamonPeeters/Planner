using System.Collections.Generic;

namespace Planner.DalInterfaces.Participants {
    public interface IParticipantDao {
        List<ParticipantDto> GetParticipants();
        int CreateParticipant(ParticipantDto participantDto);
        int UpdateParticipant(string email, ParticipantDto participantDto);
        int DeleteParticipant(string email);
    }
}
