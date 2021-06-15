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

        public IActionResult Appointment(int? id = null) {
            if (!id.HasValue) {
                return RedirectToAction(nameof(Index));
            }
            Appointment appointment = Appointments[id.Value];
            AppointmentViewModel appointmentViewModel = AppointmentViewModelMapper.ToAppointmentViewModel(appointment);
            return View(appointmentViewModel);
        }

        public IActionResult New() {
            return View();
        }

        [HttpPost]
        public IActionResult New(AppointmentViewModel appointmentViewModel) {
            if (!ModelState.IsValid) {
                return View(appointmentViewModel);
            }
            Appointments.Add(AppointmentViewModelMapper.ToAppointment(appointmentViewModel));
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id = null) {
            if (!id.HasValue) {
                return RedirectToAction(nameof(Index));
            }
            Appointment appointment = Appointments[id.Value];
            AppointmentViewModel appointmentViewModel = AppointmentViewModelMapper.ToAppointmentViewModel(appointment);
            return View(appointmentViewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, AppointmentViewModel appointmentViewModel) {
            if (!ModelState.IsValid) {
                return View(appointmentViewModel);
            }
            Appointments[id] = AppointmentViewModelMapper.ToAppointment(appointmentViewModel);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id = null) {
            if (id.HasValue) {
                Appointments.RemoveById(id.Value);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
