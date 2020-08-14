using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

using ClinicData.History;

namespace ClinicData.Entities
{
	public class UserHistory : HistoryTable
	{

		public string LoginNow { get; set; }

		public string PasswordNow { get; set; }

		public int RoleNow { get; set; }

		public string LoginLast { get; set; }

		public string PasswordLast { get; set; }

		public int RoleLast { get; set; }

		public UserHistory() { }

		public UserHistory(DbDataRecord rec)
		{
			Id = Convert.ToInt32(rec["user_id"]);
			LoginNow = rec["login_now"].ToString();
			PasswordNow = rec["password_now"].ToString();
			RoleNow = Convert.ToInt32(rec["role_now"]);
			LoginLast = rec["login_last"].ToString();
			PasswordLast = rec["password_last"].ToString();
			RoleLast = Convert.ToInt32(rec["role_last"]);
			OperationDate = Convert.ToDateTime(rec["operation_time"]);
			Operation = rec["operation"].ToString();
		}
	}
}
