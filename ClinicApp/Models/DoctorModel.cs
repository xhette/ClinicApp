using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ClinicData.Entities;

namespace ClinicApp.Models
{
	public class DoctorModel
	{
		public int Id { get; set; }

		[Display(Name = "Фамилия")]
		[Required(ErrorMessage = "Введите фамилию")]
		public string Surname { get; set; }

		[Display(Name = "Имя")]
		[Required(ErrorMessage = "Введите имя")]
		public string Name { get; set; }

		[Display(Name = "Отчество")]
		[Required(ErrorMessage = "Введите отчество")]
		public string Patronymic { get; set; }

		[Display(Name = "Специализация")]
		[Required(ErrorMessage = "Выберите специализацию")]
		public int Speciality { get; set; }

		public string SpecialityName { get; set; }

		[Display(Name = "Участок")]
		[Required(ErrorMessage = "Выберите участок")]
		public int Area { get; set; }

		public int Account { get; set; }

		public DoctorModel() { }

		public DoctorModel (Doctor db)
		{
			Id = db.Id;
			Surname = db.Surname;
			Name = db.Name;
			Patronymic = db.Patronymic;
			Speciality = db.Speciality;
			SpecialityName = db.SpecialityName;
			Area = db.Area;
			Account = db.Account;
		}
	}
}