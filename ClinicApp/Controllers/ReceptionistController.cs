using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ClinicApp.Models;
using ClinicData;

namespace ClinicApp.Controllers
{
    public class ReceptionistController : Controller
    {
        // GET: Receptionist
        public ActionResult Index()
        {
            DbWork db = new DbWork();
            List<PatientModel> model = new List<PatientModel>();

            var patients = db.PatientsList();

            foreach (var entity in patients)
			{
                model.Add(new PatientModel(entity));
			}

            return View(model);
        }

        public ActionResult Areas()
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

        public ActionResult PatientsByArea (int areaId, string areaName = "")
		{
            TempData["AreaName"] = areaName;

            DbWork db = new DbWork();
            List<PatientModel> model = new List<PatientModel>();

            var patients = db.PatientsListByArea(areaId);

            foreach (var entity in patients)
            {
                model.Add(new PatientModel(entity));
            }

            return View(model);
        }

        public ActionResult StreetsByArea(int areaId, string areaName = "")
        {
            TempData["AreaName"] = areaName;

            DbWork db = new DbWork();
            List<StreetModel> model = new List<StreetModel>();

            var dbList = db.GetStreetsByArea(areaId);

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