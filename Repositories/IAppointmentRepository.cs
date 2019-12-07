using ClinicManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Repositories
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> GetAllAppointments();
        Appointment GetAppointment(int id);
        void DeleteAppointment(int id);
        void AddAppointment(Appointment appointment);
        void EditAppointment(Appointment appointment);
    }
}
