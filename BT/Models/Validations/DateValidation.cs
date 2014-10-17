using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BT.Models
{
    public sealed class DateGreaterThanAttribute : ValidationAttribute
    {
        private string _basePropertyName;

        public DateGreaterThanAttribute(string basePropertyName)
            : base()
        {
            _basePropertyName = basePropertyName;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var basePropertyInfo = validationContext.ObjectType.GetProperty(_basePropertyName);
            var startDate = (DateTime)basePropertyInfo.GetValue(validationContext.ObjectInstance, null);
            var thisDate = (DateTime)value;
            if (thisDate < startDate)
            {
                return new ValidationResult(ErrorMessage.Any() ? ErrorMessage : "Даты ПО не может быть меньше даты С");
            }
            return null;
        }

    }
}