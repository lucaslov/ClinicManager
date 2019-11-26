using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicManager.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter description - it is required.")]
        [MaxLength(500, ErrorMessage = "Description maximum of 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter appointment's date - it is required.")]
        [NotInWeekends]
        [DateInTheFuture]
        [MaxAppointments]
        public DateTime Date { get; set; }

        [Display(Name = "Patient")]
        [Required(ErrorMessage = "Please enter patient - it is required.")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Display(Name = "Doctor")]
        [Required(ErrorMessage = "Please enter doctor - it is required.")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}