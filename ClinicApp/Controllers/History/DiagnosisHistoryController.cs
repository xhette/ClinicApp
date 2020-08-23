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
    public class DiagnosisHistoryController : Controller
    {
        // GET: Diagnosis
        public ActionResult Index(DateTime? time, int step = 0)
        {

            if (!time.HasValue)
            {
                time = DateTime.Now;
            }

            ViewBag.Step = step;
            ViewBag.Time = time;

            DbWork db = new DbWork();

            List<DiagnosisModel> model = new List<DiagnosisModel>();

            var diagnosis = db.GetDiagnoses();

            foreach (var d in diagnosis)
            {
                model.Add(new DiagnosisModel(d));
            }

            return View(model);
        }

        public ActionResult Undone(DateTime? time, int step = 0)
        {
            if (!time.HasValue)
            {
                time = DateTime.Now;
            }

            step = HistoryTableWork.DiagnosisHistory(step, time.Value, DoneStatusEnum.Undone);

            return RedirectToAction("Index", "DiagnosisHistory", new { time = time, step = step });
        }

        public ActionResult Redone(DateTime? time, int step = 0)
        {
            if (!time.HasValue)
            {
                time = DateTime.Now;
            }

            step = HistoryTableWork.DiagnosisHistory(step, time.Value, DoneStatusEnum.Redone);

            return RedirectToAction("Index", "DiagnosisHistory", new { time = time, step = step });
        }
    }
}