using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Planner.LogicFactory;
using Planner.LogicInterfaces.Priorities;
using Planner.Presentation.Mappers;
using Planner.Presentation.Models;
using System.Collections.Generic;

namespace Planner.Presentation.Controllers {
    public class PrioritiesController : Controller {
        private readonly IConfiguration Configuration;
        private readonly IPriorityCollection Priorities;

        public PrioritiesController(IConfiguration configuration) {
            Configuration = configuration;
            Priorities = PriorityLogicFactory.GetPriorityCollection(Configuration.GetConnectionString("defaultPlannerDatabase"));
        }

        public IActionResult Index() {
            IEnumerable<PriorityViewModel> priorityViewModels = PriorityViewModelMapper.ToPriorityViewModels(Priorities);
            return View(priorityViewModels);
        }
    }
}
