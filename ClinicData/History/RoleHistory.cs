using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

using ClinicData.History;

namespace ClinicData.Entities
{
	public class RoleHistory : HistoryTable
	{

		public string NameNow { get; set; }

		public string NameLast { get; set; }

		public RoleHistory() { }

		public RoleHistory(DbDataRecord rec)
		{
			Id = Convert.ToInt32(rec["role_id"]);
			NameNow = rec["role_name_now"].ToString();
			NameLast = rec["role_name_last"].ToString();
			OperationDate = Convert.ToDateTime(rec["operation_time"]);
			Operation = rec["operation"].ToString();
		}
	}
}
