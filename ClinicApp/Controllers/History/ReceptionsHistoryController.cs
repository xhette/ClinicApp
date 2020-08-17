using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ClinicApp.Models;

using ClinicData;

namespace ClinicApp.Controllers.History
{
    public class ReceptionsHistoryController : Controller
    {
        // GET: ReceptionsHistory
        public ActionResult Index()
        {
            DbWork db = new DbWork();
            var records = db.GetReceptions();

            List<ReceptionViewModel> model = new List<ReceptionViewModel>();

            foreach (var record in records)
            {
                model.Add(new ReceptionViewModel(record));
            }

            return View(model);
        }
    }
}