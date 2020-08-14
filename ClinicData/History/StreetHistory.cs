using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

using ClinicData.History;

namespace ClinicData.Entities
{
	public class StreetHistory : HistoryTable
	{
		public string NameNow { get; set; }

		public int AreaNow { get; set; }

		public string NameLast { get; set; }

		public int AreaLast { get; set; }

		public StreetHistory() { }

		public StreetHistory(DbDataRecord rec)
		{
			Id = Convert.ToInt32(rec["street_id"]);
			NameNow = rec["street_name_now"].ToString();
			AreaNow = Convert.ToInt32(rec["area_now"]);
			NameLast = rec["street_name_last"].ToString();
			AreaLast = Convert.ToInt32(rec["area_last"]);
			OperationDate = Convert.ToDateTime(rec["operation_time"]);
			Operation = rec["operation"].ToString();
		}
	}
}
