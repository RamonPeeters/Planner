using Planner.DalInterfaces.Participants;
using Planner.LogicInterfaces.Participants;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Planner.Logic.Participants {
    public class ParticipantCollection : IParticipantCollection, IParticipantReadOnlyCollection {
        private const string ParticipantEmailNotFound = "A participant with the e-mail '{0}' was not found.";
        private const string ParticipantEmailAlreadyExists = "A participant with the e-mail '{0}' already exists.";

        private readonly IParticipantDao ParticipantDao;
        private readonly List<Participant> Participants;

        private ParticipantCollection(IEnumerable<Participant> participants) {
            Participants = new List<Participant>(participants);
        }

        public ParticipantCollection(IParticipantDao participantDao) {
            ParticipantDao = participantDao;

            List<ParticipantDto> participantDtos = ParticipantDao.GetParticipants();
            Participants = new List<Participant>(ParticipantMapper.ToParticipants(participantDtos));
        }

        public Participant this[string email] {
            get {
                if (email == null) {
                    throw new ArgumentNullException(nameof(email));
                }
                int index = Participants.FindIndex(item => item.Email == email);
                if (index == -1) {
                    throw new ArgumentException(string.Format(ParticipantEmailNotFound, email));
                }
                return Participants[index];
            } set {
                if (email == null) {
                    throw new ArgumentNullException(nameof(email));
                }
                if (value == null) {
                    throw new ArgumentNullException(nameof(value));
                }
                int index = Participants.FindIndex(item => item.Email == email);
                if (index == -1) {
                    throw new ArgumentException(string.Format(ParticipantEmailNotFound, email));
                }
                if (Participants.Contains(value)) {
                    throw new ArgumentException(string.Format(ParticipantEmailAlreadyExists, value.Email));
                }
                ParticipantDao.UpdateParticipant(email, ParticipantMapper.ToParticipantDto(value));
                Participants[index] = value;
            }
        }

        public void Add(Participant participant) {
            if (Participants.Contains(participant)) {
                throw new ArgumentException(string.Format(ParticipantEmailAlreadyExists, participant.Email));
            }
            ParticipantDao.CreateParticipant(ParticipantMapper.ToParticipantDto(participant));
            Participants.Add(participant);
        }

        public bool RemoveByEmail(string email) {
            int rows = ParticipantDao.DeleteParticipant(email);
            if (rows > 0) {
                return Participants.RemoveAll(p => p.Email == email) > 0;
            }
            return false;
        }

        public IEnumerator<Participant> GetEnumerator() {
            foreach (Participant p in Participants) {
                yield return p;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public int Count { get { return Participants.Count; } }

        public static IParticipantReadOnlyCollection CreateReadOnlyCollection(IEnumerable<Participant> participants) {
            return new ParticipantCollection(participants);
        }
    }
}
