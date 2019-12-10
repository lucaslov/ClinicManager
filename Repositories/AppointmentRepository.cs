using ClinicManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ClinicManager.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
       private ApplicationDbContext _context;
        protected void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public AppointmentRepository()
        {
            _context = new ApplicationDbContext();
        }
       public IEnumerable<Appointment> GetAllAppointments()
        {
            var appointments = _context.Appointments
                 .Include(a => a.Patient)
                 .Include(a => a.Doctor);
            return appointments;
        }
        public IEnumerable<Appointment> GetTodaysAppointments()
        {
            var appointments = _context.Appointments
                 .Include(a => a.Patient)
                 .Include(a => a.Doctor)
                 .Where(a => a.Date == DateTime.Today)
                 .ToList();
            return appointments;
        }
        public Appointment GetAppointment(int id)
        {
            var appointment = _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .SingleOrDefault(a => a.Id == id);
            return appointment;
        }
        public void DeleteAppointment(int id)
        {
            var appointment = GetAppointment(id);
            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
        }
        public void AddAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public void EditAppointment(Appointment appointment)
        {
            var appointmentInDb = GetAppointment(appointment.Id);
            appointmentInDb.Description = appointment.Description;
            appointmentInDb.Date = appointment.Date;
            appointmentInDb.PatientId = appointment.PatientId;
            appointmentInDb.DoctorId = appointment.DoctorId;
            _context.SaveChanges();
        }
    }
}