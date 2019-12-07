using ClinicManager.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClinicManager.ViewModels;
using ClinicManager.Services;

namespace ClinicManager.Controllers
{
    public class DoctorController : Controller
    {
        private IDoctorService _doctorService;
        public DoctorController(DoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        public ActionResult Index()
        {
            var doctors = _doctorService.GetAllDoctors();
            return View(doctors);
        }
        public ActionResult Details(int id)
        {
            var doctor = _doctorService.GetDoctor(id);
            return View(doctor);
        }
        public ActionResult Edit(int id)
        {
            var viewModel = _doctorService.GetEditDoctorFormViewModel(id);
            return View("DoctorForm", viewModel);
        }
        public ActionResult Delete(int id)
        {
            _doctorService.DeleteDoctor(id);
            return RedirectToAction("Index", "Doctor");
        }
        public ActionResult New()
        {
            var viewModel = _doctorService.GetNewDoctorFormViewModel();
            return View("DoctorForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                if (doctor.Id == 0) _doctorService.AddDoctor(doctor);
                else
                {
                    _doctorService.EditDoctor(doctor);
                }
                return RedirectToAction("Index", "Doctor");
            }
            else
            {
                var viewModel = _doctorService.GetEditDoctorFormViewModel(doctor.Id);
                return View("DoctorForm", viewModel);
            }
        }
        public ActionResult Appointments(int id)
        {
            var viewModel = _doctorService.GetDoctorsAppointmentsViewModel(id);
            return View(viewModel);
        }
        public ActionResult Visits(int id)
        {
            var viewModel = _doctorService.GetDoctorsVisitsViewModel(id);
            return View(viewModel);
        }
    }
}