using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicManager.Models
{
    public class MaxAppointments : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var _context = new ApplicationDbContext();
            var appointment = (Appointment) validationContext.ObjectInstance;
            var appointmentDate = appointment.Date;
            var doctorId = appointment.DoctorId;
            var doctorMaxAppointments = _context.Doctors.SingleOrDefault(d => d.Id == doctorId).MaxAppointmentsPerDay;
            //appointments with choosen doctor and date
            var appointments = _context.Appointments.Where(a => a.Date == appointmentDate && a.DoctorId == doctorId).Count();
           
            if (appointments == doctorMaxAppointments || appointment == null)
            {
                return new ValidationResult("There are too many appointments with this doctor. Please change date or selected doctor.");
            }
            else
            {
                return ValidationResult.Success;
            }
            
        }
    }
}