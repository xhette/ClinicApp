﻿using ClinicApp.Models;
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

        [HttpGet]
        public ActionResult Create()
        {
            AreaModel model = new AreaModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(AreaModel model)
        {
            Area area = new Area
            {
                Name = model.Name
            };

            DbWork db = new DbWork();
            db.AddArea(area);

            return RedirectToAction("Index", "Areas");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            DbWork db = new DbWork();
            var dbEntity = db.GetAreas().Where(c => c.Id == id).FirstOrDefault();

            AreaModel model = new AreaModel(dbEntity);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AreaModel model)
        {
            Area area = new Area
            {
                Id = model.Id,
                Name = model.Name
            };

            DbWork db = new DbWork();
            db.EditArea(area);

            return RedirectToAction("Index", "Areas");
        }

        public ActionResult Delete(int id)
        {
            DbWork db = new DbWork();
            db.DeleteArea(id);

            return RedirectToAction("Index", "Areas");
        }
    }
}