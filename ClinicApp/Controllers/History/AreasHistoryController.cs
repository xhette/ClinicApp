using ClinicApp.Models;
using ClinicData;
using ClinicData.Entities;
using ClinicData.HistoryBase;
using ClinicData.HistoryBase.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicApp.Controllers.History
{
    public class AreasHistoryController : Controller
    {
        // GET: Areas
        public ActionResult Index(DateTime? time = null, int step = 0)
        {
            if (!time.HasValue)
            {
                time = DateTime.Now;
            }

            ViewBag.Step = step;
            ViewBag.Time = time;

            DbWork db = new DbWork();
            List<AreaModel> model = new List<AreaModel>();

            var dbList = db.GetAreas();

            if (dbList != null)
            {
                foreach (var entity in dbList)
                {
                    model.Add(new AreaModel(entity));
                }
            }

            return View(model);
        }

        public ActionResult Undone(DateTime? time, int step = 0)
		{
            if (!time.HasValue)
            {
                time = DateTime.Now;
            }

            step = HistoryTableWork.AreasHistory(step, time.Value, DoneStatusEnum.Undone);

            return RedirectToAction("Index", "AreasHistory", new { time = time, step = step });
        }

        public ActionResult Redone(DateTime? time, int step = 0)
        {
            if (!time.HasValue)
            {
                time = DateTime.Now;
            }

            step = HistoryTableWork.AreasHistory(step, time.Value, DoneStatusEnum.Redone);

            return RedirectToAction("Index", "AreasHistory", new { time = time, step = step });
        }
    }
}