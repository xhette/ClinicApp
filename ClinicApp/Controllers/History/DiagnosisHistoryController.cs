using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ClinicApp.Models;

using ClinicData;

namespace ClinicApp.Controllers.History
{
    public class DiagnosisHistoryController : Controller
    {
        // GET: Diagnosis
        public ActionResult Index()
        {
            DbWork db = new DbWork();

            List<DiagnosisModel> model = new List<DiagnosisModel>();

            var diagnosis = db.GetDiagnoses();

            foreach (var d in diagnosis)
            {
                model.Add(new DiagnosisModel(d));
            }

            return View(model);
        }
    }
}