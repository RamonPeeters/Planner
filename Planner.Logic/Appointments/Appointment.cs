using System;

namespace Planner.Logic.Appointments {
    public class Appointment {
        public string Title { get; }
        public string Description { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public bool Finished { get; private set; }

        public Appointment(string title, DateTime startDate, DateTime endDate) : this(title, null, startDate, endDate) { }

        public Appointment(string title, string description, DateTime startDate, DateTime endDate) {
            Title = title;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Finished = false;
        }

        public void FinishAppointment() {
            Finished = true;
        }
    }
}
