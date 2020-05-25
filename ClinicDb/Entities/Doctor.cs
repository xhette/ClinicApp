using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ClinicDb.Entities
{
	public class Doctor
	{
		public int Id { get; set; }

		public string Surname { get; set; }

		public string Name { get; set; }

		public string Patronymic { get; set; }

		public int Speciality { get; set; }

		public int Area { get; set; }

		public int Account { get; set; }

		public Doctor() { }

		public Doctor(DbDataRecord rec)
		{
			Id = Convert.ToInt32(rec["doctor_id"]);
			Surname = rec["doctor_surname"].ToString();
			Name = rec["doctor_name"].ToString();
			Patronymic = rec["doctor_patronymic"].ToString();
			Speciality = Convert.ToInt32(rec["speciality"]);
			Area = Convert.ToInt32(rec["area"]);
			Account = Convert.ToInt32(rec["account"]);
		}
	}
}
