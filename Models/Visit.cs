using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManager.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
        public string AdditionalDescription { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int? AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}