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
    public class DoctorHistoryController : Controller
    {
        // GET: DoctorHistory
        public ActionResult Index(DateTime? time, int step = 0)
        {

            if (!time.HasValue)
            {
                time = DateTime.Now;
            }

            ViewBag.Step = step;
            ViewBag.Time = time;

            DbWork db = new DbWork();

            var docs = db.GetDoctors();

            List<DoctorModel> model = new List<DoctorModel>();

            foreach (var d in docs)
            {
                model.Add(new DoctorModel(d));
            }

            return View(model);
        }

        public ActionResult Undone(DateTime? time, int step = 0)
        {
            if (!time.HasValue)
            {
                time = DateTime.Now;
            }

            step = HistoryTableWork.DoctorsHistory(step, time.Value, DoneStatusEnum.Undone);

            return RedirectToAction("Index", "DoctorHistory", new { time = time, step = step });
        }

        public ActionResult Redone(DateTime? time, int step = 0)
        {
            if (!time.HasValue)
            {
                time = DateTime.Now;
            }

            step = HistoryTableWork.DoctorsHistory(step, time.Value, DoneStatusEnum.Redone);

            return RedirectToAction("Index", "DoctorHistory", new { time = time, step = step });
        }
    }
}