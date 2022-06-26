using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PawPaw.ViewModel
{
    public class ServicesViewModel
    {
        public int ServiceId { get; set; }
        [Display(Name = "Service Price")]
        public int ServicePrice { get; set; }
        [Display(Name = "Doctor Availability")]
        public int DoctorStatusId { get; set; }
        [Display(Name = "Service Type")]
        public int ServiceTypeId { get; set; }
        [Display(Name = "Service Description")]
        public string ServiceDescription { get; set; } 
        public bool IsActive { get; set; }   


        public List<SelectListItem> ListOfDoctorStatus { get; set; }
        public  List<SelectListItem> ListOfServiceTypes { get; set; }
    }
}