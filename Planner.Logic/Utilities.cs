using Planner.LogicInterfaces;
using System;

namespace Planner.Logic {
    static class Utilities {
        public static DateTime GetStart(this DateTime dateTime, DateType dateType) {
            return dateType switch {
                DateType.Week => dateTime.AddDays(-1 * (int)dateTime.DayOfWeek).Date,
                DateType.Month => new DateTime(dateTime.Year, dateTime.Month, 1),
                DateType.Year => new DateTime(dateTime.Year, 1, 1),
                _ => dateTime.Date
            };
        }

        public static DateTime GetEnd(this DateTime dateTime, DateType dateType) {
            DateTime start = dateTime.GetStart(dateType);
            return dateType switch {
                DateType.Week => start.AddDays(7).Date,
                DateType.Month => start.AddMonths(1).Date,
                DateType.Year => start.AddYears(1).Date,
                _ => start.AddDays(1).Date
            };
        }
    }
}
