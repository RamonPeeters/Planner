using Planner.DalInterfaces.Participants;
using System.Collections.Generic;

namespace Planner.Logic.Participants {
    static class ParticipantMapper {
        public static Participant ToParticipant(ParticipantDto participantDto) {
            return new Participant(participantDto.FirstName, participantDto.LastName, participantDto.Email);
        }

        public static IEnumerable<Participant> ToParticipants(IEnumerable<ParticipantDto> participantDtos) {
            foreach (ParticipantDto participantDto in participantDtos) {
                yield return ToParticipant(participantDto);
            }
        }

        public static ParticipantDto ToParticipantDto(Participant participant) {
            return new ParticipantDto(-1, participant.FirstName, participant.LastName, participant.Email);
        }
    }
}
