using System;

namespace Planner.DalInterfaces.Appointments {
    public class AppointmentDto {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Finished { get; set; }
    }
}
