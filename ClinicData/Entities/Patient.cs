using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ClinicData.Entities
{
	public class Patient
	{
		public int Id { get; set; }

		public string Surname { get; set; }

		public string Name { get; set; }

		public string Patronymic { get; set; }

		public int Street { get; set; }

		public string StreetName { get; set; }

		public int House { get; set; }

		public int Room { get; set; }

		public int Account { get; set; }

		public Patient() { }

		public Patient(DbDataRecord rec)
		{
			Id = Convert.ToInt32(rec["patient_id"]);
			Surname = rec["patient_surname"].ToString();
			Name = rec["patient_name"].ToString();
			Patronymic = rec["patient_patronymic"].ToString();
			Street = Convert.ToInt32(rec["street"]);
			StreetName = rec["street_name"].ToString();
			House = Convert.ToInt32(rec["house"]);
			Room = Convert.ToInt32(rec["room"]);
			Account = Convert.ToInt32(rec["account"]);
		}
	}
}

