using ClinicManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ClinicManager.ViewModels;
using ClinicManager.Services;

namespace ClinicManager.Controllers
{
    public class AppointmentController : Controller
    {
        private IAppointmentService _AppointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _AppointmentService = appointmentService;
        }
        public ActionResult Index()
        {
            var appointments = _AppointmentService.GetAllAppointments();
            return View(appointments);
        }
        public ActionResult New()
        {
            var viewModel = _AppointmentService.GetNewAppointmentFormViewModel();
            return View("AppointmentForm", viewModel);
        }
        public ActionResult Details(int id)
        {
            var appointment = _AppointmentService.GetAppointment(id);
            return View(appointment);
        }
        public ActionResult Edit(int id)
        {
            var viewModel = _AppointmentService.GetEditAppointmentFormViewModel(id);
            return View("AppointmentForm", viewModel);
        }
        public ActionResult Delete(int id)
        {
            _AppointmentService.DeleteAppointment(id);
            return RedirectToAction("Index", "Appointment");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                if (appointment.Id == 0) _AppointmentService.AddAppointment(appointment);
                else
                {
                    _AppointmentService.EditAppointment(appointment);
                }
                return RedirectToAction("Index");
            }
            else
            {
                var viewModel = _AppointmentService.GetEditAppointmentFormViewModel(appointment.Id);
                return View("AppointmentForm", viewModel);
            }
        }
    }
}