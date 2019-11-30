using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicManager.Models
{
    public class Visit
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter diagnosis - it is required.")]
        public string Diagnosis { get; set; }
        [Required(ErrorMessage = "Please enter prescription - it is required.")]
        public string Prescription { get; set; }
        [Display(Name = "Additional description")]
        public string AdditionalDescription { get; set; }
        public DateTime Date { get; set; }
        [Display(Name = "Doctor")]
        [Required(ErrorMessage = "Please enter doctor - it is required.")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        [Display(Name = "Patient")]
        [Required(ErrorMessage = "Please enter patient - it is required.")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        [Display(Name = "Appointment")]
        public int? AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}