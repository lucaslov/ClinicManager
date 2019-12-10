using ClinicManager.Services;
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
            var validatedAppointment = (Appointment) validationContext.ObjectInstance;
            var doctorMaxAppointments = _context.Doctors
                .SingleOrDefault(d => d.Id == validatedAppointment.DoctorId)
                .MaxAppointmentsPerDay;
            //appointments with chosen doctor and date
            var appointments = _context.Appointments
                .Where(a => a.Date == validatedAppointment.Date 
                && a.DoctorId == validatedAppointment.DoctorId);
            var maxAppointmentsPerHour = Appointment.MaxAppointmentsPerHour;
            var appointmentsThatHour = appointments
                .Where(a => a.Date.Hour == validatedAppointment.Date.Hour);

            if (appointments.Count() == doctorMaxAppointments
                || validatedAppointment == null)
            {
                return new ValidationResult("There are too many appointments with this doctor at that day. Please change appointment time or selected doctor.");
            }
            else if (appointmentsThatHour.Count() >= maxAppointmentsPerHour)
            {
                return new ValidationResult("There are too many appointments with this doctor at that hour. Please change appointment time or selected doctor.");
            }
            else
            {
                return ValidationResult.Success;
            }
            
        }
    }
}