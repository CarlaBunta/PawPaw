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
            string message = String.Empty;
            if (objPersonnelViewModel.PersonnelId == 0)
            {
                
               //objPawPawDBEntities
                Personnel objPersonnel = new Personnel()
                {
                    PersonnelName = objPersonnelViewModel.PersonnelName,
                    PersonnelTypeId = objPersonnelViewModel.PersonnelTypeId,
                    WorkingFrom = objPersonnelViewModel.WorkingFrom
                };
                objPawPawDBEntities.Personnels.Add(objPersonnel);
                message = "Successfully Added!";
            }
            else
            {
                Personnel objPersonnel = objPawPawDBEntities.Personnels.Single(model => model.PersonnelId == objPersonnelViewModel.PersonnelId);
                objPersonnel.PersonnelName = objPersonnelViewModel.PersonnelName;
                objPersonnel.PersonnelTypeId = objPersonnelViewModel.PersonnelTypeId;
                objPersonnel.WorkingFrom = objPersonnelViewModel.WorkingFrom;
                message = "Updated!";

            }

            objPawPawDBEntities.SaveChanges();
            return Json(new {message = "Personnel Successfully Added.", success = true}, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult GetAllPersonnels()
        {
            IEnumerable<PersonnelDetailsViewModel> listOfPersonnelDetailsViewModel =
                (from objPersonnel in objPawPawDBEntities.Personnels 
                 join objPersonnelType in objPawPawDBEntities.PersonnelTypes on objPersonnel.PersonnelTypeId equals objPersonnelType.PersonnelTypeId
                select new PersonnelDetailsViewModel()
                {
                    PersonnelId = objPersonnel.PersonnelId,
                    PersonnelName = objPersonnel.PersonnelName,
                    PersonnelTypeId = objPersonnel.PersonnelTypeId,
                    WorkingFrom = objPersonnel.WorkingFrom,
                }).ToList();
            return PartialView("_PersonnelDetailsPartial.cshtml", listOfPersonnelDetailsViewModel);
        }

        [HttpGet]
        public JsonResult EditPersonnelDetails(int personnelId)
        {
            var result = objPawPawDBEntities.Personnels.Single(model => model.PersonnelId == personnelId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult DeletePersonnelDetails(int personnelId)
        {
            Personnel objPersonnel=objPawPawDBEntities.Personnels.Single(model => model.PersonnelId==personnelId);
            objPawPawDBEntities.SaveChanges();
            return Json(new {message="Record successfully deleted!", success = true}, JsonRequestBehavior.AllowGet);
        }
    }
}