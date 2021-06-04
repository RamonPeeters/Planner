using System;

namespace Planner.Presentation.Models {
    public class AppointmentViewModel {
        public int Id { get; }
        public string Title { get; }
        public string Description { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public bool Finished { get; private set; }

        public AppointmentViewModel(int id, string title, string description, DateTime startDate, DateTime endDate, bool finished) {
            Id = id;
            Title = title;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Finished = finished;
        }
    }
}
