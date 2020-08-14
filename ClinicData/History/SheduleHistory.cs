using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

using ClinicData.History;

namespace ClinicData.Entities
{
	public class SheduleHistory : HistoryTable
	{

		public DateTime DateNow { get; set; }

		public DateTime StartTimeNow { get; set; }

		public DateTime EndTimeNow { get; set; }

		public int DoctorNow { get; set; }

		public DateTime DateLast { get; set; }

		public DateTime StartTimeLast { get; set; }

		public DateTime EndTimeLast { get; set; }

		public int DoctorLast { get; set; }

		public SheduleHistory() { }

		public SheduleHistory(DbDataRecord rec)
		{
			Id = Convert.ToInt32(rec["schedule_id"]);
			DateNow = Convert.ToDateTime(rec["schedule_date_now"].ToString());
			StartTimeNow = Convert.ToDateTime(rec["start_time_now"].ToString());
			EndTimeNow = Convert.ToDateTime(rec["end_time_now"].ToString());
			DoctorNow = Convert.ToInt32(rec["doctor_now"]);
			DateLast = Convert.ToDateTime(rec["schedule_date_last"].ToString());
			StartTimeLast = Convert.ToDateTime(rec["start_time_last"].ToString());
			EndTimeLast = Convert.ToDateTime(rec["end_time_last"].ToString());
			DoctorLast = Convert.ToInt32(rec["doctor_last"]);
			OperationDate = Convert.ToDateTime(rec["operation_time"]);
			Operation = rec["operation"].ToString();
		}
	}
}
