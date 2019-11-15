using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManager.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
        public ICollection<Appointment> Appointments { get; set; }

    }
}