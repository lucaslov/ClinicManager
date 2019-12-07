using ClinicManager.Repositories;
using ClinicManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Services
{
    public interface IAppointmentService : IAppointmentRepository
    {
        AppointmentFormViewModel GetEditAppointmentFormViewModel(int id);
        AppointmentFormViewModel GetNewAppointmentFormViewModel();
    }
}
