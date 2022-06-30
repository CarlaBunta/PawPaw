using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PawPaw.Controllers
{
    public class AppointmentsController : Controller
    {
        // GET: Appointments
        public ActionResult Appointments()
        {
            return View();
        }
    }
}