using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClinicApp.Models;
using ClinicData;
using ClinicData.Composite;
using ClinicData.Entities;

namespace ClinicApp.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RegisterPacient()
        {
            RegisterPatientModel model = new RegisterPatientModel();

            DbWork db = new DbWork();

            var streets = db.GetStreets();

            foreach (var st in streets)
            {
                model.Streets.Add(new StreetModel(st));
            }

            return View(model);
        }

        public ActionResult RegisterPacient(RegisterPatientModel model)
        {
            PatientComposite patient = new PatientComposite
            {
                Patient = new Patient
                {
                    Surname = model.Patient.Surname,
                    Name = model.Patient.Name,
                    Patronymic = model.Patient.Patronymic,
                    Street = model.Patient.Street,
                    House = model.Patient.House,
                    Room = model.Patient.Room
                },
                User = new User
                {
                    Login = model.User.Login,
                    Password = model.User.Password
                }
            };

            DbWork db = new DbWork();
            db.RegistryPatient(patient);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult RegisterDoctor()
        {
            RegisterDoctorModel model = new RegisterDoctorModel();

            DbWork db = new DbWork();

            var areas = db.GetAreas();

            foreach (var st in areas)
            {
                model.Areas.Add(new AreaModel(st));
            }

            var specialities = db.GetSpecialities();

            foreach (var st in specialities)
            {
                model.Specialities.Add(new SpecialityModel(st));
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult RegisterDoctor (RegisterDoctorModel model)
        {
            DoctorComposite doctor = new DoctorComposite
            {
                Doctor = new Doctor
                {
                    Surname = model.Doctor.Surname,
                    Name = model.Doctor.Name,
                    Patronymic = model.Doctor.Patronymic,
                    Area = model.Doctor.Area,
                    Speciality = model.Doctor.Speciality
                },

                User = new User
                {
                    Login = model.User.Login,
                    Password = model.User.Password
                }
            };

            DbWork db = new DbWork();
            db.RegisterDoctor(doctor);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult RegisterReceptionist()
        {
            UserModel model = new UserModel
            {
                Role = Enums.UserRoleEnum.Receptionist
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult RegisterReceptionist(UserModel model)
        {
            User user = new User
            {
                Login = model.Login,
                Password = model.Password
            };

            DbWork db = new DbWork();
            db.RegisteReceptionist(user);

            return RedirectToAction("Index", "Home");
        }
    }
}