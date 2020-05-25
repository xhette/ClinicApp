using ClinicApp.Models;
using ClinicData;
using ClinicData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicApp.Controllers
{
    public class AreasController : Controller
    {
        // GET: Areas
        public ActionResult Index()
        {
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
    }
}