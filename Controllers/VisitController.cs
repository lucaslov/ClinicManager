using ClinicManager.Models;
using ClinicManager.Services;
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
        private IVisitService _visitService;
        public VisitController(IVisitService visitService)
        {
            _visitService = visitService;
        }
        public ActionResult Index()
        {
            var visits = _visitService.GetAllVisits();
            return View(visits);
        }
        public ActionResult Details(int id)
        {
            var visit = _visitService.GetVisit(id);
            return View(visit);
        }
        public ActionResult Delete(int id)
        {
            _visitService.DeleteVisit(id);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var viewModel = _visitService.GetEditVisitFormViewModel(id);
            return View("VisitForm", viewModel);
        }
        public ActionResult New()
        {
            var viewModel = _visitService.GetNewVisitFormViewModel();
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
                    _visitService.AddVisit(visit);
                }
                else
                {
                    _visitService.EditVisit(visit);
                }
                return RedirectToAction("Index");
            }
            else
            {
                var viewModel = _visitService.GetEditVisitFormViewModel(visit.Id);
                return View("VisitForm", viewModel);
            }
        }
    }
}