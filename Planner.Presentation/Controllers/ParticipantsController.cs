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
    }
}
