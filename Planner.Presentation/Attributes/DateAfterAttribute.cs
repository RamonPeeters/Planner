using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Planner.Presentation.Attributes {
    public class DateAfterAttribute : ValidationAttribute {
        private const string UnknownProperty = "Unknown property {0}.";
        private const string PropertyIsNotDateTime = "{0} is not a DateTime object.";

        public override bool RequiresValidationContext { get { return true; } }
        private readonly string PropertyName;

        public DateAfterAttribute(string propertyName) {
            PropertyName = propertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            if (value is not DateTime endDate) {
                return new ValidationResult(string.Format(PropertyIsNotDateTime, nameof(value)));
            }
            PropertyInfo property = validationContext.ObjectType.GetProperty(PropertyName);
            if (property == null) {
                return new ValidationResult(string.Format(UnknownProperty, PropertyName));
            }
            if (property.GetValue(validationContext.ObjectInstance, null) is not DateTime startDate) {
                return new ValidationResult(string.Format(PropertyIsNotDateTime, PropertyName));
            }
            if (endDate < startDate) {
                return new ValidationResult(ErrorMessage);
            }
            return null;
        }
    }
}
