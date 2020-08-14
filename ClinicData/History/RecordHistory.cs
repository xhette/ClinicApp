using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

using ClinicData.History;

namespace ClinicData.Entities
{
	public class RecordHistory : HistoryTable
	{

		public int PatientNow { get; set; }

		public int DiagnosisNow { get; set; }

		public string TherapyNow { get; set; }

		public int PatientLast { get; set; }

		public int DiagnosisLast { get; set; }

		public string TherapyLast { get; set; }

		public RecordHistory() { }

		public RecordHistory(DbDataRecord rec)
		{
			Id = Convert.ToInt32(rec["case_id"]);
			PatientNow = Convert.ToInt32(rec["patient_now"]);
			DiagnosisNow = Convert.ToInt32(rec["diagnosis_now"]);
			TherapyNow = rec["therapy_now"].ToString();
			PatientLast = Convert.ToInt32(rec["patient_last"]);
			DiagnosisLast = Convert.ToInt32(rec["diagnosis_last"]);
			TherapyLast = rec["therapy_last"].ToString();
			OperationDate = Convert.ToDateTime(rec["operation_time"]);
			Operation = rec["operation"].ToString();
		}
	}
}
