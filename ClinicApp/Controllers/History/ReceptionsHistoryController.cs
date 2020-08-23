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
    public class ReceptionsHistoryController : Controller
    {
        // GET: ReceptionsHistory
        public ActionResult Index(DateTime? time, int step = 0)
        {

            if (!time.HasValue)
            {
                time = DateTime.Now;
            }

            ViewBag.Step = step;
            ViewBag.Time = time;

            DbWork db = new DbWork();
            var records = db.GetReceptions();

            List<ReceptionViewModel> model = new List<ReceptionViewModel>();

            foreach (var record in records)
            {
                model.Add(new ReceptionViewModel(record));
            }

            return View(model);
        }

        public ActionResult Undone(DateTime? time, int step = 0)
        {
            if (!time.HasValue)
            {
                time = DateTime.Now;
            }

            step = HistoryTableWork.ReceptionsHistory(step, time.Value, DoneStatusEnum.Undone);

            return RedirectToAction("Index", "ReceptionsHistory", new { time = time, step = step });
        }

        public ActionResult Redone(DateTime? time, int step = 0)
        {
            if (!time.HasValue)
            {
                time = DateTime.Now;
            }

            step = HistoryTableWork.ReceptionsHistory(step, time.Value, DoneStatusEnum.Redone);

            return RedirectToAction("Index", "ReceptionsHistory", new { time = time, step = step });
        }
    }
}