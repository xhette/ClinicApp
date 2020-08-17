using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ClinicApp.Models;

using ClinicData;

namespace ClinicApp.Controllers.History
{
    public class DoctorHistoryController : Controller
    {
        // GET: DoctorHistory
        public ActionResult Index()
        {
            DbWork db = new DbWork();

            var docs = db.GetDoctors();

            List<DoctorModel> model = new List<DoctorModel>();

            foreach (var d in docs)
            {
                model.Add(new DoctorModel(d));
            }

            return View(model);
        }
    }
}