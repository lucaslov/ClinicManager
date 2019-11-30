using ClinicManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManager.ViewModels
{
    public class PatientsVisitsViewModel
    {
        public Patient Patient { get; set; }
        public IEnumerable<Visit> Visits { get; set; }
    }
}