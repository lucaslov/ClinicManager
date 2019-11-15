using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManager.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int MyProperty { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Visit> Visits{ get; set; }
    }
}