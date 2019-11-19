using ClinicManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManager.ViewModels
{
    public class AppointmentsViewModel
    {
        public IEnumerable<Appointment> Appointments { get; set; }
        public Doctor Doctor { get; set; }
    }
}