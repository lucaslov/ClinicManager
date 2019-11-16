using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicManager.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string FullName { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string EMail { get; set; }
        public string Address { get; set; }
        [Required]
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
        public ICollection<Appointment> Appointments { get; set; }

    }
}