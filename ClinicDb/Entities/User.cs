using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ClinicDb.Entities
{
	public class User
	{
		public int Id { get; set; }

		public string Login { get; set; }

		public string Password { get; set; }

		public int Role { get; set; }

		public User () { }

		public User (DbDataRecord rec)
		{
			Id = Convert.ToInt32(rec["user_id"]);
			Login = rec["login"].ToString();
			Password = rec["password"].ToString();
			Role = Convert.ToInt32(rec["role"]);
		}
	}
}
