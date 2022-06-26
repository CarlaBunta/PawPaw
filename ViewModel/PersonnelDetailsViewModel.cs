using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PawPaw.ViewModel
{
    public class PersonnelDetailsViewModel
    {
        public int PersonnelId { get; set; }
        public string PersonnelName { get; set; }
        public int PersonnelTypeId { get; set; }
        public DateTime WorkingFrom { get; set; }
    }
}