using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ClinicApp.Models;

using ClinicData;
using ClinicData.HistoryBase;
using ClinicData.HistoryBase.Enums;

namespace ClinicApp.Controllers.History
{
    public class PatientsHistoryController : Controller
    {
        // GET: PatientsHistory
        public ActionResult Index(DateTime? time, int step = 0)
        {

            if (!time.HasValue)
            {
                time = DateTime.Now;
            }

            ViewBag.Step = step;
            ViewBag.Time = time;

            DbWork db = new DbWork();

            var docs = db.PatientsList();

            List<PatientModel> model = new List<PatientModel>();

            foreach (var d in docs)
            {
                model.Add(new PatientModel(d));
            }

            return View(model);
        }

        public ActionResult Undone(DateTime? time, int step = 0)
        {
            if (!time.HasValue)
            {
                time = DateTime.Now;
            }

            step = HistoryTableWork.PatientsHistory(step, time.Value, DoneStatusEnum.Undone);

            return RedirectToAction("Index", "PatientsHistory", new { time = time, step = step });
        }

        public ActionResult Redone(DateTime? time, int step = 0)
        {
            if (!time.HasValue)
            {
                time = DateTime.Now;
            }

            step = HistoryTableWork.PatientsHistory(step, time.Value, DoneStatusEnum.Redone);

            return RedirectToAction("Index", "PatientsHistory", new { time = time, step = step });
        }
    }
}