using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ClinicData.Entities
{
	public class Record
	{
		public int Id { get; set; }

		public int Patient { get; set; }

		public int Diagnosis { get; set; }

		public string Therapy { get; set; }

		public Record() { }

		public Record (DbDataRecord rec)
		{
			Id = Convert.ToInt32(rec["case_id"]);
			Patient = Convert.ToInt32(rec["patient"]);
			Diagnosis = Convert.ToInt32(rec["diagnosis"]);
			Therapy = rec["therapy"].ToString();
		}
	}
}
