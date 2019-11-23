using ClinicManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ClinicManager.ViewModels;

namespace ClinicManager.Controllers
{
    public class AppointmentController : Controller
    {
        private ApplicationDbContext _context;
        public AppointmentController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var appointments = _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor);
            return View(appointments);
        }
        public ActionResult New()
        {
            var patients = _context.Patients;
            var doctors = _context.Doctors;
            var viewModel = new AppointmentFormViewModel
            {
                Patients = patients,
                Doctors = doctors
            };
            return View("AppointmentForm", viewModel);
        }
        public ActionResult Details(int id)
        {
            var appointment = _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .SingleOrDefault(a => a.Id == id);
            return View(appointment);
        }
        public ActionResult Edit(int id)
        {
            var patients = _context.Patients;
            var doctors = _context.Doctors;
            var appointment = _context.Appointments.SingleOrDefault(a => a.Id == id);
            var viewModel = new AppointmentFormViewModel
            {
                Patients = patients,
                Doctors = doctors,
                Appointment = appointment
            };
            return View("AppointmentForm", viewModel);
        }
        public ActionResult Delete(int id)
        {
            var appointment = _context.Appointments.SingleOrDefault(a => a.Id == id);
            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
            return RedirectToAction("Index", "Appointment");
        }
        public ActionResult Save(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                if (appointment.Id == 0) _context.Appointments.Add(appointment);
                else
                {
                    var appointmentInDb = _context.Appointments.SingleOrDefault(a => a.Id == appointment.Id);
                    appointmentInDb.Description = appointment.Description;
                    appointmentInDb.Date = appointment.Date;
                    appointmentInDb.PatientId = appointment.PatientId;
                    appointmentInDb.DoctorId = appointment.DoctorId;
                }
                _context.SaveChanges();
                return RedirectToAction("Index", "Appointment");
            }
            else
            {
                var patients = _context.Patients;
                var doctors = _context.Doctors;
                var viewModel = new AppointmentFormViewModel
                {
                    Appointment = appointment,
                    Patients = patients,
                    Doctors = doctors
                };
                return View("AppointmentForm", viewModel);
            }
        }
    }
}