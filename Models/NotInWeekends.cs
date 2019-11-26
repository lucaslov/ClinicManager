using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicManager.Models
{
    public class NotInWeekends : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var _context = new ApplicationDbContext();
            var appointment = (Appointment)validationContext.ObjectInstance;
            var appointmentDate = appointment.Date;
           if(appointmentDate.DayOfWeek == DayOfWeek.Saturday 
                || appointmentDate.DayOfWeek == DayOfWeek.Sunday)
            {
                return new ValidationResult("You can't schedule appointments on weekends.");
            }
           else
            {
                return ValidationResult.Success;
            }
        }
    }
}