using Planner.DalInterfaces.Participants;
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
                return null;
            }
            return ToParticipantsInternal(participantDtos);
        }

        private static IEnumerable<Participant> ToParticipantsInternal(IEnumerable<ParticipantDto> participantDtos) {
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

        public static IEnumerable<ParticipantDto> ToParticipantDtos(IEnumerable<Participant> participants) {
            if (participants == null) {
                return null;
            }
            return ToParticipantDtosInternal(participants);
        }

        private static IEnumerable<ParticipantDto> ToParticipantDtosInternal(IEnumerable<Participant> participants) {
            foreach (Participant participantDto in participants) {
                yield return ToParticipantDto(participantDto);
            }
        }
    }
}
