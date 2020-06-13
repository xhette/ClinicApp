using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClinicApp.Models;
using ClinicData;

namespace ClinicApp.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Index()
        {
            int userId = int.TryParse(Session["UserId"].ToString(), out userId) ? userId : 0;

            if (userId > 0)
            {
                DbWork db = new DbWork();
                var pacient = db.GetPatientByUserId(userId);

                PatientModel model = new PatientModel(pacient);

                Session["PatientId"] = model.Id;

                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Records()
        {
            int patientId = int.TryParse(Session["PatientId"].ToString(), out patientId) ? patientId : 0;

            if (patientId > 0)
            {
                DbWork db = new DbWork();
                var records = db.RecordsByPatient(patientId);

                List<CaseRecordModel> model = new List<CaseRecordModel>();

                foreach (var record in records)
                {
                    model.Add(new CaseRecordModel(record));
                }

                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}