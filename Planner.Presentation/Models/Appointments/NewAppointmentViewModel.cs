﻿using Planner.Presentation.Attributes;
using System;

namespace Planner.Presentation.Models.Appointments {
    public class NewAppointmentViewModel {
        public string Title { get; set; }
        public string Description { get; set; }

        [DatePassed(ErrorMessage = "Select a date that hasn't passed yet.")]
        public DateTime StartDate { get; set; }

        [DateAfter(nameof(StartDate), ErrorMessage = "The end date must be later than the start date.")]
        public DateTime EndDate { get; set; }
    }
}
