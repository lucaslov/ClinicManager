using ClinicManager.Repositories;
using ClinicManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManager.Services
{
    public class PatientService : PatientRepository, IPatientService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IVisitRepository _visitRepository;
        public PatientService(IAppointmentRepository appointmentRepository, IVisitRepository visitRepository)
        {
            _appointmentRepository = appointmentRepository;
            _visitRepository = visitRepository;
        }
        public PatientsAppointmentsViewModel GetPatientsAppointmentsViewModel(int id)
        {
            var appointments = _appointmentRepository.GetAllAppointments().Where(a => a.PatientId == id);
            var patient = GetPatient(id);
            var viewmodel = new PatientsAppointmentsViewModel
            {
                Appointments = appointments,
                Patient = patient
            };
            return viewmodel;
        }
        public PatientsVisitsViewModel GetPatientsVisitsViewModel(int id)
        {
            var patient = GetPatient(id);
            var visits = _visitRepository.GetAllVisits().Where(v => v.PatientId == id);
            var viewModel = new PatientsVisitsViewModel
            {
                Patient = patient,
                Visits = visits
            };
            return viewModel;
        }
    }
}