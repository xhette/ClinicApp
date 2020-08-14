using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

using ClinicData.History;

namespace ClinicData.Entities
{
	public class DiagnosisHistory : HistoryTable
	{

		public string CodeNow { get; set; }

		public string DescriptionNow { get; set; }

		public string CodeLast { get; set; }

		public string DescriptionLast { get; set; }

		public DiagnosisHistory() { }

		public DiagnosisHistory(DbDataRecord rec)
		{
			Id = Convert.ToInt32(rec["diagnosis_id"]);
			CodeNow = rec["diagnosis_code_now"].ToString();
			DescriptionNow = rec["diagnosis_description_now"].ToString();
			CodeLast = rec["diagnosis_code_last"].ToString();
			DescriptionLast = rec["diagnosis_description_last"].ToString();
			OperationDate = Convert.ToDateTime(rec["operation_time"]);
			Operation = rec["operation"].ToString();
		}
	}
}
