using Planner.DalInterfaces.Participants;
using Planner.LogicInterfaces.Participants;
using System.Collections.Generic;

namespace Planner.Logic.Participants {
    static class ParticipantMapper {
        public static Participant ToParticipant(ParticipantDto participantDto) {
            if (participantDto == null) {
                return null;
            }
            return new Participant(participantDto.FirstName, participantDto.LastName, participantDto.Email);
        }

        public static IEnumerable<Participant> ToParticipants(IEnumerable<ParticipantDto> participantDtos) {
            if (participantDtos == null) {
                yield break;
            }
            foreach (ParticipantDto participantDto in participantDtos) {
                yield return ToParticipant(participantDto);
            }
        }

        public static ParticipantDto ToParticipantDto(Participant participant) {
            if (participant == null) {
                return null;
            }
            return new ParticipantDto(-1, participant.FirstName, participant.LastName, participant.Email);
        }

        public static IEnumerable<ParticipantDto> ToParticipantDtos(IParticipantReadOnlyCollection participants) {
            if (participants == null) {
                yield break;
            }
            foreach (Participant participantDto in participants) {
                yield return ToParticipantDto(participantDto);
            }
        }
    }
}
