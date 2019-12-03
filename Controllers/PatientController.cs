using ClinicManager.Models;
using ClinicManager.ViewModels;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using AutoMapper;
using ClinicManager.Services;
using Ninject;

namespace ClinicManager.Controllers
{
    public class PatientController : Controller
    {
        private ApplicationDbContext _context;
        
        private  IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _context = new ApplicationDbContext();
            _patientService = patientService;
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        { 
            var patients = _patientService.GetAllPatients(); 
            return View(patients);
        }
        public ActionResult New()
        {
            return View("PatientForm");
        }
        public ActionResult Details(int id)
        {
            var patient = _patientService.GetPatient(id);
            if (patient == null) return HttpNotFound();
            return View(patient);
        }
        public ActionResult Edit(int id)
        {
            var patient = _patientService.GetPatient(id);
            if (patient == null) return HttpNotFound();
            return View("PatientForm", patient);
        }
        public ActionResult Delete(int id)
        {
            _patientService.DeletePatient(id);
            return RedirectToAction("Index", "Patient");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Patient patient)
        {
            if (ModelState.IsValid)
            {
                if (patient.Id == 0) _patientService.AddPatient(patient);
                else
                {
                    _patientService.EditPatient(patient);
                }
                return RedirectToAction("Index", "Patient");
            }
            else
            {
                return View("PatientForm", patient);
            }
        }
        public ActionResult Appointments(int id)
        {
            var appointments = _context.Appointments.Include(d => d.Doctor).Where(a => a.PatientId == id);
            var patient = _context.Patients.SingleOrDefault(p => p.Id == id);
            var viewmodel = new PatientsAppointmentsViewModel
            {
                Appointments = appointments,
                Patient = patient
            };
            return View(viewmodel);
        }
        public ActionResult Visits(int id)
        {
            var patient = _context.Patients.SingleOrDefault(p => p.Id == id);
            var visits = _context.Visits.Include(d => d.Doctor).Where(v => v.PatientId == id);
            var viewModel = new PatientsVisitsViewModel
            {
                Patient = patient,
                Visits = visits
            };
            return View(viewModel);
        }
    }
}