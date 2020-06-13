using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClinicDb.Entities;

namespace ClinicApp.Models
{
	public class SpecialityModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public SpecialityModel() { }

		public SpecialityModel (Speciality db)
		{
			Id = db.Id;
			Name = db.Name;
		}
	}
}