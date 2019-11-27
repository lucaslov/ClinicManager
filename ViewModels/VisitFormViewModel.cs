using ClinicManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManager.ViewModels
{
    public class VisitFormViewModel
    {
        public Visit Visit { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<Patient> Patients { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
    }
}