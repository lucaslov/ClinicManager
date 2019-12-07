using ClinicManager.Repositories;
using ClinicManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManager.Services
{
    public class AppointmentService : AppointmentRepository, IAppointmentService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;
        public AppointmentService(IPatientRepository patientService, IDoctorRepository doctorService)
        {
            _doctorRepository = doctorService;
            _patientRepository = patientService;
        }
        public AppointmentFormViewModel GetEditAppointmentFormViewModel(int id)
        {
            var patients = _patientRepository.GetAllPatients();
            var doctors = _doctorRepository.GetAllDoctors();
            var appointment = GetAppointment(id);
            var viewModel = new AppointmentFormViewModel
            {
                Patients = patients,
                Doctors = doctors,
                Appointment = appointment
            };
            return viewModel;
        }

        public AppointmentFormViewModel GetNewAppointmentFormViewModel()
        {
            var patients = _patientRepository.GetAllPatients();
            var doctors = _doctorRepository.GetAllDoctors();
            var viewModel = new AppointmentFormViewModel
            {
                Patients = patients,
                Doctors = doctors
            };
            return viewModel;
        }
    }
}