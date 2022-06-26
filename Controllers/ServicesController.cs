using PawPaw.Models;
using PawPaw.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PawPaw.Controllers
{
    public class ServicesController : Controller
    {
        PawPawDBEntities objPawPawDBEntities;
        // GET: Service
        public ServicesController()
        {
            objPawPawDBEntities = new PawPawDBEntities();
        }
        public ActionResult Services()
        {
            ServicesViewModel objServicesViewModel = new ServicesViewModel();
            objServicesViewModel.ListOfDoctorStatus = (from obj in objPawPawDBEntities.DoctorStatus
                                                       select new SelectListItem()
                                                    {
                                                        Text = obj.DoctorStatus,
                                                        Value = obj.DoctorStatusId.ToString()
                                                    }).ToList();
           
            objServicesViewModel.ListOfServiceTypes = (from obj in objPawPawDBEntities.ServiceTypes
                                                       select new SelectListItem()
                                                       {
                                                           Text = obj.ServiceTypeName,
                                                           Value = obj.ServiceTypeId.ToString()
                                                       }).ToList();
            return View(objServicesViewModel);
        }
    }
}