using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClinicManager.Models;
using Ninject;

namespace ClinicManager.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private ApplicationDbContext _context;
        public PatientRepository()
        {
            _context = new ApplicationDbContext();
            //_databaseConnection = databaseConnection;
        }
        public IEnumerable<Patient> GetAllPatients()
        {
           var patients = _context.Patients;
            return patients;
        }
        public Patient GetPatient(int id)
        {
            var patient = _context.Patients.SingleOrDefault(p => p.Id == id);
            return patient;
        }
        public void DeletePatient(int id)
        {
            var patient = GetPatient(id);
            _context.Patients.Remove(patient);
            _context.SaveChanges();
        }
        public void AddPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }
        public void EditPatient(Patient patient)
        {
            var patientInDb = GetPatient(patient.Id);
            patientInDb.FullName = patient.FullName;
            patientInDb.BirthDate = patient.BirthDate;
            patientInDb.PhoneNumber = patient.PhoneNumber;
            patientInDb.EMail = patient.EMail;
            patientInDb.Address = patient.Address;
            patientInDb.Height = patient.Height;
            patientInDb.Weight = patient.Weight;
            patientInDb.IsInsured = patient.IsInsured;
            _context.SaveChanges();
        }

    }
}