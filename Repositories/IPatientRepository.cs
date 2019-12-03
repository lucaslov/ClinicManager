using ClinicManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Repositories
{
   public interface IPatientRepository
    {
        IEnumerable<Patient> GetAllPatients();
        Patient GetPatient(int id);
        void DeletePatient(int id);
        void AddPatient(Patient patient);
        void EditPatient(Patient patient);
    }
}
