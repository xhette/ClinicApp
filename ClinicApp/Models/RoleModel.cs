using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClinicData.Entities;

namespace ClinicApp.Models
{
	public class RoleModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public RoleModel() { }

		public RoleModel(Role db)
		{
			Id = db.Id;
			Name = db.Name;
		}
	}
}