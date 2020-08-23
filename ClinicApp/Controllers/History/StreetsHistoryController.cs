using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClinicApp.Models;
using ClinicData;
using ClinicData.Entities;
using ClinicData.HistoryBase;
using ClinicData.HistoryBase.Enums;

namespace ClinicApp.Controllers.History
{
    public class StreetsHistoryController : Controller
    {
        // GET: Streets
        public ActionResult Index(DateTime? time, int step = 0)
        {

            if (!time.HasValue)
            {
                time = DateTime.Now;
            }

            ViewBag.Step = step;
            ViewBag.Time = time;

            DbWork db = new DbWork();
            List<StreetModel> model = new List<StreetModel>();

            var dbList = db.GetStreets();

            if (dbList != null)
            {
                foreach (var entity in dbList)
                {
                    model.Add(new StreetModel(entity));
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

            step = HistoryTableWork.StreetsHistory(step, time.Value, DoneStatusEnum.Undone);

            return RedirectToAction("Index", "StreetsHistory", new { time = time, step = step });
        }

        public ActionResult Redone(DateTime? time, int step = 0)
        {
            if (!time.HasValue)
            {
                time = DateTime.Now;
            }

            step = HistoryTableWork.StreetsHistory(step, time.Value, DoneStatusEnum.Redone);

            return RedirectToAction("Index", "StreetsHistory", new { time = time, step = step });
        }
    }
}