using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PawPaw.ViewModel
{
    public class PersonnelViewModel
    {
        public int PersonnelId { get; set; }    
        [Display (Name = "Name")]
        [Required(ErrorMessage ="Personnel Name is required!")]
        public string PersonnelName { get; set; }
        [Display(Name = "Personnel")]
        [Required(ErrorMessage = "Personnel Type is required!")]

        public int PersonnelTypeId { get; set; }
        [Display(Name = "Working since")]
        [Required(ErrorMessage = "A date is required!")]

        public DateTime WorkingFrom { get; set; }

        public List<SelectListItem> ListOfPersonnelTypes { get; set; }
    }
}