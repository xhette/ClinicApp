using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClinicApp.Models;
using ClinicData;
using ClinicData.Entities;

namespace ClinicApp.Controllers.History
{
    public class StreetsHistoryController : Controller
    {
        // GET: Streets
        public ActionResult Index()
        {
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
    }
}