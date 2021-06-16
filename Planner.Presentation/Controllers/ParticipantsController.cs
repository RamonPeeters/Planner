using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Planner.LogicFactory;
using Planner.LogicInterfaces.Participants;
using Planner.Presentation.Mappers;
using Planner.Presentation.Models;
using System.Collections.Generic;

namespace Planner.Presentation.Controllers {
    public class ParticipantsController : Controller {
        private readonly IConfiguration Configuration;
        private readonly IParticipantCollection Participants;

        public ParticipantsController(IConfiguration configuration) {
            Configuration = configuration;
            Participants = ParticipantLogicFactory.GetParticipantCollection(Configuration.GetConnectionString("defaultPlannerDatabase"));
        }

        public IActionResult Index() {
            IEnumerable<ParticipantViewModel> participantViewModels = ParticipantViewModelMapper.ToParticipantViewModels(Participants);
            return View(participantViewModels);
        }

        public IActionResult Participant(string email = null) {
            if (email == null) {
                return RedirectToAction(nameof(Index));
            }
            Participant participant = Participants[email];
            ParticipantViewModel participantViewModel = ParticipantViewModelMapper.ToParticipantViewModel(participant);
            return View(participantViewModel);
        }

        public IActionResult New() {
            return View();
        }

        [HttpPost]
        public IActionResult New(ParticipantViewModel participantViewModel) {
            if (!ModelState.IsValid) {
                return View(participantViewModel);
            }
            Participants.Add(ParticipantViewModelMapper.ToParticipant(participantViewModel));
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(string email = null) {
            if (email == null) {
                return RedirectToAction(nameof(Index));
            }
            Participant participant = Participants[email];
            ParticipantViewModel participantViewModel = ParticipantViewModelMapper.ToParticipantViewModel(participant);
            return View(participantViewModel);
        }

        [HttpPost]
        public IActionResult Edit([FromQuery] string email, ParticipantViewModel participantViewModel) {
            if (!ModelState.IsValid) {
                return View(participantViewModel);
            }
            Participants[email] = ParticipantViewModelMapper.ToParticipant(participantViewModel);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(string email = null) {
            if (email != null) {
                Participants.RemoveByEmail(email);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
