using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicManager.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [Display(Name ="Full name")]
        [Required(ErrorMessage = "Please enter patient's full name - it is required.")]
        [MaxLength(255, ErrorMessage = "Full name must maximum of 255 characters.")]
        public string FullName { get; set; }
        [Display(Name = "Date of birth")]
        [Required(ErrorMessage = "Please enter patient's date of birth - it is required.")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Please enter patient's phone number - it is required.")]
        [Phone(ErrorMessage = "Please enter a correct phone number.")]
        public string PhoneNumber { get; set; }
        [Display(Name = "E-mail address")]
        [Required(ErrorMessage = "Please enter patient's email address - it is required.")]
        [EmailAddress(ErrorMessage = "Please enter a correct e-mail address.")]
        public string EMail { get; set; }
        public string Address { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Visit> Visits{ get; set; }
    }
}