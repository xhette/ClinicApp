using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

using ClinicData.History;

namespace ClinicData.Entities
{
	public class DoctorHistory : HistoryTable
	{

		public string SurnameNow { get; set; }

		public string NameNow { get; set; }

		public string PatronymicNow { get; set; }

		public int SpecialityNow { get; set; }

		public int AreaNow { get; set; }

		public int AccountNow { get; set; }

		public string SurnameLast { get; set; }

		public string NameLast { get; set; }

		public string PatronymicLast { get; set; }

		public int SpecialityLast { get; set; }

		public int AreaLast { get; set; }

		public int AccountLast { get; set; }

		public DoctorHistory() { }

		public DoctorHistory(DbDataRecord rec)
		{
			Id = Convert.ToInt32(rec["doctor_id"]);
			SurnameNow = rec["doctor_surname_now"].ToString();
			NameNow = rec["doctor_name_now"].ToString();
			PatronymicNow = rec["doctor_patronymic_now"].ToString();
			SpecialityNow = Convert.ToInt32(rec["speciality_now"]);
			AreaNow = Convert.ToInt32(rec["area_now"]);
			AccountNow = Convert.ToInt32(rec["account_now"]);
			SurnameLast = rec["doctor_surname_last"].ToString();
			NameLast = rec["doctor_name_last"].ToString();
			PatronymicLast = rec["doctor_patronymi_lastc"].ToString();
			SpecialityLast = Convert.ToInt32(rec["speciality_last"]);
			AreaLast = Convert.ToInt32(rec["area_last"]);
			AccountLast = Convert.ToInt32(rec["account_last"]);
			OperationDate = Convert.ToDateTime(rec["operation_time"]);
			Operation = rec["operation"].ToString();
		}
	}
}
