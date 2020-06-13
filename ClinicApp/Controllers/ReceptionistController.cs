using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ClinicApp.Models;
using ClinicData;

namespace ClinicApp.Controllers
{
    public class ReceptionistController : Controller
    {
        // GET: Receptionist
        public ActionResult Index()
        {
            return View();
        }
    }
}