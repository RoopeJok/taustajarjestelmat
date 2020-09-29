using System;
using System.ComponentModel.DataAnnotations;
namespace GameWebApi
{
    public class DateChecker : ValidationAttribute
    {
        public string errormessage() => "CreationDate is a date from the past. ";
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dateTime = (DateTime)validationContext.ObjectInstance;
            if (dateTime < DateTime.UtcNow)
            {
                return new ValidationResult(errormessage());
            }
            return ValidationResult.Success;
        }
    }

}