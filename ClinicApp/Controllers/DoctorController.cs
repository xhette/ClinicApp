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
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult Index()
        {
            if (Session["UserId"] != null)
            {
                int userId = int.TryParse(Session["UserId"].ToString(), out userId) ? userId : 0;

                if (userId > 0)
                {
                    DbWork db = new DbWork();
                    var doctor = db.GetDoctorByUserId(userId);

                    DoctorModel model = new DoctorModel(doctor);

                    Session["DoctorId"] = model.Id;

                    return View(model);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Patients()
		{
            if (Session["DoctorId"] != null)
            {
                int doctorId = int.TryParse(Session["DoctorId"].ToString(), out doctorId) ? doctorId : 0;

                if (doctorId > 0)
                {
                    List<PatientModel> model = new List<PatientModel>();

                    DbWork db = new DbWork();
                    var patients = db.PatientsListByDoctor(doctorId);

                    foreach (var p in patients)
                    {
                        model.Add(new PatientModel(p));
                    }

                    return View(model);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Records(int patientId)
        {
            if (Session["DoctorId"] != null)
            {
                int doctorId = int.TryParse(Session["DoctorId"].ToString(), out doctorId) ? doctorId : 0;

                if (doctorId > 0)
                {
                    DbWork db = new DbWork();
                    var records = db.RecordsByPatient(patientId);

                    List<CaseRecordModel> model = new List<CaseRecordModel>();

                    foreach (var record in records)
                    {
                        model.Add(new CaseRecordModel(record));
                    }

                    TempData["PatientId"] = patientId;
                    return View(model);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Schedule()
        {
            if (Session["DoctorId"] != null)
            {
                int docId = int.TryParse(Session["DoctorId"].ToString(), out docId) ? docId : 0;

                if (docId > 0)
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

        public ActionResult Calendar(int id)
        {
            if (Session["DoctorId"] != null)
            {
                int docId = int.TryParse(Session["DoctorId"].ToString(), out docId) ? docId : 0;

                if (docId > 0)
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

        [HttpGet]
        public ActionResult AddRecord (int patientId)
		{
            if (Session["DoctorId"] != null)
            {
                int docId = int.TryParse(Session["DoctorId"].ToString(), out docId) ? docId : 0;

                if (docId > 0)
                {
                    DbWork db = new DbWork();

                    RecordModel model = new RecordModel();
                    model.Patient = patientId;

                    var diagnosis = db.GetDiagnoses();

                    foreach (var d in diagnosis)
                    {
                        model.Diagnoses.Add(new DiagnosisModel(d));
                    }

                    return View(model);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult AddRecord(RecordModel model)
        {
            if (Session["DoctorId"] != null)
            {
                int docId = int.TryParse(Session["DoctorId"].ToString(), out docId) ? docId : 0;

                if (docId > 0)
                {
                    DbWork db = new DbWork();

                    if (ModelState.IsValid)
                    {
                        db.AddDiagnosis(new Record
                        {
                            Id = 0,
                            Diagnosis = model.Diagnosis,
                            Patient = model.Patient,
                            Therapy = model.Therapy
                        });

                        return RedirectToAction("Patients", "Doctor");
                    }
                    else
                    {
                        return View(model);
                    }
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}