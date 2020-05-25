using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ClinicDb.Entities
{
	public class Shedule
	{
		public int Id { get; set; }

		public DateTime Date { get; set; }

		public DateTime StartTime { get; set; }

		public DateTime EndTime { get; set; }

		public int Doctor { get; set; }

		public Shedule () { }

		public Shedule (DbDataRecord rec)
		{
			Id = Convert.ToInt32(rec["shedule_id"]);
			Date = Convert.ToDateTime(rec["shedule_date"]);
			StartTime = Convert.ToDateTime(rec["start_time"]);
			EndTime = Convert.ToDateTime(rec["end_time"]);
			Doctor = Convert.ToInt32(rec["doctor"]);
		}
	}
}
