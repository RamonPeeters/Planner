using Planner.LogicInterfaces.Participants;
using Planner.Presentation.Models;
using System.Collections.Generic;

namespace Planner.Presentation.Mappers {
    class ParticipantViewModelMapper {
        public static ParticipantViewModel ToParticipantViewModel(Participant participant) {
            return new ParticipantViewModel(participant.Id, participant.FirstName, participant.LastName, participant.Email);
        }

        public static IEnumerable<ParticipantViewModel> ToParticipantViewModels(IParticipantCollection participants) {
            foreach (Participant participant in participants) {
                yield return ToParticipantViewModel(participant);
            }
        }

        public static Participant ToParticipant(ParticipantViewModel participantViewModel) {
            return new Participant(participantViewModel.Id, participantViewModel.FirstName, participantViewModel.LastName, participantViewModel.Email);
        }
    }
}
