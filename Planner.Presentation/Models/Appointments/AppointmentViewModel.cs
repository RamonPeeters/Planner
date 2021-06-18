using System;
using System.ComponentModel.DataAnnotations;

namespace Planner.Presentation.Models.Appointments {
    public class AppointmentViewModel {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:ddd d MMMM yyy (H:mm:ss)}")]
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:ddd d MMMM yyy (H:mm:ss)}")]
        public DateTime EndDate { get; set; }
        public bool Finished { get; private set; }

        public AppointmentViewModel() : this(-1, "", null, default, default, false) { }

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
