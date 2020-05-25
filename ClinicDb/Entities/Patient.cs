using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ClinicDb.Entities
{
	public class Patient
	{
		public int Id { get; set; }

		public string Surname { get; set; }

		public string Name { get; set; }

		public string Patronymic { get; set; }

		public int Street { get; set; }

		public int House { get; set; }

		public int Room { get; set; }

		public int Account { get; set; }

		public Patient() { }

		public Patient(DbDataRecord rec)
		{
			Id = Convert.ToInt32(rec["pacient_id"]);
			Surname = rec["pacient_surname"].ToString();
			Name = rec["pacient_name"].ToString();
			Patronymic = rec["pacient_patronymic"].ToString();
			Street = Convert.ToInt32(rec["street"]);
			House = Convert.ToInt32(rec["house"]);
			Room = Convert.ToInt32(rec["room"]);
			Account = Convert.ToInt32(rec["account"]);
		}
	}
}

