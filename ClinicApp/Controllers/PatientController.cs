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
            if (Session["UserId"] != null)
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
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Records()
        {
            if (Session["PatientId"] != null)
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
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Receptions()
        {
            if (Session["PatientId"] != null)
            {
                int patientId = int.TryParse(Session["PatientId"].ToString(), out patientId) ? patientId : 0;

                if (patientId > 0)
                {
                    DbWork db = new DbWork();
                    var records = db.ReceptionsByPatient(patientId);

                    List<ReceptionViewModel> model = new List<ReceptionViewModel>();

                    foreach (var record in records)
                    {
                        model.Add(new ReceptionViewModel(record));
                    }

                    return View(model);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult AddReceptionSpecialities()
		{
            if (Session["PatientId"] != null)
            {
                int patientId = int.TryParse(Session["PatientId"].ToString(), out patientId) ? patientId : 0;

                if (patientId > 0)
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

            return RedirectToAction("Index", "Home");
        }

        public ActionResult AddReceptionDoctor(int specId)
        {
            if (Session["PatientId"] != null)
            {
                int patientId = int.TryParse(Session["PatientId"].ToString(), out patientId) ? patientId : 0;

                if (patientId > 0)
                {
                    DbWork db = new DbWork();

                    var specialities = db.GetDoctorsBySpec(specId);

                    List<DoctorModel> model = new List<DoctorModel>();

                    foreach (var spec in specialities)
                    {
                        model.Add(new DoctorModel(spec));
                    }

                    return View(model);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult AddReceptionSchedule(int docId)
        {
            if (Session["PatientId"] != null)
            {
                int patientId = int.TryParse(Session["PatientId"].ToString(), out patientId) ? patientId : 0;

                if (patientId > 0)
                {
                    DbWork db = new DbWork();

                    var specialities = db.GetSheduleByDoctor(docId);

                    List<ScheduleModel> model = new List<ScheduleModel>();

                    foreach (var spec in specialities)
                    {
                        model.Add(new ScheduleModel(spec));
                    }

                    return View(model);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult ReceptionCalendar(int id)
        {
            if (Session["PatientId"] != null)
            {
                int patientId = int.TryParse(Session["PatientId"].ToString(), out patientId) ? patientId : 0;

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

                    return View(model);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult AddReception (DateTime time, int scheduleId)
		{
            if (Session["PatientId"] != null)
            {
                int patientId = int.TryParse(Session["PatientId"].ToString(), out patientId) ? patientId : 0;

                if (patientId > 0)
                {
                    DbWork db = new DbWork();
                    db.AddSchedule(scheduleId, patientId, time);

                    return RedirectToAction("Receptions", "Patient");
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}