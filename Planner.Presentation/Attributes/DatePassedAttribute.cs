using System;
using System.ComponentModel.DataAnnotations;

namespace Planner.Presentation.Attributes {
    public class DatePassedAttribute : ValidationAttribute {
        public override bool IsValid(object value) {
            return value is DateTime dateTime && dateTime > DateTime.Now;
        }
    }
}
