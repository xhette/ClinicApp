using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ClinicData.Entities
{
	public class Diagnosis
	{
		public int Id { get; set; }

		public string Code { get; set; }

		public string Description { get; set; }


		public Diagnosis() { }

		public Diagnosis(DbDataRecord rec)
		{
			Id = Convert.ToInt32(rec["diagnosis_id"]);
			Code = rec["diagnosis_code"].ToString();
			Description = rec["diagnosis_description"].ToString();
		}
	}
}
