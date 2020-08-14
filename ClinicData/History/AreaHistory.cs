using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

using ClinicData.History;

namespace ClinicData.Entities
{
	public class AreaHistory : HistoryTable
	{
		public string NameNow { get; set; }

		public string NameLast { get; set; }

		public AreaHistory() { }

		public AreaHistory(DbDataRecord rec)
		{
			Id = Convert.ToInt32(rec["area_id"]);
			NameNow = rec["area_name_now"].ToString();
			NameLast = rec["area_name_last"].ToString();
			OperationDate = Convert.ToDateTime(rec["operation_time"]);
			Operation = rec["operation"].ToString();
		}
	}
}
