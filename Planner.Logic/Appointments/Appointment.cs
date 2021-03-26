using System;

namespace Planner.Logic.Appointments {
    public class Appointment {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Finished { get; set; }
    }
}
