using PawPaw.Models;
using PawPaw.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PawPaw.Controllers
{
    public class PersonnelController : Controller
    {
        PawPawDBEntities objPawPawDBEntities;
        // GET: Service
        public PersonnelController()
        {
            objPawPawDBEntities = new PawPawDBEntities();
        }
        public ActionResult Personnel()
        {
            PersonnelViewModel objPersonnelViewModel = new PersonnelViewModel();

            objPersonnelViewModel.ListOfPersonnelTypes = (from obj in objPawPawDBEntities.PersonnelTypes
                                                       select new SelectListItem()
                                                       {
                                                           Text = obj.PersonnelTypeName,
                                                           Value = obj.PersonnelTypeId.ToString()
                                                       }).ToList();
            return View(objPersonnelViewModel);
        }
        [HttpPost]
        public ActionResult Personnel(PersonnelViewModel objPersonnelViewModel)
        {
            //objPawPawDBEntities
            Personnel objPersonnel = new Personnel()
            {
                PersonnelName = objPersonnelViewModel.PersonnelName,
                PersonnelTypeName = objPersonnelViewModel.PersonnelTypeId,
                WorkingFrom = objPersonnelViewModel.WorkingFrom
            };
            objPawPawDBEntities.Personnels.Add(objPersonnel);
            objPawPawDBEntities.SaveChanges();
            return Json(new {message = "Personnel Successfully Added.", success = true}, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult GetAllPersonnel()
        {
            IEnumerable< PersonnelDetailsViewModel > listOfPersonnelDetailsViewModel = 
                (from objPersonnel in objPawPawDBEntities.Personnels 
                 join objPersonnelType in objPawPawDBEntities.PersonnelTypes on objPersonnel.PersonnelTypeId equals objPersonnelType.PersonnelTypeId
                select new PersonnelDetailsViewModel()
                {
                    PersonnelId = objPersonnel.PersonnelId,
                    PersonnelName = objPersonnel.PersonnelName,
                    PersonnelTypeId = objPersonnel.PersonnelTypeName,
                    WorkingFrom = objPersonnel.WorkingFrom,
                }).ToList();
            return PartialView("_PersonnelDetailsPartial.cshtml", listOfPersonnelDetailsViewModel);
        }
    }
}