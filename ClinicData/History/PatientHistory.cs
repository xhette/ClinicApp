using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

using ClinicData.History;

namespace ClinicData.Entities
{
	public class PatientHistory : HistoryTable
	{

		public string SurnameNow { get; set; }

		public string NameNow { get; set; }

		public string PatronymicNow { get; set; }

		public int StreetNow { get; set; }

		public int HouseNow { get; set; }

		public int RoomNow { get; set; }

		public int AccountNow { get; set; }

		public string SurnameLast { get; set; }

		public string NameLast { get; set; }

		public string PatronymicLast { get; set; }

		public int StreetLast { get; set; }

		public int HouseLast { get; set; }

		public int RoomLast { get; set; }

		public int AccountLast { get; set; }

		public PatientHistory() { }

		public PatientHistory(DbDataRecord rec)
		{
			Id = Convert.ToInt32(rec["patient_id"]);
			SurnameNow = rec["patient_surname_now"].ToString();
			NameNow = rec["patient_name_now"].ToString();
			PatronymicNow = rec["patient_patronymic_now"].ToString();
			StreetNow = Convert.ToInt32(rec["street_now"]);
			HouseNow = Convert.ToInt32(rec["house_now"]);
			RoomNow = Convert.ToInt32(rec["room_now"]);
			AccountNow = Convert.ToInt32(rec["account_now"]);
			SurnameLast = rec["patient_surname_last"].ToString();
			NameLast = rec["patient_name_last"].ToString();
			PatronymicLast = rec["patient_patronymic_last"].ToString();
			StreetLast = Convert.ToInt32(rec["street_last"]);
			HouseLast = Convert.ToInt32(rec["house_last"]);
			RoomLast = Convert.ToInt32(rec["room_last"]);
			AccountLast = Convert.ToInt32(rec["account_last"]);
			OperationDate = Convert.ToDateTime(rec["operation_time"]);
			Operation = rec["operation"].ToString();
		}
	}
}

