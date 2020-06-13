using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ClinicData.Composite;
using ClinicData.Entities;

namespace ClinicApp.Models
{
	public class PatientModel
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

		[Display(Name = "Улица")]
		[Required(ErrorMessage = "Выберите улицу")]
		public int Street { get; set; }

		public string StreetName { get; set; }

		[Display(Name = "Дом")]
		[Required(ErrorMessage = "Введите номер дома")]
		public int House { get; set; }

		[Display(Name = "Квартира")]
		[Required(ErrorMessage = "Введите номер квартиры")]
		public int Room { get; set; }

		public int Account { get; set; }

		public string Address
		{
			get
			{
				return String.Format("{0}, д. {1}, кв. {2}", StreetName, House, Room);
			}
		}

		public PatientModel() { }

		public PatientModel (Patient pacient)
		{
			Id = pacient.Id;
			Surname = pacient.Surname;
			Name = pacient.Name;
			Patronymic = pacient.Patronymic;
			Street = pacient.Street;
			StreetName = pacient.StreetName;
			House = pacient.House;
			Room = pacient.Room;
			Account = pacient.Account;
		}

		public PatientModel(PatientComposite pacient)
		{
			Id = pacient.Patient.Id;
			Surname = pacient.Patient.Surname;
			Name = pacient.Patient.Name;
			Patronymic = pacient.Patient.Patronymic;
			Street = pacient.Patient.Street;
			StreetName = pacient.Patient.StreetName;
			House = pacient.Patient.House;
			Room = pacient.Patient.Room;
			Account = pacient.Patient.Account;
			StreetName = pacient.Street.Name;
		}
	}
}