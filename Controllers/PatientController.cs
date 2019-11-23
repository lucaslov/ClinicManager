using ClinicManager.Models;
using ClinicManager.ViewModels;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace ClinicManager.Controllers
{
    public class PatientController : Controller
    {
        private ApplicationDbContext _context;
        public PatientController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var patients = _context.Patients;
            return View(patients);
        }
        public ActionResult New()
        {
            return View("PatientForm");
        }
        public ActionResult Details(int id)
        {
            var patient = _context.Patients.FirstOrDefault(p => p.Id == id);
            return View(patient);
        }
        public ActionResult Edit(int id)
        {
            var patient = _context.Patients.FirstOrDefault(p => p.Id == id);
            if (patient == null) return HttpNotFound();
            return View("PatientForm", patient);
        }
        public ActionResult Delete(int id)
        {
            var patient = _context.Patients.FirstOrDefault(p => p.Id == id);
            _context.Patients.Remove(patient);
            _context.SaveChanges();
            return RedirectToAction("Index", "Patient");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Patient patient)
        {
            if (ModelState.IsValid)
            {
                if (patient.Id == 0) _context.Patients.Add(patient);
                else
                {
                    var patientInDb = _context.Patients.SingleOrDefault(p => p.Id == patient.Id);
                    patientInDb.FullName = patient.FullName;
                    patientInDb.BirthDate = patient.BirthDate;
                    patientInDb.PhoneNumber = patient.PhoneNumber;
                    patientInDb.EMail = patient.EMail;
                    patientInDb.Address = patient.Address;
                    patientInDb.Height = patient.Height;
                    patientInDb.Weight = patient.Weight;
                }
                _context.SaveChanges();
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
    }
}