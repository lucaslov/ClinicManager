using ClinicManager.Models;
using ClinicManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicManager.Controllers
{
    public class VisitController : Controller
    {
        private ApplicationDbContext _context;
        public VisitController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var visits = _context.Visits
                .Include(v => v.Patient)
                .Include(v => v.Doctor)
                .Include(v => v.Appointment)
                .ToList();
            return View(visits);
        }
        public ActionResult Details(int id)
        {
            var visit = _context.Visits
                .Include(v => v.Doctor)
                .Include(v => v.Patient)
                .Include(v => v.Appointment)
                .SingleOrDefault(v => v.Id == id);
            return View(visit);
        }
        public ActionResult Delete(int id)
        {
            var visits = _context.Visits;
           var visit = _context.Visits.SingleOrDefault(v => v.Id == id);
            _context.Visits.Remove(visit);
            _context.SaveChanges();
            return View("Index", visits);
        }
        public ActionResult Edit(int id)
        {
            var visit = _context.Visits.SingleOrDefault(v => v.Id == id);
            var patients = _context.Patients;
            var appointments = _context.Appointments;
            var doctors = _context.Doctors;
            var viewModel = new VisitFormViewModel
            {
                Patients = patients,
                Appointments = appointments,
                Doctors = doctors,
                Visit = visit
            };
            return View("VisitForm", viewModel);
        }
        public ActionResult New()
        {
            var patients = _context.Patients;
            var appointments = _context.Appointments;
            var doctors = _context.Doctors;
            var viewModel = new VisitFormViewModel
            {
                Patients = patients,
                Appointments = appointments,
                Doctors = doctors
            };
            return View("VisitForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Visit visit)
        {
            if (ModelState.IsValid)
            {
                if (visit.Id == 0)
                {
                    visit.Date = DateTime.Now;
                    _context.Visits.Add(visit);
                }
                else
                {
                    var visitInDb = _context.Visits.SingleOrDefault(v => v.Id == visit.Id);
                    visitInDb.Diagnosis = visit.Diagnosis;
                    visitInDb.Prescription = visit.Prescription;
                    visitInDb.AdditionalDescription = visit.AdditionalDescription;
                    visitInDb.DoctorId = visit.DoctorId;
                    visitInDb.PatientId = visit.PatientId;
                    visitInDb.AppointmentId = visit.AppointmentId;
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                var appointments = _context.Appointments;
                var patients = _context.Patients;
                var doctors = _context.Doctors;
                var viewModel = new VisitFormViewModel
                {
                    Visit = visit,
                    Appointments = appointments,
                    Patients = patients,
                    Doctors = doctors
                };
                return View("VisitForm", viewModel);
            }
        }
    }
}