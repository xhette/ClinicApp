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
    public class RolesController : Controller
    {
        // GET: Roles
        public ActionResult Index()
        {
            DbWork db = new DbWork();
            List<RoleModel> model = new List<RoleModel>();

            var dbList = db.GetRoles();

            if (dbList != null)
            {
                foreach (var entity in dbList)
                {
                    model.Add(new RoleModel(entity));
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            RoleModel model = new RoleModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(RoleModel model)
        {
            Role area = new Role
            {
                Name = model.Name
            };

            DbWork db = new DbWork();
            db.AddRole(area);

            return RedirectToAction("Index", "Roles");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            DbWork db = new DbWork();
            var dbEntity = db.GetRoles().Where(c => c.Id == id).FirstOrDefault();

            RoleModel model = new RoleModel(dbEntity);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(RoleModel model)
        {
            Role area = new Role
            {
                Id = model.Id,
                Name = model.Name
            };

            DbWork db = new DbWork();
            db.EditRole(area);

            return RedirectToAction("Index", "Roles");
        }

        public ActionResult Delete(int id)
        {
            DbWork db = new DbWork();
            db.DeleteRole(id);

            return RedirectToAction("Index", "Roles");
        }
    }
}