using System;

namespace Planner.LogicInterfaces.Appointments {
    public interface IAppointment {
        int Id { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        bool Finished { get; set; }

        bool UpdateAppointment();
        bool DeleteAppointment();
    }
}
