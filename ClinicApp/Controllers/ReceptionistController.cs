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

        public ActionResult AddReceptionSpecialities(int patientId)
        {
            DbWork db = new DbWork();

            var specialities = db.GetSpecialities();

            List<SpecialityModel> model = new List<SpecialityModel>();

            foreach (var spec in specialities)
            {
                model.Add(new SpecialityModel(spec));
            }

            TempData["PatientId"] = patientId;
            return View(model);
        }

        public ActionResult AddReceptionDoctor(int specId)
        {
            DbWork db = new DbWork();

            int patientId = int.TryParse(TempData["PatientId"].ToString(), out patientId) ? patientId : 0;

            if (patientId > 0)
            {

                var specialities = db.GetDoctorsBySpecAndPatient(specId, patientId);

                List<DoctorModel> model = new List<DoctorModel>();

                foreach (var spec in specialities)
                {
                    model.Add(new DoctorModel(spec));
                }

                TempData["PatientId"] = patientId;
                return View(model);
            }

            return RedirectToAction("Index", "Receptionist");
        }

        public ActionResult AddReceptionSchedule(int docId)
        {
            int patientId = int.TryParse(TempData["PatientId"].ToString(), out patientId) ? patientId : 0;

            if (patientId > 0)
            {
                DbWork db = new DbWork();

                var specialities = db.GetSheduleByDoctor(docId);

                List<ScheduleModel> model = new List<ScheduleModel>();

                foreach (var spec in specialities)
                {
                    model.Add(new ScheduleModel(spec));
                }

                TempData["PatientId"] = patientId;

                return View(model);
            }

            return RedirectToAction("Index", "Receptionist");
        }

        public ActionResult ReceptionCalendar(int id)
        {

            int patientId = int.TryParse(TempData["PatientId"].ToString(), out patientId) ? patientId : 0;

            if (patientId > 0)
            {
                DbWork db = new DbWork();
                var schedule = db.GetSheduleById(id);

                ScheduleModel model = new ScheduleModel(schedule);

                DateTime timeStart = model.StartTime;
                DateTime timeEnd = model.EndTime;

                while (timeStart < timeEnd)
                {
                    var reception = db.ReceptionByScheduleAndTime(model.Id, timeStart);
                    model.Receptions.Add(new ReceptionModel(reception));

                    timeStart = timeStart.AddMinutes(15);
                }

                TempData["PatientId"] = patientId;
                return View(model);
            }

            return RedirectToAction("Index", "Receptionist");
        }

        public ActionResult AddReception(DateTime time, int scheduleId)
        {
            int patientId = int.TryParse(TempData["PatientId"].ToString(), out patientId) ? patientId : 0;

            if (patientId > 0)
            {
                DbWork db = new DbWork();
                db.AddSchedule(scheduleId, patientId, time);

                return RedirectToAction("Index", "Receptionist");
            }

            return RedirectToAction("Index", "Receptionist");
        }

        public ActionResult Doctors(int areaId, string areaName = "")
        {
            TempData["AreaName"] = areaName;

            DbWork db = new DbWork();
            var specialities = db.GetDoctorsByArea(areaId);

            List<DoctorModel> model = new List<DoctorModel>();

            foreach (var spec in specialities)
            {
                model.Add(new DoctorModel(spec));
            }

            return View(model);

        }
    }
}