using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicManager.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        [Display(Name = "Full name")]
        [Required(ErrorMessage = "Please enter doctor's full name - it is required.")]
        [MaxLength(255, ErrorMessage = "Full name must maximum of 255 characters.")]
        public string FullName { get; set; }
        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "Please enter doctor's phone number - it is required.")]
        [Phone(ErrorMessage = "Please enter a correct phone number.")]
        public string PhoneNumber { get; set; }
        [Display(Name = "E-mail address")]
        [Required(ErrorMessage = "Please enter doctor's e-mail address - it is required.")]
        [EmailAddress(ErrorMessage = "Please enter a correct e-mail address.")]
        public string EMail { get; set; }
        public string Address { get; set; }
        [Display(Name = "Doctor's specialization")]
        [Required(ErrorMessage = "Please enter doctor's specialization - it is required.")]
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
        public ICollection<Appointment> Appointments { get; set; }

    }
}