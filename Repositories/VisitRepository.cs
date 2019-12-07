using ClinicManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ClinicManager.Repositories
{
    public class VisitRepository : IVisitRepository
    {
        private ApplicationDbContext _context;
        protected void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public VisitRepository()
        {
            _context = new ApplicationDbContext();
        }

        public void AddVisitHelper(Visit visit)
        {
            _context.Visits.Add(visit);
            _context.SaveChanges();
        }

        public void DeleteVisit(int id)
        {
            var visit = GetVisit(id);
            _context.Visits.Remove(visit);
            _context.SaveChanges();
        }

        public IEnumerable<Visit> GetAllVisits()
        {
            var visits = _context.Visits
                .Include(v => v.Patient)
                .Include(v => v.Doctor)
                .Include(v => v.Appointment)
                .ToList();
            return visits;
        }
        public Visit GetVisit(int id)
        {
            var visit = _context.Visits
                .Include(v => v.Doctor)
                .Include(v => v.Patient)
                .Include(v => v.Appointment)
                .SingleOrDefault(v => v.Id == id);
            return visit;
        }
        public void EditVisit(Visit visit)
        {
            var visitInDb = GetVisit(visit.Id);
            visitInDb.Diagnosis = visit.Diagnosis;
            visitInDb.Prescription = visit.Prescription;
            visitInDb.AdditionalDescription = visit.AdditionalDescription;
            visitInDb.DoctorId = visit.DoctorId;
            visitInDb.PatientId = visit.PatientId;
            visitInDb.AppointmentId = visit.AppointmentId;
            _context.SaveChanges();
        }
    }
}