using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ClinicData.Entities
{
	public class Street
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public int Area { get; set; }

		public Street() { }

		public Street (DbDataRecord rec)
		{
			Id = Convert.ToInt32(rec["street_id"]);
			Name = rec["street_name"].ToString();
			Area = Convert.ToInt32(rec["area"]);
		}
	}
}
