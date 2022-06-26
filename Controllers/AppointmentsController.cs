using HotelBooking.Models;
using HotelBooking.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelBooking.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: Booking
        private PawPawDBEntities   AppointmentController;
        public AppointmentController()
        {
            AppointmentController = new PawPawDBEntities  ();
        }
        public ActionResult Index()
        {
            AppointmentViewModel objAppointmentViewModel = new AppointmentViewModel();
            objAppointmentViewModel.BookingIn = DateTime.Now;

            return View(objAppointmentViewModel);
        }
        [HttpPost]
        public ActionResult Appointment(AppointmentViewModel objAppointmentViewModel)
        {

            PatientAppointment patientAppointment = new PatientAppointment()
            {
                PatientName=objAppointmentViewModel.PatientName,
                OwnerName=objAppointmentViewModel.OwnerName,
                BookingIn=objAppointmentViewModel.BookingIn, 
                ServiceType=objAppointmentViewModel.ServiceType,
                TotalAmount=TotalAmount,
            };
            AppointmentController.PatientAppointments.Add(PatientAppointment);
            AppointmentController.SaveChanges();

        

            return Json(data: new { message="Appointments successfully created!", success=true}, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult GetAllAppointmentHistory()
        {
            List<PacientAppointmentViewModel> listOfAppointmentViewModels = new List<PacientAppointmentViewModel>();
            listOfAppointmentViewModels = (from objAppointment in objPawPawDBEntities.PacientAppointments
                                           join objPacient in objPawPawDBEntities.Pacients on objAppointment.AppointmentId equals objPacient.AppointmentId
                                           select new PacientAppointmentViewModel
                                           {
                                               Bookingin = objAppointment.BookingIn,
                                               PacientName = objAppointment.PacientName,
                                               OwnerName = objAppointment.OwnerName,
                                               ServiceTypeId = objAppointment.ServiceTypeId,
                                               TotalAmount = objAppointment.TotalAmount,
                                               ServicePrice = objAppointment.ServicePrice
                                           }).ToList();

            return PartialView("_AppointmentHistoryPartial", listOfAppointmentViewModels);
        }

    }
}
