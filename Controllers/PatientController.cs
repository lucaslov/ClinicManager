using ClinicManager.Models;
using System.Linq;
using System.Web.Mvc;

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
        public ActionResult Save(Patient patient)
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
    }
}