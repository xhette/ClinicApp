using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

using ClinicData.History;

namespace ClinicDb.Entities
{
	public class SpecialityHistory : HistoryTable
	{
		public string NameNow { get; set; }

		public string NameLast { get; set; }

		public SpecialityHistory() { }

		public SpecialityHistory(DbDataRecord rec)
		{
			Id = Convert.ToInt32(rec["speciality_id"]);
			NameNow = rec["speciality_name_now"].ToString();
			NameLast = rec["speciality_name_last"].ToString();
			OperationDate = Convert.ToDateTime(rec["operation_time"]);
			Operation = rec["operation"].ToString();
		}
	}
}
