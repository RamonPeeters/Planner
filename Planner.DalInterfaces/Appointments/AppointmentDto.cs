using Planner.DalInterfaces.Priorities;
using System;

namespace Planner.DalInterfaces.Appointments {
    public class AppointmentDto {
        public int Id { get; }
        public string Title { get; }
        public string Description { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public bool Finished { get; }
        public PriorityDto Priority { get; }

        public AppointmentDto() {}

        public AppointmentDto(int id, string title, string description, DateTime startDate, DateTime endDate, bool finished, PriorityDto priority) {
            Id = id;
            Title = title;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Finished = finished;
            Priority = priority;
        }
    }
}
