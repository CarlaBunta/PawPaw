using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appointment.ViewModel
{
    public class AppointmentViewModel
    {

        [Display(Name = "Pacient Name")]
        [Required(ErrorMessage = "Name is required!")]
        public string PacientName { get; set; }

        [Display(Name = "Owner Name")]
        [Required(ErrorMessage = "Name is required!")]
        public string OwnerName { get; set; }

        [Display(Name = "Owner Name")]
        [Required(ErrorMessage = "Name is required!")]
        public string OwnerPhone { get; set; }

        [Display(Name = "Booking In")]
        [Required(ErrorMessage = "Date is required!")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BookingIn { get; set; }

        [Display(Name = "Service Type")]
        [Required(ErrorMessage = "Service is required!")]
        public int ServiceTypeId { get; set; }

        [Display(Name = "Amount")]
        [Required(ErrorMessage = "Amount is required!")]
        public int TotalAmount { get; set; }

        public IEnumerable<SelectListItem> ListOfServiceTypes { get; set; }
    }
}