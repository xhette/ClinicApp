using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace ClinicData.Entities
{
	public class Area
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public Area() { }

		public Area(DbDataRecord rec)
		{
			Id = Convert.ToInt32(rec["area_id"]);
			Name = rec["area_name"].ToString();
		}
	}
}
