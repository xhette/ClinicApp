using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClinicApp.Enums;
using ClinicApp.Models;
using ClinicData;

namespace ClinicApp.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			UserModel model = new UserModel();

			return View(model);
		}

		[HttpPost]
		public ActionResult Index(UserModel model)
		{
			DbWork db = new DbWork();
			var user = db.GetUserByLogin(model.Login);

			if (user.Password == model.Password)
			{
				UserRoleEnum role = (UserRoleEnum)user.Role;

				switch (role)
				{
					case UserRoleEnum.Pacient:
						Session["UserId"] = user.Id;
						Session["UserRole"] = UserRoleEnum.Pacient;
						return RedirectToAction("Index", "Patient");

					case UserRoleEnum.Doctor:
						Session["UserId"] = user.Id;
						Session["UserRole"] = UserRoleEnum.Doctor;
						return RedirectToAction("Index", "Doctor");

					case UserRoleEnum.Receptionist:
						Session["UserId"] = user.Id;
						Session["UserRole"] = UserRoleEnum.Receptionist;
						return RedirectToAction("Index", "Receptionist");

					default: break;
				}
			}

			return RedirectToAction("Index", "Home");
		}
	}
}