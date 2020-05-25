using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ClinicData.Entities
{
	public class Role
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public Role () { }

		public Role (DbDataRecord rec)
		{
			Id = Convert.ToInt32(rec["role_id"]);
			Name = rec["role_name"].ToString();
		}
	}
}
