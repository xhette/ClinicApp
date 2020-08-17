using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ClinicApp.Models;

using ClinicData;

namespace ClinicApp.Controllers.History
{
    public class RecordsHistoryController : Controller
    {
        // GET: CaseRecords
        public ActionResult Index()
        {
            DbWork db = new DbWork();
            var records = db.RecordsList();

            List<CaseRecordModel> model = new List<CaseRecordModel>();

            foreach (var record in records)
            {
                model.Add(new CaseRecordModel(record));
            }

            return View(model);
        }
    }
}