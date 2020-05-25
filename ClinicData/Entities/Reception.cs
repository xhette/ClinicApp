using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ClinicData.Entities
{
	public class Reception
	{
		public int Id { get; set; }

		public DateTime Time { get; set; }

		public int Patient { get; set; }

		public int Shedule { get; set; }

		public Reception () { }

		public Reception (DbDataRecord rec)
		{
			Id = Convert.ToInt32(rec["reception_id"]);
			Time = Convert.ToDateTime(rec["reception_time"]);
			Shedule = Convert.ToInt32(rec["shedule"]);
			Patient = Convert.ToInt32(rec["patient"]);
		}
	}
}
