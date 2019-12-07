using ClinicManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Repositories
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetAllDoctors();
        Doctor GetDoctor(int id);
        void DeleteDoctor(int id);
        void AddDoctor(Doctor doctor);
        void EditDoctor(Doctor doctor);
    }
}
