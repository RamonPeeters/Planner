using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Planner.LogicFactory;
using Planner.LogicInterfaces.Appointments;
using Planner.Presentation.Mappers;
using Planner.Presentation.Models;
using System.Collections.Generic;

namespace Planner.Presentation.Controllers {
    public class AppointmentsController : Controller {
        private readonly IConfiguration Configuration;
        private readonly IAppointmentCollection Appointments;

        public AppointmentsController(IConfiguration configuration) {
            Configuration = configuration;
            Appointments = AppointmentLogicFactory.GetAppointmentCollection(Configuration.GetConnectionString("defaultPlannerDatabase"));
        }

        public IActionResult Index() {
            IEnumerable<AppointmentViewModel> appointmentViewModels = AppointmentViewModelMapper.ToAppointmentViewModels(Appointments);
            return View(appointmentViewModels);
        }
    }
}
