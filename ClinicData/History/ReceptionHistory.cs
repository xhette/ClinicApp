using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

using ClinicData.History;

namespace ClinicData.Entities
{
	public class ReceptionHistory : HistoryTable
	{

		public DateTime TimeNow { get; set; }

		public int? PatientNow { get; set; }

		public int SheduleNow { get; set; }

		public DateTime TimeLast { get; set; }

		public int? PatientLast { get; set; }

		public int SheduleLast { get; set; }

		public ReceptionHistory() { }

		public ReceptionHistory(DbDataRecord rec)
		{
			Id = Convert.ToInt32(rec["reception_id"]);
			TimeNow = Convert.ToDateTime(rec["reception_time_now"].ToString());
			SheduleNow = Convert.ToInt32(rec["schedule_now"]);
			PatientNow = Convert.ToInt32(rec["patient_now"]);
			TimeLast = Convert.ToDateTime(rec["reception_time_last"].ToString());
			SheduleLast = Convert.ToInt32(rec["schedule_last"]);
			PatientLast = Convert.ToInt32(rec["patient_last"]);
			OperationDate = Convert.ToDateTime(rec["operation_time"]);
			Operation = rec["operation"].ToString();
		}
	}
}
