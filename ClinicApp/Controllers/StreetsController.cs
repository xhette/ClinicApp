using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClinicApp.Models;
using ClinicData;
using ClinicData.Entities;

namespace ClinicApp.Controllers
{
    public class StreetsController : Controller
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

        [HttpGet]
        public ActionResult Create()
        {
            StreetModel model = new StreetModel();

            DbWork db = new DbWork();
            var areas = db.GetAreas();

            foreach (var area in areas)
            {
                model.AreasList.Add(new AreaModel(area));
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(StreetModel model)
        {
            Street street = new Street
            {
                Name = model.Name,
                Area = model.Area
            };

            DbWork db = new DbWork();
            db.AddStreet(street);

            return RedirectToAction("Index", "Streets");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            DbWork db = new DbWork();
            var dbEntity = db.GetStreets().Where(c => c.Id == id).FirstOrDefault();

            StreetModel model = new StreetModel(dbEntity);
            var areas = db.GetAreas();

            foreach (var area in areas)
            {
                model.AreasList.Add(new AreaModel(area));
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(StreetModel model)
        {
            Street street = new Street
            {
                Id = model.Id,
                Name = model.Name,
                Area = model.Area
            };

            DbWork db = new DbWork();
            db.EditStreet(street);

            return RedirectToAction("Index", "Streets");
        }

        public ActionResult Delete(int id)
        {
            DbWork db = new DbWork();
            db.DeleteStreet(id);

            return RedirectToAction("Index", "Streets");
        }

        public ActionResult ByArea (int areaId = 0)
        {
            if (areaId == 0)
            {
                return RedirectToAction("Index", "Areas");
            }

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