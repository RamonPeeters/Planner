using Planner.DalInterfaces.Participants;
using System.Collections.Generic;

namespace Planner.Tests.TestDal.Participants {
    public class ParticipantTestDao : IParticipantDao {
        private int IdAutoIncrement = 1;
        private readonly List<ParticipantDto> Participants = new List<ParticipantDto>();

        public List<ParticipantDto> GetParticipants() {
            return new List<ParticipantDto>(Participants);
        }

        public int CreateParticipant(ParticipantDto participantDto) {
            ParticipantDto actualParticipantDto = new ParticipantDto(IdAutoIncrement++, participantDto.FirstName, participantDto.LastName, participantDto.Email);
            Participants.Add(actualParticipantDto);
            return 1;
        }

        public int UpdateParticipant(string email, ParticipantDto participantDto) {
            int index = Participants.FindIndex(p => p.Email == email);
            if (index == -1) return 0;
            Participants[index] = participantDto;
            return 1;
        }

        public int DeleteParticipant(string email) {
            return Participants.RemoveAll(p => p.Email == email);
        }
    }
}
