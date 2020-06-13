using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ClinicApp.Enums;
using ClinicData.Entities;

namespace ClinicApp.Models
{
	public class UserModel
	{
		public int Id { get; set; }

		[Display(Name = "Логин")]
		[Required(ErrorMessage = "Введите логин")]
		public string Login { get; set; }

		[Display(Name = "Пароль")]
		[Required(ErrorMessage = "Введите пароль")]
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