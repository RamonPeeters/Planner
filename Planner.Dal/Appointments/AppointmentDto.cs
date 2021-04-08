using Planner.DalInterfaces.Appointments;
using System;

namespace Planner.Dal.Appointments {
    public class AppointmentDto : IAppointmentDto {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Finished { get; set; }
    }
}
