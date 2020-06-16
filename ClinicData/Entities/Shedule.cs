using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ClinicData.Entities
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
			Id = Convert.ToInt32(rec["schedule_id"]);
			Date = Convert.ToDateTime(rec["schedule_date"].ToString());
			StartTime = Convert.ToDateTime(rec["start_time"].ToString());
			EndTime = Convert.ToDateTime(rec["end_time"].ToString());
			Doctor = Convert.ToInt32(rec["doctor"]);
		}
	}
}
