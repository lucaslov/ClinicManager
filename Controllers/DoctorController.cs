using ClinicManager.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClinicManager.ViewModels;

namespace ClinicManager.Controllers
{
    public class DoctorController : Controller
    {
        private ApplicationDbContext _context;
        public DoctorController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var doctors = _context.Doctors.Include(d => d.Specialization).ToList();
            return View(doctors);
        }
        public ActionResult Details(int id)
        {
            var doctor = _context.Doctors.Include(d => d.Specialization).FirstOrDefault(d => d.Id == id);
            return View(doctor);
        }
        public ActionResult Edit(int id)
        {
            var doctor = _context.Doctors.Include(d => d.Specialization).FirstOrDefault(d => d.Id == id);
            var specializations = _context.Specializations.ToList();
            var viewModel = new DoctorFormViewModel
            {
                Specializations = specializations,
                Doctor = doctor
            };
            return View("DoctorForm", viewModel);
        }
        public ActionResult Delete(int id)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.Id == id);
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
            return RedirectToAction("Index", "Doctor");
        }
        public ActionResult New()
        {
            var specializations = _context.Specializations.ToList();
            var viewModel = new DoctorFormViewModel
            {
                Specializations = specializations
            };
            return View("DoctorForm", viewModel);
        }
        public ActionResult Save(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                if (doctor.Id == 0) _context.Doctors.Add(doctor);
                else
                {
                    var doctorInDb = _context.Doctors.SingleOrDefault(d => d.Id == doctor.Id);
                    doctorInDb.FullName = doctor.FullName;
                    doctorInDb.PhoneNumber = doctor.PhoneNumber;
                    doctorInDb.EMail = doctor.EMail;
                    doctorInDb.Address = doctor.Address;
                    doctorInDb.SpecializationId = doctor.SpecializationId;
                }
                _context.SaveChanges();
                return RedirectToAction("Index", "Doctor");
            }
            else
            {
                var specializations = _context.Specializations.ToList();
                var viewModel = new DoctorFormViewModel
                {
                    Specializations = specializations,
                    Doctor = doctor
                };
                return View("DoctorForm", viewModel);
            }
        }
        public ActionResult Appointments(int id)
        {
            var appointments = _context.Appointments.Include(p => p.Patient).Where(d => d.DoctorId == id);
            var doctor = _context.Doctors.SingleOrDefault(d => d.Id == id);
            var viewModel = new DoctorsAppointmentsViewModel
            {
                Appointments = appointments,
                Doctor = doctor
            };
            return View(viewModel);
        }
    }
}