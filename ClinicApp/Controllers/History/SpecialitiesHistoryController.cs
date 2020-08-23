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
    public class SpecialitiesHistoryController : Controller
    {
        // GET: SpecialitiesHistory
        public ActionResult Index(DateTime? time, int step = 0)
        {

            if (!time.HasValue)
            {
                time = DateTime.Now;
            }

            ViewBag.Step = step;
            ViewBag.Time = time;

            DbWork db = new DbWork();

            var specialities = db.GetSpecialities();

            List<SpecialityModel> model = new List<SpecialityModel>();

            foreach (var spec in specialities)
            {
                model.Add(new SpecialityModel(spec));
            }

            return View(model);
        }

        public ActionResult Undone(DateTime? time, int step = 0)
        {
            if (!time.HasValue)
            {
                time = DateTime.Now;
            }

            step = HistoryTableWork.SpecialitiesHistory(step, time.Value, DoneStatusEnum.Undone);

            return RedirectToAction("Index", "SpecialitiesHistory", new { time = time, step = step });
        }

        public ActionResult Redone(DateTime? time, int step = 0)
        {
            if (!time.HasValue)
            {
                time = DateTime.Now;
            }

            step = HistoryTableWork.SpecialitiesHistory(step, time.Value, DoneStatusEnum.Redone);

            return RedirectToAction("Index", "SpecialitiesHistory", new { time = time, step = step });
        }
    }
}