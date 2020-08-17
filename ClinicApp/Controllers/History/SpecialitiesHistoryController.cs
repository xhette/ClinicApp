using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ClinicApp.Models;

using ClinicData;

namespace ClinicApp.Controllers.History
{
    public class SpecialitiesHistoryController : Controller
    {
        // GET: SpecialitiesHistory
        public ActionResult Index()
        {
            DbWork db = new DbWork();

            var specialities = db.GetSpecialities();

            List<SpecialityModel> model = new List<SpecialityModel>();

            foreach (var spec in specialities)
            {
                model.Add(new SpecialityModel(spec));
            }

            return View(model);
        }
    }
}