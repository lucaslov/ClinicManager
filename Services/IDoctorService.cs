using ClinicManager.Repositories;
using ClinicManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Services
{
    public interface IDoctorService : IDoctorRepository
    {
        DoctorFormViewModel GetEditDoctorFormViewModel(int id);
        DoctorFormViewModel GetNewDoctorFormViewModel();
        DoctorsAppointmentsViewModel GetDoctorsAppointmentsViewModel(int id);
        DoctorsVisitsViewModel GetDoctorsVisitsViewModel(int id);
    }
}
