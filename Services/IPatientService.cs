﻿using ClinicManager.Repositories;
using ClinicManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Services
{
    public interface IPatientService : IPatientRepository
    {
        PatientsAppointmentsViewModel GetPatientsAppointmentsViewModel(int id);
        PatientsVisitsViewModel GetPatientsVisitsViewModel(int id);
    }
}
