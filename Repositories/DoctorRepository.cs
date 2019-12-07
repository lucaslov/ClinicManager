using ClinicManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ClinicManager.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private ApplicationDbContext _context;
        protected void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public DoctorRepository()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Doctor> GetAllDoctors()
        {
            var doctors = _context.Doctors.Include(s => s.Specialization).ToList();
            return doctors;
        }
        public Doctor GetDoctor(int id)
        {
            var doctor = _context.Doctors.Include(d => d.Specialization).SingleOrDefault(d => d.Id == id);
            return doctor;
        }
        public void DeleteDoctor(int id)
        {
            var doctor = GetDoctor(id);
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
        }
        public void AddDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }
        public void EditDoctor(Doctor doctor)
        {
            var doctorInDb = GetDoctor(doctor.Id);
            doctorInDb.FullName = doctor.FullName;
            doctorInDb.PhoneNumber = doctor.PhoneNumber;
            doctorInDb.EMail = doctor.EMail;
            doctorInDb.Address = doctor.Address;
            doctorInDb.SpecializationId = doctor.SpecializationId;
            doctorInDb.MaxAppointmentsPerDay = doctor.MaxAppointmentsPerDay;
            _context.SaveChanges();
        }
    }
}