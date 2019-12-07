using ClinicManager.Repositories;
using ClinicManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManager.Services
{
    public class DoctorService : DoctorRepository, IDoctorService
    {
        private readonly ISpecializationRepository _specializationRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IVisitRepository _visitRepository;
        public DoctorService(ISpecializationRepository specializationRepository,
            IAppointmentRepository appointmentRepository, IVisitRepository visitRepository)
        {
            _specializationRepository = specializationRepository;
            _appointmentRepository = appointmentRepository;
            _visitRepository = visitRepository;
        }

        public DoctorsAppointmentsViewModel GetDoctorsAppointmentsViewModel(int id)
        {
            var appointments = _appointmentRepository.GetAllAppointments().Where(d => d.DoctorId == id);
            var doctor = GetDoctor(id);
            var viewModel = new DoctorsAppointmentsViewModel
            {
                Appointments = appointments,
                Doctor = doctor
            };
            return viewModel;
        }

        public DoctorsVisitsViewModel GetDoctorsVisitsViewModel(int id)
        {
            var doctor = GetDoctor(id);
            var visits = _visitRepository.GetAllVisits().Where(v => v.DoctorId == id);
            var viewModel = new DoctorsVisitsViewModel
            {
                Doctor = doctor,
                Visits = visits
            };
            return viewModel;
        }

        public DoctorFormViewModel GetEditDoctorFormViewModel(int id)
        {
            var doctor = GetDoctor(id);
            var specializations = _specializationRepository.GetAllSpecializations().ToList();
            var viewModel = new DoctorFormViewModel
            {
                Specializations = specializations,
                Doctor = doctor
            };
            return viewModel;
        }
        public DoctorFormViewModel GetNewDoctorFormViewModel()
        {
            var specializations = _specializationRepository.GetAllSpecializations();
            var viewModel = new DoctorFormViewModel
            {
                Specializations = specializations
            };
            return viewModel;
        }
    }
}