using ClinicManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManager.ViewModels
{
    public class DoctorFormViewModel
    {
        public IEnumerable<Specialization> Specializations { get; set; }
        public Doctor Doctor { get; set; }
    }
}