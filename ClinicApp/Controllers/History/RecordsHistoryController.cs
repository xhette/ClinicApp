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
    public class RecordsHistoryController : Controller
    {
        // GET: CaseRecords
        public ActionResult Index(DateTime? time, int step = 0)
        {

            if (!time.HasValue)
            {
                time = DateTime.Now;
            }

            ViewBag.Step = step;
            ViewBag.Time = time;

            DbWork db = new DbWork();
            var records = db.RecordsList();

            List<CaseRecordModel> model = new List<CaseRecordModel>();

            foreach (var record in records)
            {
                model.Add(new CaseRecordModel(record));
            }

            return View(model);
        }

        public ActionResult Undone(DateTime? time, int step = 0)
        {
            if (!time.HasValue)
            {
                time = DateTime.Now;
            }

            step = HistoryTableWork.CaseRecordsHistory(step, time.Value, DoneStatusEnum.Undone);

            return RedirectToAction("Index", "RecordsHistory", new { time = time, step = step });
        }

        public ActionResult Redone(DateTime? time, int step = 0)
        {
            if (!time.HasValue)
            {
                time = DateTime.Now;
            }

            step = HistoryTableWork.CaseRecordsHistory(step, time.Value, DoneStatusEnum.Redone);

            return RedirectToAction("Index", "RecordsHistory", new { time = time, step = step });
        }
    }
}