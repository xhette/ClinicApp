using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClinicApp.Enums;
using ClinicData.Entities;

namespace ClinicApp.Models
{
	public class UserModel
	{
		public int Id { get; set; }

		public string Login { get; set; }

		public string Password { get; set; }

		public UserRoleEnum Role { get; set; }

		public UserModel() { }

		public UserModel(User db)
		{
			Id = db.Id;
			Login = db.Login;
			Password = db.Password;
			Role = (UserRoleEnum)db.Role;
		}
	}
}