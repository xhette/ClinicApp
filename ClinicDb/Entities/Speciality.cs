using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ClinicDb.Entities
{
	public class Speciality
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public Speciality() { }

		public Speciality(DbDataRecord rec)
		{
			Id = Convert.ToInt32(rec["speciality_id"]);
			Name = rec["speciality_name"].ToString();
		}
	}
}
