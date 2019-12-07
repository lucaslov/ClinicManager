using ClinicManager.Models;
using ClinicManager.Repositories;
using ClinicManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManager.Services
{
    public class VisitService : VisitRepository, IVisitService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        public VisitService(IPatientRepository patientRepository,
            IDoctorRepository doctorRepository, IAppointmentRepository appointmentRepository)
        {
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
            _appointmentRepository = appointmentRepository;
        }
        public VisitFormViewModel GetEditVisitFormViewModel(int id)
        {
            var visit = GetVisit(id);
            var patients = _patientRepository.GetAllPatients();
            var appointments = _appointmentRepository.GetAllAppointments();
            var doctors = _doctorRepository.GetAllDoctors();
            var viewModel = new VisitFormViewModel
            {
                Patients = patients,
                Appointments = appointments,
                Doctors = doctors,
                Visit = visit
            };
            return viewModel;
        }
        public VisitFormViewModel GetNewVisitFormViewModel()
        {
            var patients = _patientRepository.GetAllPatients();
            var appointments = _appointmentRepository.GetAllAppointments();
            var doctors = _doctorRepository.GetAllDoctors();
            var viewModel = new VisitFormViewModel
            {
                Patients = patients,
                Appointments = appointments,
                Doctors = doctors
            };
            return viewModel;
        }
        public void AddVisit(Visit visit)
        {
            visit.Date = DateTime.Now;
            visit.Cost = CountVisitCost(visit);
            AddVisitHelper(visit);
        }
        public IEnumerable<Visit> PatientsVisits(int patientId)
        {
            var visits = GetAllVisits().Where(v => v.PatientId == patientId);
            return visits;
        }
        public ushort PatientsVisitsForYearPeriod(int patientId)
        {
            var visitsNumber = (ushort)PatientsVisits(patientId)
                .Where(v => (DateTime.Now - v.Date).Days <= 365)
                .Count();
            return visitsNumber;
        }
        public decimal CountVisitCost(Visit visit)
        {
            var patient = _patientRepository.GetPatient(visit.PatientId);
            var doctor = _doctorRepository.GetDoctor(visit.DoctorId);
            decimal visitCost = (decimal)doctor.Specialization.VisitPrice;
            decimal insuranceDiscount = (decimal)(100 - Visit.InsuranceDiscount) / 100;
            decimal loyaltyDiscount = (decimal)(100 - Visit.LoyaltyDiscount) / 100;
            if (patient.IsInsured)
            {
                visitCost = visitCost * insuranceDiscount;
            }
            if (PatientsVisitsForYearPeriod(visit.PatientId) >= Visit.MinimumVisitsForLoyaltyDiscount)
            {
                visitCost = visitCost * loyaltyDiscount;
            }
            return visitCost;
        }
    }
}