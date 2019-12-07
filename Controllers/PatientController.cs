using ClinicManager.Models;
using ClinicManager.ViewModels;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using AutoMapper;
using ClinicManager.Services;

namespace ClinicManager.Controllers
{
    public class PatientController : Controller
    {
        private  IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
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
            var viewmodel = _patientService.GetPatientsAppointmentsViewModel(id);
            return View(viewmodel);
        }
        public ActionResult Visits(int id)
        {
            var viewModel = _patientService.GetPatientsVisitsViewModel(id);
            return View(viewModel);
        }
    }
}