﻿using Planner.LogicInterfaces.Participants;
using Planner.LogicInterfaces.Priorities;
using System;
using System.Collections.Generic;

namespace Planner.LogicInterfaces.Appointments {
    public class Appointment {
        public int Id { get; }
        public string Title { get; }
        public string Description { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public bool Finished { get; private set; }
        public Priority Priority { get; }
        public IParticipantReadOnlyCollection Participants { get; }

        public Appointment(int id, string title, string description, DateTime startDate, DateTime endDate, bool finished, Priority priority, IParticipantReadOnlyCollection participants) {
            Id = id;
            Title = title;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Finished = finished;
            Priority = priority;
            Participants = participants;
        }

        public Appointment(int id, string title, string description, DateTime startDate, DateTime endDate, bool finished, Priority priority) : this(id, title, description, startDate, endDate, finished, priority, null) { }

        public Appointment(int id, string title, string description, DateTime startDate, DateTime endDate, bool finished) : this(id, title, description, startDate, endDate, finished, null) { }

        public Appointment(string title, DateTime startDate, DateTime endDate) : this(-1, title, null, startDate, endDate, false) { }

        public Appointment(string title, string description, DateTime startDate, DateTime endDate) : this(-1, title, description, startDate, endDate, false) { }

        public void FinishAppointment() {
            Finished = true;
        }
    }
}
