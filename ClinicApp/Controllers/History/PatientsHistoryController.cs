using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ClinicApp.Models;

using ClinicData;

namespace ClinicApp.Controllers.History
{
    public class PatientsHistoryController : Controller
    {
        // GET: PatientsHistory
        public ActionResult Index()
        {
            DbWork db = new DbWork();

            var docs = db.PatientsList();

            List<PatientModel> model = new List<PatientModel>();

            foreach (var d in docs)
            {
                model.Add(new PatientModel(d));
            }

            return View(model);
        }
    }
}