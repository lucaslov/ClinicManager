using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicManager.Models
{
    public class DateInTheFuture : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var appointment = (Appointment)validationContext.ObjectInstance;
            var appointmentDate = appointment.Date;
            if(appointmentDate < DateTime.Now)
            {
                return new ValidationResult("You can't use a date in the past or today's date to make a new appointment.");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}