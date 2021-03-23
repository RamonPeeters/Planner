using System;
using System.Collections.Generic;

namespace Planner.Logic.Appointments {
    public class AppointmentContainer {
        public List<Appointment> GetAppointments(DateTime date, DateType dateType) {
            DateTime start = GetStartDate(date, dateType);
            DateTime end = GetEndDate(date, dateType);
            throw new NotImplementedException();
        }

        public Appointment GetAppointmentById(int id) {
            throw new NotImplementedException();
        }

        private DateTime GetStartDate(DateTime dateTime, DateType dateType) {
            return dateType switch {
                DateType.Week => dateTime.AddDays(-1 * (int)dateTime.DayOfWeek).Date,
                DateType.Month => new DateTime(dateTime.Year, dateTime.Month, 1),
                DateType.Year => new DateTime(dateTime.Year, 1, 1),
                _ => dateTime.Date
            };
        }

        private DateTime GetEndDate(DateTime dateTime, DateType dateType) {
            DateTime start = GetStartDate(dateTime, dateType);
            return dateType switch {
                DateType.Week => start.AddDays(7).Date,
                DateType.Month => start.AddMonths(1).Date,
                DateType.Year => start.AddYears(1).Date,
                _ => start.AddDays(1).Date
            };
        }
    }
}
