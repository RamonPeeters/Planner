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

        public IActionResult Priority(string name = null) {
            if (name == null) {
                return RedirectToAction(nameof(Index));
            }
            Priority priority = Priorities[name];
            PriorityViewModel priorityViewModel = PriorityViewModelMapper.ToPriorityViewModel(priority);
            return View(priorityViewModel);
        }

        public IActionResult New() {
            return View();
        }

        [HttpPost]
        public IActionResult New(PriorityViewModel priorityViewModel) {
            if (!ModelState.IsValid) {
                return View(priorityViewModel);
            }
            Priorities.Add(PriorityViewModelMapper.ToPriority(priorityViewModel));
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(string name = null) {
            if (name == null) {
                return RedirectToAction(nameof(Index));
            }
            Priority priority = Priorities[name];
            PriorityViewModel priorityViewModel = PriorityViewModelMapper.ToPriorityViewModel(priority);
            return View(priorityViewModel);
        }

        [HttpPost]
        public IActionResult Edit([FromQuery] string name, PriorityViewModel priorityViewModel) {
            if (!ModelState.IsValid) {
                return View(priorityViewModel);
            }
            Priorities[name] = PriorityViewModelMapper.ToPriority(priorityViewModel);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(string name = null) {
            if (name != null) {
                Priorities.RemoveByName(name);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
